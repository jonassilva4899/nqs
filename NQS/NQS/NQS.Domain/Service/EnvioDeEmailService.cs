using Leega.Domain.Utils;
using Leega.Entity;
using Leega.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Leega.Entity.Entity;
using Amazon.S3.Model;
using Leega.Domain.Domain;

namespace Leega.Domain.Service
{
    public class EnvioDeEmailService
    {
        public async Task<bool> EnviaNotificacaoEmail(EmailNotificacaoViewModel dados)
        {
            var client = await ConfiguraEnvio();
            return true;
        }

        private async Task<SmtpClient> ConfiguraEnvio()
        {
            var client = new SmtpClient();
            client.Host = "email-ssl.com.br";
            client.EnableSsl = true;
            client.Port = 587;
            client.Credentials = new NetworkCredential("goobee@cadmus.com.br", "Goobee@Cadmus2020");
            return client;
        }

        private async Task<MailMessage> ConfiguraRemetenteDestinatario(string emailDestinatario, string assunto)
        {
            var mail = new MailMessage();
            mail.Sender = new MailAddress("goobee@cadmus.com.br", "Goobee Teams");
            mail.From = new MailAddress("goobee@cadmus.com.br", "Goobee Teams");
            mail.To.Add(new MailAddress(emailDestinatario));
            mail.Subject = assunto; //Assunto do E-mail
            return mail;
        }

        public async Task<RespostaEnvioEmail> EnvioConvite(Convite dados, string linkConvite)
        {
            var assunto = "Goobee Teams - Convite!";

            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(dados.Email, assunto);

            mail.Body = await MontarEmailConvite(dados, linkConvite); //Recebe Corpo do E-mail
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail); //Envia o E-mail!!!!! CAUTION!!!
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnvioRecuperarSenha(RecuperarSenha dados, string linkRecuperarSenha)
        {
            var assunto = "Goobee - Recuperar Senha!";

            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(dados.Pessoa.Email, assunto);

            mail.Body = await MontarEmailRecuperarSenha(dados, linkRecuperarSenha); ; //Recebe Corpo do E-mail
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail); //Envia o E-mail!!!!! CAUTION!!!
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnvioNotificacao(NotificacaoUsuario notificacaoUsuario, string nomePessoa)
        {
            var assunto = "Goobee - Nova notificação!";

            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(notificacaoUsuario.Usuario.Login, assunto);

            mail.Body = await MontarEmailNotificacao(notificacaoUsuario, nomePessoa); //Recebe Corpo do E-mail
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail); //Envia o E-mail!!!!! CAUTION!!!
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        //public async Task<RespostaEnvioEmail> EnvioNotificacaoEnps(string emailDestinatario, Guid idPessoa, string nomeOrganizacao, string nomeDestinatario, List<EnpsPesquisaPergunta> perguntas)
        //{
        //    var assunto = "Goobee - eNPS!";

        //    var client = await ConfiguraEnvio();
        //    var mail = await ConfiguraRemetenteDestinatario(emailDestinatario, assunto);

        //    mail.Body = await MontarEmailNotificacaoEnps(nomeDestinatario, nomeOrganizacao, idPessoa, perguntas); //Recebe Corpo do E-mail
        //    mail.IsBodyHtml = true;
        //    mail.Priority = MailPriority.High;

        //    try
        //    {
        //        client.Send(mail); //Envia o E-mail!!!!! CAUTION!!!
        //    }
        //    catch (Exception erro)
        //    {
        //        return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
        //    }

        //    return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        //}

        public async Task<RespostaEnvioEmail> EnvioNotificacaoAssessment(string emailDestinatario, string nomeOrganizacao, string nomeDestinatario, string nomeTime, string linkAssessment)
        {
            var assunto = "Goobee - Assessment!";

            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(emailDestinatario, assunto);

            mail.Body = await MontarEmailNotificacaoAssessment(linkAssessment, nomeDestinatario, nomeOrganizacao, nomeTime); //Recebe Corpo do E-mail
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail); //Envia o E-mail!!!!! CAUTION!!!
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnviarAvisoAntecedenciaDaily(Time time, Pessoa pessoa, double tempo)
        {
            var assunto = $"Goobee - {time.Nome}, daily em {tempo} minutos!";
            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(pessoa.Email, assunto);

            TemplateEmailPadraoViewModel template = new TemplateEmailPadraoViewModel()
            {
                Titulo1 = $"{time.Nome}, daily em {tempo} minutos!",
                Apresentacao = $"Olá {pessoa.Nome},",
                Descricao = $"Prepare-se para realizar a Daily junto do seu time! Não esqueça de registrar o evento no GoobeeTeams..."
            };

            mail.Body = await MontarEmailTemplatePadrao(template);
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail);
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnviarAvisoAntecedenciaRetro(Time time, Pessoa pessoa, DateTime horario)
        {
            var assunto = $"Goobee - {time.Nome} - Aviso de Retrospectiva!";
            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(pessoa.Email, assunto);

            TemplateEmailPadraoViewModel template = new TemplateEmailPadraoViewModel()
            {
                Titulo1 = $"{time.Nome}, amanhã temos retrospectiva às {horario.Hour}:{horario.Minute.ToString("00")}",
                Apresentacao = $"Olá {pessoa.Nome},",
                Descricao = $"Fique Atento! Amanhã temos retrospectiva agendada!"
            };

            //mail.Body = await MontarEmailTemplatePadrao(template);
            //mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.High;

            //try
            //{
            //    client.Send(mail);
            //}
            //catch (Exception erro)
            //{
            //    return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            //}

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnviarAvisoPosteriorRetro(Time time, Pessoa pessoa)
        {
            var assunto = $"Goobee - {time.Nome} - Aviso de Retrospectiva!";
            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(pessoa.Email, assunto);

            TemplateEmailPadraoViewModel template = new TemplateEmailPadraoViewModel()
            {
                Titulo1 = $"{time.Nome}, vocês não realizaram a Retrospectiva ontem.",
                Apresentacao = $"Olá {pessoa.Nome},",
                Descricao = $"Não houve registro dessa informação ontem. Converse com o seu time!"
            };

            mail.Body = await MontarEmailTemplatePadrao(template);
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail);
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnviarAvisoPosteriorDaily(Time time, Pessoa pessoa)
        {
            var assunto = $"Goobee - {time.Nome} - Daily não realizada!";
            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(pessoa.Email, assunto);

            TemplateEmailPadraoViewModel template = new TemplateEmailPadraoViewModel()
            {
                Titulo1 = $"{time.Nome}, vocês ainda não realizaram a daily hoje.",
                Apresentacao = $"Olá {pessoa.Nome},",
                Descricao = $"Não houve registro dessa informação no dia de hoje: {DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}"
            };

            mail.Body = await MontarEmailTemplatePadrao(template);
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail);
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnviarAvisoPosteriorPlanning(Time time, Pessoa pessoa)
        {
            var assunto = $"Goobee - {time.Nome} - Planning não realizada!";
            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(pessoa.Email, assunto);

            TemplateEmailPadraoViewModel template = new TemplateEmailPadraoViewModel()
            {
                Titulo1 = $"{time.Nome}, vocês não realizaram a Planning ontem.",
                Apresentacao = $"Olá {pessoa.Nome},",
                Descricao = $"Não houve registro dessa informação ontem. Converse com o seu time!"
            };

            //mail.Body = await MontarEmailTemplatePadrao(template);
            //mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.High;

            //try
            //{
            //    client.Send(mail);
            //}
            //catch (Exception erro)
            //{
            //    return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            //}

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnviarAvisoAntecedenciaPlanning(Time time, Pessoa pessoa, DateTime horario)
        {
            var assunto = $"Goobee - {time.Nome} - Aviso Planning!";
            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(pessoa.Email, assunto);

            TemplateEmailPadraoViewModel template = new TemplateEmailPadraoViewModel()
            {
                Titulo1 = $"{time.Nome}, amanhã temos planning às {horario.Hour}:{horario.Minute.ToString("00")}",
                Apresentacao = $"Olá {pessoa.Nome},",
                Descricao = $"Fique Atento! Amanhã temos planning agendada!"
            };

            mail.Body = await MontarEmailTemplatePadrao(template);
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail);
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnviarAvisoPosteriorReview(Time time, Pessoa pessoa)
        {
            var assunto = $"Goobee - {time.Nome} - Review não realizada!";
            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(pessoa.Email, assunto);

            TemplateEmailPadraoViewModel template = new TemplateEmailPadraoViewModel()
            {
                Titulo1 = $"{time.Nome}, vocês não realizaram a Review ontem.",
                Apresentacao = $"Olá {pessoa.Nome},",
                Descricao = $"Não houve registro dessa informação ontem. Converse com o seu time!"
            };

            mail.Body = await MontarEmailTemplatePadrao(template);
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail);
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnviarAvisoAntecedenciaReview(Time time, Pessoa pessoa, DateTime horario)
        {
            var assunto = $"Goobee - {time.Nome} - Aviso Review!";
            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(pessoa.Email, assunto);

            TemplateEmailPadraoViewModel template = new TemplateEmailPadraoViewModel()
            {
                Titulo1 = $"{time.Nome}, amanhã temos review às {horario.Hour}:{horario.Minute.ToString("00")}",
                Apresentacao = $"Olá {pessoa.Nome},",
                Descricao = $"Fique Atento! Amanhã temos review agendada!"
            };

            mail.Body = await MontarEmailTemplatePadrao(template);
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail);
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnvioNotificacaoDaily(NotificacaoUsuario notificacaoUsuario, Pessoa pessoaRemetente, string nomeTime)
        {
            var assunto = "Goobee - Daily!";
            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(notificacaoUsuario.Usuario.Login, assunto);

            mail.Body = await MontarEmailNotificacaoDaily(notificacaoUsuario, pessoaRemetente, nomeTime); //Recebe Corpo do E-mail
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail); //Envia o E-mail!!!!! CAUTION!!!
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnvioNotificacaoDicaAC(NotificacaoUsuario notificacaoUsuario, Pessoa pessoaRemetente, string nomeTime)
        {
            var assunto = "Goobee - Dicas Agile Coach!";
            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(notificacaoUsuario.Usuario.Login, assunto);

            mail.Body = await MontarEmailNotificacaoDicaAC(notificacaoUsuario, pessoaRemetente, nomeTime); //Recebe Corpo do E-mail
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail); //Envia o E-mail!!!!! CAUTION!!!
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        public async Task<RespostaEnvioEmail> EnvioNotificacaoMelhoriaContinua(NotificacaoUsuario notificacaoUsuario, Pessoa pessoaRemetente, string nomeTime)
        {
            var assunto = "Goobee - Melhoria Continua!";
            var client = await ConfiguraEnvio();
            var mail = await ConfiguraRemetenteDestinatario(notificacaoUsuario.Usuario.Login, assunto);

            mail.Body = await MontarEmailNotificacaoDicaAC(notificacaoUsuario, pessoaRemetente, nomeTime); //Recebe Corpo do E-mail
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            try
            {
                client.Send(mail); //Envia o E-mail!!!!! CAUTION!!!
            }
            catch (Exception erro)
            {
                return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
            }

            return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        }

        private async Task<string> MontarEmailTemplatePadrao(TemplateEmailPadraoViewModel templateEmail)
        {
            var corpoEmail = @"
                    <html>
                        <body style='padding:0; margin:0; background-color: #fff;' bgcolor='#000'>

                            <table border='0' cellpadding='0' cellspacing='0' style='margin: 0; padding: 0' width='100%'>
                                <tr>
                                    <td align='center' valign='top'>

                                        <table width='640' border='0' cellspacing='0' cellpadding='0' class='hide'>
                                            <tr>
                                                <td height='15'></td>
                                            </tr>
                                        </table>

                                        <table width='640' cellspacing='0' cellpadding='0' bgcolor='#' class='100p'>
                                            <tr>
                                                <td bgcolor='#fff' width='640' valign='top' class='100p'>
                                                    <div>
                                                        <table width='640' border='0' cellspacing='0' cellpadding='20' class='100p'>
                                                            <tr>
                                                                <td valign='top'>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <!-- cabecalho -->
                                                                        <tr>
                                                                            <td align='center' width='50%' class='100p'><img
                                                                                    src='http://69.64.36.38/mkt_goobeeteams/images/goobee_mkt_cabecalho.png'
                                                                                    style='width: 100%;' />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <tr>
                                                                            <td height='20'></td>
                                                                        </tr>
                                                                        <!-- texto -->
                                                                        <tr>
                                                                            <td align='left' style='color:#666; font-size:16px;'>
                                                                                <font face=''Roboto', Arial, sans-serif'>
                                                                                    <h1
                                                                                        style='font-size: 30px; text-align: center; color: #df7f19;'>
                                                                                        " + templateEmail.Titulo1 + @"</h1>
                                                                                    <p>" + templateEmail.Apresentacao + @"</p>
                                                                                    <p>
                                                                                        " + templateEmail.Descricao + @"<br />
                                                                                    </p>
                                                                                </font>
                                                                            </td>
                                                                        </tr>
                                                                        <br/>
                                                                        <br/>
                                                                        <br/>
                                                                        <tr>
                                                                            <td align='center' style='font-size:16px; color:#848484;'>
                                                                                <br>
                                                                                <font face=''Roboto', Arial, sans-serif'><span
                                                                                        style='color:#df7f19; font-size:24px;'>Atenciosamente,
                                                                                        Goobee Teams.</span></font>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>

                                                </td>
                                            </tr>
                                        </table>

                                        <table width='640' class='100p' border='0' cellspacing='0' cellpadding='0'>
                                            <tr>
                                                <td height='40'>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                        </body>
                    </html>";

            return corpoEmail;
        }

        private async Task<string> MontarEmailNotificacaoDaily(NotificacaoUsuario dados, Pessoa pessoaRemetente, string nomeTime)
        {
            var corpoEmail = @"
                    <html>
                        <body style='padding:0; margin:0; background-color: #fff;' bgcolor='#000'>

                            <table border='0' cellpadding='0' cellspacing='0' style='margin: 0; padding: 0' width='100%'>
                                <tr>
                                    <td align='center' valign='top'>

                                        <table width='640' border='0' cellspacing='0' cellpadding='0' class='hide'>
                                            <tr>
                                                <td height='15'></td>
                                            </tr>
                                        </table>

                                        <table width='640' cellspacing='0' cellpadding='0' bgcolor='#' class='100p'>
                                            <tr>
                                                <td bgcolor='#fff' width='640' valign='top' class='100p'>
                                                    <div>
                                                        <table width='640' border='0' cellspacing='0' cellpadding='20' class='100p'>
                                                            <tr>
                                                                <td valign='top'>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <!-- cabecalho -->
                                                                        <tr>
                                                                            <td align='center' width='50%' class='100p'><img
                                                                                    src='http://69.64.36.38/mkt_goobeeteams/images/goobee_mkt_cabecalho.png'
                                                                                    style='width: 100%;' />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <tr>
                                                                            <td height='20'></td>
                                                                        </tr>
                                                                        <!-- texto -->
                                                                        <tr>
                                                                            <td align='left' style='color:#666; font-size:16px;'>
                                                                                <font face=''Roboto', Arial, sans-serif'>
                                                                                    <h1
                                                                                        style='font-size: 30px; text-align: center; color: #df7f19;'>
                                                                                        Você recebeu uma notificação!</h1>
                                                                                    <p>Olá " + nomeTime + @",</p>
                                                                                    <p>
                                                                                        Vocês não tem realizado daily na última semana? Que tal conversar com o seu time e avaliar o que vocês podem fazer para corrigir isso? <br />
                                                                                        A Daily é o propulsor do nosso fluxo. Peça ajuda dos nossos Agile Coaches se precisar!
                                                                                    </p>
                                                                                </font>
                                                                            </td>
                                                                        </tr>
                                                                        <br/>
                                                                        <br/>
                                                                        <br/>
                                                                        <tr>
                                                                            <td align='center' style='font-size:16px; color:#848484;'>
                                                                                <br>
                                                                                <font face=''Roboto', Arial, sans-serif'><span
                                                                                        style='color:#df7f19; font-size:24px;'>Atenciosamente,
                                                                                        Goobee Teams.</span></font>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>

                                                </td>
                                            </tr>
                                        </table>

                                        <table width='640' class='100p' border='0' cellspacing='0' cellpadding='0'>
                                            <tr>
                                                <td height='40'>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                        </body>
                    </html>";

            return corpoEmail;
        }

        private async Task<string> MontarEmailNotificacaoDicaAC(NotificacaoUsuario dados, Pessoa pessoaRemetente, string nomeTime)
        {
            var corpoEmail = @"
                    <html>
                        <body style='padding:0; margin:0; background-color: #fff;' bgcolor='#000'>

                            <table border='0' cellpadding='0' cellspacing='0' style='margin: 0; padding: 0' width='100%'>
                                <tr>
                                    <td align='center' valign='top'>

                                        <table width='640' border='0' cellspacing='0' cellpadding='0' class='hide'>
                                            <tr>
                                                <td height='15'></td>
                                            </tr>
                                        </table>

                                        <table width='640' cellspacing='0' cellpadding='0' bgcolor='#' class='100p'>
                                            <tr>
                                                <td bgcolor='#fff' width='640' valign='top' class='100p'>
                                                    <div>
                                                        <table width='640' border='0' cellspacing='0' cellpadding='20' class='100p'>
                                                            <tr>
                                                                <td valign='top'>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <!-- cabecalho -->
                                                                        <tr>
                                                                            <td align='center' width='50%' class='100p'><img
                                                                                    src='http://69.64.36.38/mkt_goobeeteams/images/goobee_mkt_cabecalho.png'
                                                                                    style='width: 100%;' />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <tr>
                                                                            <td height='20'></td>
                                                                        </tr>
                                                                        <!-- texto -->
                                                                        <tr>
                                                                            <td align='left' style='color:#666; font-size:16px;'>
                                                                                <font face=''Roboto', Arial, sans-serif'>
                                                                                    <h1
                                                                                        style='font-size: 30px; text-align: center; color: #df7f19;'>
                                                                                        Você recebeu uma notificação!</h1>
                                                                                    <p>Olá " + nomeTime + @",</p>
                                                                                    <p>
                                                                                        Percebemos que vocês não tem analisado as dicas dos nossos coaches. Que tal conversar com o seu time e avaliar o que vocês podem fazer para melhorar isso? <br />
                                                                                        Aprendizado e Melhoria Contínua é a essência do ágil e de times de alta performance. As Dicas que vocês recebem podem fazer toda a diferença no dia a dia. Converse com seu gestor sobre isso, se precisar!
                                                                                    </p>
                                                                                </font>
                                                                            </td>
                                                                        </tr>
                                                                        <br/>
                                                                        <br/>
                                                                        <br/>
                                                                        <tr>
                                                                            <td align='center' style='font-size:16px; color:#848484;'>
                                                                                <br>
                                                                                <font face=''Roboto', Arial, sans-serif'><span
                                                                                        style='color:#df7f19; font-size:24px;'>Atenciosamente,
                                                                                        Goobee Teams.</span></font>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>

                                                </td>
                                            </tr>
                                        </table>

                                        <table width='640' class='100p' border='0' cellspacing='0' cellpadding='0'>
                                            <tr>
                                                <td height='40'>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                        </body>
                    </html>";

            return corpoEmail;
        }

        //public async Task<RespostaEnvioEmail> EnvioNotificacaoKudoCard(NotificacaoUsuario notificacaoUsuario, EnviarKudoCardViewModel kudoInfos, Pessoa pessoaRemetente, string nomePessoa)
        //{
        //    var assunto = "Goobee - Kudo Card!";
        //    var client = await ConfiguraEnvio();
        //    var mail = await ConfiguraRemetenteDestinatario(notificacaoUsuario.Usuario.Login, assunto);

        //    string kudoCardPath = "";
        //    switch (kudoInfos.TipoKudoCard)
        //    {
        //        case TipoKudoCardEnum.ObrigadoPelaForca:
        //            kudoCardPath = "https://apiteams.goobee.com.br/api/AwsS3?nomeArquivo=kudocard_obrigado-pela-forca.svg";
        //            break;

        //        case TipoKudoCardEnum.ParabensMestre:
        //            kudoCardPath = "https://apiteams.goobee.com.br/api/AwsS3?nomeArquivo=kudocard_parabens-mestre.svg";
        //            break;

        //        case TipoKudoCardEnum.QueMaravilha:
        //            kudoCardPath = "https://apiteams.goobee.com.br/api/AwsS3?nomeArquivo=kudocard_que-maravilha.svg";
        //            break;

        //        case TipoKudoCardEnum.QueTrabalhoIncrivel:
        //            kudoCardPath = "https://apiteams.goobee.com.br/api/AwsS3?nomeArquivo=kudocard_que-trabalho-incrivel.svg";
        //            break;

        //        case TipoKudoCardEnum.VoceEImbativel:
        //            kudoCardPath = "https://apiteams.goobee.com.br/api/AwsS3?nomeArquivo=kudocard_voce-e-imbativel.svg";
        //            break;

        //        case TipoKudoCardEnum.SuperTrabalho:
        //            kudoCardPath = "https://apiteams.goobee.com.br/api/AwsS3?nomeArquivo=kudocard_super-trabalho.svg";
        //            break;

        //        case TipoKudoCardEnum.TimePoderoso:
        //            kudoCardPath = "https://apiteams.goobee.com.br/api/AwsS3?nomeArquivo=kudocard_time-poderoso.svg";
        //            break;
        //    }

        //    mail.Body = await MontarEmailNotificacaoKudoKard(notificacaoUsuario, nomePessoa, kudoCardPath, kudoInfos, pessoaRemetente); //Recebe Corpo do E-mail
        //    mail.IsBodyHtml = true;
        //    mail.Priority = MailPriority.High;

        //    try
        //    {
        //        client.Send(mail); //Envia o E-mail!!!!! CAUTION!!!
        //    }
        //    catch (Exception erro)
        //    {
        //        return new RespostaEnvioEmail { Resposta = false, Mensagem = erro.Message };
        //    }

        //    return new RespostaEnvioEmail { Resposta = true, Mensagem = "E-mail enviado com sucesso!" };
        //}

        public async Task<string> GerarLink(Guid idConviteHistorico, string token, string rota)
        {
            string resultado = string.Format("{0}{1}/{2}/{3}",
                "https://teams.goobee.com.br/",
                rota,
                Base64.Encode(idConviteHistorico.ToString(), true),
                Base64.Encode(token, true));
            return resultado;
        }

        public async Task<string> GerarLinkAssessment(Guid idPesquisa, Guid idPessoa, string rota)
        {
            string resultado = string.Format("{0}{1}/{2}/{3}",
                "https://teams.goobee.com.br/",
                rota,
                idPesquisa.ToString(),
                idPessoa.ToString());
            return resultado;
        }

        public async Task<string> MontarEmailConvite(Convite dados, string linkConvite)
        {
            var corpoEmail = @"
                    <html>
                        <body style='padding:0; margin:0; background-color: #fff;' bgcolor='#000'>

                            <table border='0' cellpadding='0' cellspacing='0' style='margin: 0; padding: 0' width='100%'>
                                <tr>
                                    <td align='center' valign='top'>

                                        <table width='640' border='0' cellspacing='0' cellpadding='0' class='hide'>
                                            <tr>
                                                <td height='15'></td>
                                            </tr>
                                        </table>

                                        <table width='640' cellspacing='0' cellpadding='0' bgcolor='#' class='100p'>
                                            <tr>
                                                <td bgcolor='#fff' width='640' valign='top' class='100p'>
                                                    <div>
                                                        <table width='640' border='0' cellspacing='0' cellpadding='20' class='100p'>
                                                            <tr>
                                                                <td valign='top'>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <!-- cabecalho -->
                                                                        <tr>
                                                                            <td align='center' width='50%' class='100p'><img
                                                                                    src='http://69.64.36.38/mkt_goobeeteams/images/goobee_mkt_cabecalho.png'
                                                                                    style='width: 100%;' />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <tr>
                                                                            <td height='20'></td>
                                                                        </tr>
                                                                        <!-- texto -->
                                                                        <tr>
                                                                            <td align='left' style='color:#666; font-size:16px;'>
                                                                                <font face=''Roboto', Arial, sans-serif'>
                                                                                    <h1
                                                                                        style='font-size: 30px; text-align: center; color: #df7f19;'>
                                                                                        Entre para o Goobee Teams!</h1>
                                                                                    <p>Olá " + dados.Nome + @",</p>
                                                                                    <p>
                                                                                        Você foi convidado para entrar no Goobee Teams!
                                                                                        <br>
                                                                                    </p>
                                                                                    <p>
                                                                                        Para começar é bem simples:
                                                                                        <ul>
                                                                                            <li><a href='" + linkConvite + @"'
                                                                                                    style='color:#df7f19; font-weight: bold; text-decoration:none;'>Acesse
                                                                                                    a plataforma.</a></li>
                                                                                            <li>Cadastre sua nova senha.</li>
                                                                                        </ul>
                                                                                    </p>
                                                                                    <!-- ilustracao -->
                                                                                    </br>
                                                                                    <p style='text-align: center;'>
                                                                                        <img src='http://69.64.36.38/mkt_goobeeteams/images/ilustracao_cadastro.png'
                                                                                            style='width: 400px; max-width: 100%;' />
                                                                                    </p>
                                                                                    <!-- lembrete -->
                                                                                    <p
                                                                                        style='font-weight: bold; font-size: 12px; text-align: center;'>
                                                                                        Lembre-se, é
                                                                                        importante que
                                                                                        você preencha os dados do seu perfil.</p>
                                                                                </font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align='center' style='font-size:16px; color:#848484;'>
                                                                                <br>
                                                                                <font face=''Roboto', Arial, sans-serif'><span
                                                                                        style='color:#df7f19; font-size:24px;'>Atenciosamente,
                                                                                        Goobee Teams.</span></font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height='30'></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>

                                                </td>
                                            </tr>
                                        </table>

                                        <table width='640' class='100p' border='0' cellspacing='0' cellpadding='0'>
                                            <tr>
                                                <td height='40'>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                        </body>
                    </html>";

            return corpoEmail;
        }

        public async Task<string> MontarEmailRecuperarSenha(RecuperarSenha dados, string linkRecuperarSenha)
        {
            var corpoEmail = @"
                    <html>
                        <body style='padding:0; margin:0; background-color: #fff;' bgcolor='#000'>

                            <table border='0' cellpadding='0' cellspacing='0' style='margin: 0; padding: 0' width='100%'>
                                <tr>
                                    <td align='center' valign='top'>

                                        <table width='640' border='0' cellspacing='0' cellpadding='0' class='hide'>
                                            <tr>
                                                <td height='15'></td>
                                            </tr>
                                        </table>

                                        <table width='640' cellspacing='0' cellpadding='0' bgcolor='#' class='100p'>
                                            <tr>
                                                <td bgcolor='#fff' width='640' valign='top' class='100p'>
                                                    <div>
                                                        <table width='640' border='0' cellspacing='0' cellpadding='20' class='100p'>
                                                            <tr>
                                                                <td valign='top'>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <!-- cabecalho -->
                                                                        <tr>
                                                                            <td align='center' width='50%' class='100p'><img
                                                                                    src='http://69.64.36.38/mkt_goobeeteams/images/goobee_mkt_cabecalho.png'
                                                                                    style='width: 100%;' />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <tr>
                                                                            <td height='20'></td>
                                                                        </tr>
                                                                        <!-- texto -->
                                                                        <tr>
                                                                            <td align='left' style='color:#666; font-size:16px;'>
                                                                                <font face=''Roboto', Arial, sans-serif'>
                                                                                    <h1
                                                                                        style='font-size: 30px; text-align: center; color: #df7f19;'>
                                                                                        Recuperação de senha</h1>
                                                                                    <p>Olá " + dados.Pessoa.Nome + @",</p>
                                                                                    <p>
                                                                                        Segue link para alteração de sua senha:
                                                                                        <ul>
                                                                                            <li><a href='" + linkRecuperarSenha + @"'
                                                                                                    style='color:#df7f19; font-weight: bold; text-decoration:none;'>Acesse
                                                                                                    a plataforma.</a></li>
                                                                                            <li>Cadastre sua nova senha.</li>
                                                                                        </ul>
                                                                                    </p>                                                            
                                                                                </font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align='center' style='font-size:16px; color:#848484;'>
                                                                                <br>
                                                                                <font face=''Roboto', Arial, sans-serif'><span
                                                                                        style='color:#df7f19; font-size:24px;'>Atenciosamente,
                                                                                        Goobee Teams.</span></font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height='30'></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>

                                                </td>
                                            </tr>
                                        </table>

                                        <table width='640' class='100p' border='0' cellspacing='0' cellpadding='0'>
                                            <tr>
                                                <td height='40'>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                        </body>
                    </html>";

            return corpoEmail;
        }

        public async Task<string> MontarEmailNotificacao(NotificacaoUsuario dados, string nomePessoa)
        {
            var corpoEmail = @"
                    <html>
                        <body style='padding:0; margin:0; background-color: #fff;' bgcolor='#000'>

                            <table border='0' cellpadding='0' cellspacing='0' style='margin: 0; padding: 0' width='100%'>
                                <tr>
                                    <td align='center' valign='top'>

                                        <table width='640' border='0' cellspacing='0' cellpadding='0' class='hide'>
                                            <tr>
                                                <td height='15'></td>
                                            </tr>
                                        </table>

                                        <table width='640' cellspacing='0' cellpadding='0' bgcolor='#' class='100p'>
                                            <tr>
                                                <td bgcolor='#fff' width='640' valign='top' class='100p'>
                                                    <div>
                                                        <table width='640' border='0' cellspacing='0' cellpadding='20' class='100p'>
                                                            <tr>
                                                                <td valign='top'>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <!-- cabecalho -->
                                                                        <tr>
                                                                            <td align='center' width='50%' class='100p'><img
                                                                                    src='http://69.64.36.38/mkt_goobeeteams/images/goobee_mkt_cabecalho.png'
                                                                                    style='width: 100%;' />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <tr>
                                                                            <td height='20'></td>
                                                                        </tr>
                                                                        <!-- texto -->
                                                                        <tr>
                                                                            <td align='left' style='color:#666; font-size:16px;'>
                                                                                <font face=''Roboto', Arial, sans-serif'>
                                                                                    <h1
                                                                                        style='font-size: 30px; text-align: center; color: #df7f19;'>
                                                                                        Você recebeu uma notificação!</h1>
                                                                                    <p>Olá " + nomePessoa + @",</p>
                                                                                    <p>
                                                                                        Você recebeu uma notificação:
                                                                                        <br></br>
                                                                                        <span><em>" + "\"" + dados.Notificacao.Mensagem + ".\"" + @"</em></span>
                                                                                    </p>
                                                                                </font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align='center' style='font-size:16px; color:#848484;'>
                                                                                <br>
                                                                                <font face=''Roboto', Arial, sans-serif'><span
                                                                                        style='color:#df7f19; font-size:24px;'>Atenciosamente,
                                                                                        Goobee Teams.</span></font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height='30'></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>

                                                </td>
                                            </tr>
                                        </table>

                                        <table width='640' class='100p' border='0' cellspacing='0' cellpadding='0'>
                                            <tr>
                                                <td height='40'>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                        </body>
                    </html>";

            return corpoEmail;
        }

        //public async Task<string> MontarEmailNotificacaoEnps(string nomePessoa, string nomeOrganizacao, Guid idPessoa, List<EnpsPesquisaPergunta> pesquisaPerguntas)
        //{
        //    var dictParams = new Dictionary<string, string>();
        //    dictParams.Add("[[NomeOrganizacao]]", nomeOrganizacao);

        //    List<PerguntaEnpsEmailViewModel> perguntasEnps = pesquisaPerguntas.Select(x => new PerguntaEnpsEmailViewModel()
        //    {
        //        IdPesquisaPergunta = x.Id,
        //        Texto = x.Pergunta.Texto,
        //        IdOrganizacao = x.Pesquisa.IdOrganizacao
        //    }).ToList();

        //    perguntasEnps.Select(x =>
        //    {
        //        x.Texto =
        //            dictParams.Aggregate(x.Texto, (result, s) => result.Replace(s.Key, s.Value));
        //        return x;
        //    }).ToList();

        //    var possiveisRespostas = new List<int>();
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        possiveisRespostas.Add(i);
        //    }

        //    var corpo = "<br></br>";

        //    foreach (var pergunta in perguntasEnps)
        //    {
        //        corpo += $"{pergunta.Texto}" +
        //                 "<table style = 'color:#666; font-size:16px; width: 100%' >" +
        //                 "<tr>";
        //        foreach (var resposta in possiveisRespostas)
        //        {
        //            var baseUrl = "https://apiteams.goobee.com.br/";
        //            var url = baseUrl + $"api/Enps/Responder?idPesquisaPergunta={pergunta.IdPesquisaPergunta}&idPessoa={idPessoa}&resposta={resposta}&idOrganizacao={pergunta.IdOrganizacao}";
        //            corpo +=
        //                "<td style = 'border: 1px solid black; padding: 5px; text-align: center; cursor: pointer'>" +
        //                $"<a href = '{url}' style = 'text-decoration: none;'> {resposta.ToString()}";
        //        }
        //        corpo += "</tr>" +
        //                 "</table>";
        //    }

        //    corpo += "</tr>" +
        //                "</table>";

        //    var corpoEmail = @"
        //            <html>
        //                <body style='padding:0; margin:0; background-color: #fff;' bgcolor='#000'>

        //                    <table border='0' cellpadding='0' cellspacing='0' style='margin: 0; padding: 0' width='100%'>
        //                        <tr>
        //                            <td align='center' valign='top'>

        //                                <table width='640' border='0' cellspacing='0' cellpadding='0' class='hide'>
        //                                    <tr>
        //                                        <td height='15'></td>
        //                                    </tr>
        //                                </table>

        //                                <table width='640' cellspacing='0' cellpadding='0' bgcolor='#' class='100p'>
        //                                    <tr>
        //                                        <td bgcolor='#fff' width='640' valign='top' class='100p'>
        //                                            <div>
        //                                                <table width='640' border='0' cellspacing='0' cellpadding='20' class='100p'>
        //                                                    <tr>
        //                                                        <td valign='top'>
        //                                                            <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
        //                                                                <!-- cabecalho -->
        //                                                                <tr>
        //                                                                    <td align='center' width='50%' class='100p'><img
        //                                                                            src='http://69.64.36.38/mkt_goobeeteams/images/goobee_mkt_cabecalho.png'
        //                                                                            style='width: 100%;' />
        //                                                                    </td>
        //                                                                </tr>
        //                                                            </table>
        //                                                            <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
        //                                                                <tr>
        //                                                                    <td height='20'></td>
        //                                                                </tr>
        //                                                                <!-- texto -->
        //                                                                <tr>
        //                                                                    <td align='left' style='color:#666; font-size:16px;'>
        //                                                                        <font face=''Roboto', Arial, sans-serif'>
        //                                                                            <h1
        //                                                                                style='font-size: 30px; text-align: center; color: #df7f19;'>
        //                                                                                Você recebeu uma notificação!</h1>
        //                                                                            <p>Olá " + nomePessoa + @", sua opinião é muito importante para continuarmos a criar o melhor ambiente possível para todos.
        //                                                                            Essa pesquisa é parte do índice eNPS usado globalmente. Por favor, seja honesto na sua resposta para que possamos melhorar sempre.
        //                                                                            </p> 
        //                                                                            <p>
        //                                                                                " + corpo + @"
        //                                                                            </p>
        //                                                                        </font>
        //                                                                    </td>
        //                                                                </tr>
        //                                                                <tr>
        //                                                                    <td align='center' style='font-size:16px; color:#848484;'>
        //                                                                        <br>
        //                                                                        <font face=''Roboto', Arial, sans-serif'><span
        //                                                                                style='color:#df7f19; font-size:24px;'>Atenciosamente,
        //                                                                                Goobee Teams.</span></font>
        //                                                                    </td>
        //                                                                </tr>
        //                                                                <tr>
        //                                                                    <td height='30'></td>
        //                                                                </tr>
        //                                                            </table>
        //                                                        </td>
        //                                                    </tr>
        //                                                </table>
        //                                            </div>

        //                                        </td>
        //                                    </tr>
        //                                </table>

        //                                <table width='640' class='100p' border='0' cellspacing='0' cellpadding='0'>
        //                                    <tr>
        //                                        <td height='40'>

        //                                        </td>
        //                                    </tr>
        //                                </table>
        //                            </td>
        //                        </tr>
        //                    </table>

        //                </body>
        //            </html>";

        //    return corpoEmail;
        //}

        public async Task<string> MontarEmailNotificacaoAssessment(string linkAssessment, string nomePessoa, string nomeOrganizacao, string nomeTime)
        {
            var corpoEmail = @"
                    <html>
                        <body style='padding:0; margin:0; background-color: #fff;' bgcolor='#000'>

                            <table border='0' cellpadding='0' cellspacing='0' style='margin: 0; padding: 0' width='100%'>
                                <tr>
                                    <td align='center' valign='top'>

                                        <table width='640' border='0' cellspacing='0' cellpadding='0' class='hide'>
                                            <tr>
                                                <td height='15'></td>
                                            </tr>
                                        </table>

                                        <table width='640' cellspacing='0' cellpadding='0' bgcolor='#' class='100p'>
                                            <tr>
                                                <td bgcolor='#fff' width='640' valign='top' class='100p'>
                                                    <div>
                                                        <table width='640' border='0' cellspacing='0' cellpadding='20' class='100p'>
                                                            <tr>
                                                                <td valign='top'>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <!-- cabecalho -->
                                                                        <tr>
                                                                            <td align='center' width='50%' class='100p'><img
                                                                                    src='http://69.64.36.38/mkt_goobeeteams/images/goobee_mkt_cabecalho.png'
                                                                                    style='width: 100%;' />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
                                                                        <tr>
                                                                            <td height='20'></td>
                                                                        </tr>
                                                                        <!-- texto -->
                                                                        <tr>
                                                                            <td align='left' style='color:#666; font-size:16px;'>
                                                                                <font face=''Roboto', Arial, sans-serif'>
                                                                                    <h1
                                                                                        style='font-size: 30px; text-align: center; color: #df7f19;'>
                                                                                        Você recebeu uma notificação!</h1>
                                                                                    <p>Olá " + nomePessoa + @",</p>
                                                                                    <p>
                                                                                        Você recebeu um link para responder as questões do Assessment do time " + nomeTime + " da organização " + nomeOrganizacao + @":
                                                                                        <br></br>
                                                                                        <a href='" + linkAssessment + @"'><span>Acesse aqui</span></a>
                                                                                    </p>
                                                                                </font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align='center' style='font-size:16px; color:#848484;'>
                                                                                <br>
                                                                                <font face=''Roboto', Arial, sans-serif'><span
                                                                                        style='color:#df7f19; font-size:24px;'>Atenciosamente,
                                                                                        Goobee Teams.</span></font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height='30'></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>

                                                </td>
                                            </tr>
                                        </table>

                                        <table width='640' class='100p' border='0' cellspacing='0' cellpadding='0'>
                                            <tr>
                                                <td height='40'>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                        </body>
                    </html>";

            return corpoEmail;
        }

        //public async Task<string> MontarEmailNotificacaoKudoKard(NotificacaoUsuario dados, string nomePessoa, string kudoCardPath, EnviarKudoCardViewModel kudoInfos, Pessoa pessoaRemetente)
        //{
        //    var corpoEmail = @"
        //            <html>
        //                <body style='padding:0; margin:0; background-color: #fff;' bgcolor='#000'>

        //                    <table border='0' cellpadding='0' cellspacing='0' style='margin: 0; padding: 0' width='100%'>
        //                        <tr>
        //                            <td align='center' valign='top'>

        //                                <table width='640' border='0' cellspacing='0' cellpadding='0' class='hide'>
        //                                    <tr>
        //                                        <td height='15'></td>
        //                                    </tr>
        //                                </table>

        //                                <table width='640' cellspacing='0' cellpadding='0' bgcolor='#' class='100p'>
        //                                    <tr>
        //                                        <td bgcolor='#fff' width='640' valign='top' class='100p'>
        //                                            <div>
        //                                                <table width='640' border='0' cellspacing='0' cellpadding='20' class='100p'>
        //                                                    <tr>
        //                                                        <td valign='top'>
        //                                                            <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
        //                                                                <!-- cabecalho -->
        //                                                                <tr>
        //                                                                    <td align='center' width='50%' class='100p'><img
        //                                                                            src='http://69.64.36.38/mkt_goobeeteams/images/goobee_mkt_cabecalho.png'
        //                                                                            style='width: 100%;' />
        //                                                                    </td>
        //                                                                </tr>
        //                                                            </table>
        //                                                            <table border='0' cellspacing='0' cellpadding='0' width='600' class='100p'>
        //                                                                <tr>
        //                                                                    <td height='20'></td>
        //                                                                </tr>
        //                                                                <!-- texto -->
        //                                                                <tr>
        //                                                                    <td align='left' style='color:#666; font-size:16px;'>
        //                                                                        <font face=''Roboto', Arial, sans-serif'>
        //                                                                            <h1
        //                                                                                style='font-size: 30px; text-align: center; color: #df7f19;'>
        //                                                                                Você recebeu um KudoCard!</h1>
        //                                                                            <p>Olá " + nomePessoa + @",</p>
        //                                                                            <p>
        //                                                                                Você recebeu um KudoCard de " + pessoaRemetente.Nome + @":
        //                                                                                <br></br>
        //                                                                                <span><em>" + "\"" + kudoInfos.Mensagem + ".\"" + @"</em></span>
        //                                                                            </p>
        //                                                                        </font>
        //                                                                    </td>
        //                                                                </tr>
        //                                                                <br/>
        //                                                                <br/>
        //                                                                <br/>
        //                                                                <tr>
        //                                                                    <p style='text-align: center;'>
        //                                                                                <img src='" + kudoCardPath + @"'
        //                                                                                    style='width: 400px; max-width: 100%;' />
        //                                                                    </p>
        //                                                                </tr>
        //                                                                <tr>
        //                                                                    <td align='center' style='font-size:16px; color:#848484;'>
        //                                                                        <br>
        //                                                                        <font face=''Roboto', Arial, sans-serif'><span
        //                                                                                style='color:#df7f19; font-size:24px;'>Atenciosamente,
        //                                                                                Goobee Teams.</span></font>
        //                                                                    </td>
        //                                                                </tr>
        //                                                            </table>
        //                                                        </td>
        //                                                    </tr>
        //                                                </table>
        //                                            </div>

        //                                        </td>
        //                                    </tr>
        //                                </table>

        //                                <table width='640' class='100p' border='0' cellspacing='0' cellpadding='0'>
        //                                    <tr>
        //                                        <td height='40'>

        //                                        </td>
        //                                    </tr>
        //                                </table>
        //                            </td>
        //                        </tr>
        //                    </table>

        //                </body>
        //            </html>";

        //    return corpoEmail;
        //}
    }
}
