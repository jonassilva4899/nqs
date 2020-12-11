using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace Leega.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private HttpClient apiClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
            apiClient.BaseAddress = new Uri(_configuration["ApiBaseAddres"]);
        }

        [AllowAnonymous]

        public IActionResult Login(string returnUrl, string companyid)
        {
            if (!string.IsNullOrEmpty(companyid))
            {
                HttpContext.Session.SetString("companyid", companyid);
            }
            else
            {
                HttpContext.Session.Remove("companyid");
            }

            Models.Login model = new Models.Login()
            {
                returnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Models.Login model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {

                StringContent content = new StringContent(JsonSerializer.Serialize(model, typeof(Models.Login)), Encoding.UTF8, "application/json");


                //HttpResponseMessage httpResponse = await apiClient.PostAsync("/api/Token", content);
                HttpResponseMessage httpResponse = await apiClient.PostAsync("/api/Token", content);

                var result = await httpResponse.Content.ReadAsStringAsync();
                JObject Usuario = JObject.Parse(result.ToString());

                if (httpResponse.IsSuccessStatusCode)
                {
                    JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(Usuario["token"].ToString());

                    ClaimsIdentity identity = new ClaimsIdentity(jwtSecurityToken.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim("token", Usuario["token"].ToString()));
                    //identity.AddClaim(new Claim("IdOrganizacao", Usuario["IdOrganizacao"].ToString()));

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties() { });

                    var IdPessoa = new Guid(Usuario["id"].ToString());
                    Leega.Dtos.Pessoa pessoa = ObterLoginPessoa(IdPessoa);

                    if (pessoa != null)
                    {
                        HttpContext.Session.SetString("username", pessoa.nomesocial ?? pessoa.nome);
                        if (pessoa.imagem != null)
                        {
                            HttpContext.Session.SetString("userpicture", pessoa.imagem);
                        }
                    }
                    else
                    {
                        HttpContext.Session.SetString("username", model.Usuario);
                    }
                    if (!string.IsNullOrEmpty(model.returnUrl))
                    {
                        return Redirect(model.returnUrl);
                    }
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        ModelState.AddModelError("password", "Login/senha incorreto");
                        return View(model);
                    }
                }
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }

            return View();         
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(Leega.Dtos.ForgotPassword model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(model, typeof(Leega.Dtos.ForgotPassword)), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await apiClient.PostAsync("/Login/ValidarRecuperarSenha", content);

            var result = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("index", "home");
            }

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult ResetPassword(string token)
        {
            Leega.Dtos.PasswordReset model = new Leega.Dtos.PasswordReset()
            {
                token = token
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(Leega.Dtos.PasswordReset model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(model, typeof(Leega.Dtos.PasswordReset)), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await apiClient.PostAsync("/account/resetpassword", content);

            var result = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("login", "account");
            }

            List<ProblemDetails> problems = (List<ProblemDetails>)JsonSerializer.Deserialize(result, typeof(List<ProblemDetails>));

            problems.ForEach(problem =>
            {
                switch (problem.Type)
                {
                    case "PasswordRequireDigit":
                        ModelState.AddModelError("newPassword", "Senha requer números");
                        break;
                    case "PasswordRequireLower":
                        ModelState.AddModelError("newPassword", "Senha requer letras minúsculas");
                        break;
                    case "PasswordRequireNonLetterOrDigit":
                        ModelState.AddModelError("newPassword", "Senha requer caracteres especiais");
                        break;
                    case "PasswordRequireUpper":
                        ModelState.AddModelError("newPassword", "Senha requer letras maiúsculas");
                        break;
                    case "PasswordTooShort":
                        ModelState.AddModelError("newPassword", "Senha é muito curta");
                        break;
                    default:
                        ModelState.AddModelError("newPassword", problem.Detail);
                        break;
                }
            });

            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Register(string returnUrl, string tipo)
        {
            return View("register", new Models.Pessoa() { tipo = tipo ?? "F", returnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(Models.Pessoa model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            StringContent content = new StringContent(System.Text.Json.JsonSerializer.Serialize(model, typeof(Leega.Dtos.Pessoa)), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await apiClient.PostAsync("/account/register", content);

            var result = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
            {
                return Login(new Models.Login() { Usuario = model.register.username, Senha = model.register.password, returnUrl = model.returnUrl }).Result;
            }

            List<ProblemDetails> problems = (List<ProblemDetails>)JsonSerializer.Deserialize(result, typeof(List<ProblemDetails>));

            problems.ForEach(problem =>
            {
                switch (problem.Type)
                {
                    case "DuplicateUserName":
                        ModelState.AddModelError("register.password", "Usuário já cadastrado");
                        break;
                    case "PasswordRequireDigit":
                        ModelState.AddModelError("register.password", "Senha requer números");
                        break;
                    case "PasswordRequireLower":
                        ModelState.AddModelError("register.password", "Senha requer letras minúsculas");
                        break;
                    case "PasswordRequireNonLetterOrDigit":
                        ModelState.AddModelError("register.password", "Senha requer caracteres especiais");
                        break;
                    case "PasswordRequireUpper":
                        ModelState.AddModelError("register.password", "Senha requer letras maiúsculas");
                        break;
                    case "PasswordTooShort":
                        ModelState.AddModelError("register.password", "Senha é muito curta");
                        break;
                    default:
                        ModelState.AddModelError("register.password", problem.Detail);
                        break;
                }
            });

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var model = new
            {
                email = email,
                token = token
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = await apiClient.PostAsync("/account/confirmemail", content);

            var result = await httpResponse.Content.ReadAsStringAsync();

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Clear();

            return RedirectToAction("login", "account");
        }

        private Leega.Dtos.Pessoa ObterLoginPessoa(Guid idPessoa)
        {
            StringContent content = new StringContent(string.Format("\"{0}\"", idPessoa), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse = apiClient.PostAsync("/pessoa/obterporuser", content).Result;

            var result = httpResponse.Content.ReadAsStringAsync().Result;

            if (!string.IsNullOrEmpty(result))
            {
                return (Leega.Dtos.Pessoa)JsonSerializer.Deserialize(result, typeof(Leega.Dtos.Pessoa));
            }

            return null;
        }

        [AllowAnonymous]
        public ActionResult Style()
        {
            string id = HttpContext.Session.GetString("companyid");

            MemoryStream stream = new MemoryStream();

            StringBuilder style = new StringBuilder();

            style.AppendLine(":root {");

            if (id == null)
            {
                style.AppendLine(string.Format("--primary-color: {0};", _configuration["CorPrimaria"]));
                style.AppendLine(string.Format("--secondary-color: {0};", _configuration["CorSecundaria"]));
                style.AppendLine(string.Format("--support-color: {0};", _configuration["CorSuporte"]));
                style.AppendLine(string.Format("--logo: Url('{0}');", _configuration["Logo"]));
            }
            else
            {
                StringContent content = new StringContent(JsonSerializer.Serialize(id), Encoding.UTF8, "application/json");

                HttpResponseMessage httpResponse = apiClient.PostAsync("/empresa/get", content).Result;

                var result = httpResponse.Content.ReadAsStringAsync().Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    Leega.Dtos.Empresa empresa = (Leega.Dtos.Empresa)JsonSerializer.Deserialize(result, typeof(Leega.Dtos.Empresa));

                    style.AppendLine(string.Format("--primary-color: {0};", empresa.corprincipal));
                    style.AppendLine(string.Format("--secondary-color: {0};", empresa.corsecundaria));
                    style.AppendLine(string.Format("--support-color: {0};", empresa.corsuporte));
                    style.AppendLine(string.Format("--logo: Url('{0}');", empresa.logo));
                }
            }

            style.AppendLine("}");

            StreamWriter writer = new StreamWriter(stream);
            writer.Write(style.ToString());
            writer.Flush();
            stream.Position = 0;

            return File(stream, "text/css");
        }
    }
}
