//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Leega.Domain;
//using Leega.Domain.Service;
//using Leega.Entity;
//using Microsoft.AspNetCore.Mvc;
//using Hangfire;
//using Leega.Entity.Enums;

//namespace Leega.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class JobsController : ControllerBase
//    {
//        private JobsService _jobsService;
//        private readonly TimeService<TimeViewModel, Time> _timeService;
//        private readonly TimeZoneInfo hrBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

//        public JobsController(JobsService jobsService, TimeService<TimeViewModel, Time> timeService)
//        {
//            _jobsService = jobsService;
//            _timeService = timeService;
//        }

//        [HttpGet("VerificaDailies")]
//        public async Task VerificaDailies()
//        {
//            try
//            {
//                var dailies = await _jobsService.BuscarTimesComDailiesPendentes();
//                dailies = dailies.Where(x => x.PorcentagemDailies < 70).ToList();
//                foreach (var dailyTime in dailies)
//                {
//                    if (dailyTime.PessoasTime.Any())
//                        await _jobsService.EnviarNotificacaoEmail(dailyTime.IdTime, dailyTime.PessoasTime);
//                }
//            }
//            catch (Exception e)
//            {
//                return;
//            }
//        }

//        [HttpGet("VerificaDicasAgileCoach")]
//        public async Task VerificaDicasAgileCoach()
//        {
//            try
//            {
//                var times = await _jobsService.BuscarTimesComDicasAgileCoach();
//                times = times.Where(x => x.PontosTemperatura < 5).ToList();
//                foreach (var time in times)
//                {
//                    if (time.PessoasTime.Any())
//                        await _jobsService.EnviarNotificacaoEmailDicasAC(time.IdTime, time.PessoasTime);
//                }
//            }
//            catch (Exception e)
//            {
//                return;
//            }
//        }

//        [HttpGet("VerificaDicasMelhoriaContinua")]
//        public async Task VerificaDicasMelhoriaContinua()
//        {
//            try
//            {
//                var times = await _jobsService.BuscarTimesComMelhoriaContinua();
//                times = times.Where(x => x.PontosTemperatura < 5).ToList();
//                foreach (var time in times)
//                {
//                    if (time.PessoasTime.Any())
//                        await _jobsService.EnviarNotificacaoEmailMelhoriaContinua(time.IdTime, time.PessoasTime);
//                }
//            }
//            catch (Exception e)
//            {
//                return;
//            }
//        }

//        [HttpGet("ConfiguraAvisoDeDailies")]
//        public void ConfiguraAvisoDeDailies()
//        {
//            var configDailies = _jobsService.BuscarDailiesConfigs();

//            try
//            {
//                foreach (var config in configDailies)
//                {
//                    var horarioDaily = Convert.ToDateTime(config.Time.DailyConfiguracao.HorarioDaily);
//                    var avisoAntecedencia = TimeSpan.Parse(config.AntecedenciaMin);
//                    var horarioDailyAntecedencia = horarioDaily.AddMinutes(-avisoAntecedencia.TotalMinutes);
//                    RecurringJob.AddOrUpdate<JobsController>(string.Concat("Daily - ", config.Time.Id), y => y.NotificacaoDaily(config.Id, AgendamentoNotificacaoEnum.Antecedencia, avisoAntecedencia.TotalMinutes), Cron.Daily(horarioDailyAntecedencia.Hour, horarioDailyAntecedencia.Minute), hrBrasilia);

//                    var avisoPosterior = TimeSpan.Parse(config.PosterioridadeMin);
//                    var horarioDailyPosterior = horarioDaily.AddMinutes(avisoPosterior.TotalMinutes);
//                    RecurringJob.AddOrUpdate<JobsController>(string.Concat("Daily - ", config.Time.Id, " Posterior"), y => y.NotificacaoDaily(config.Id, AgendamentoNotificacaoEnum.Posterioridade, 0), Cron.Daily(horarioDailyPosterior.Hour, horarioDailyPosterior.Minute), hrBrasilia);
//                }
//            }
//            catch (Exception error)
//            {
//                return;
//            }
//        }

//        [HttpGet("ConfiguraAvisoDeRetrospectivas")]
//        public void ConfiguraAvisoDeRetrospectivas()
//        {
//            var configRetro = _jobsService.BuscarRetroConfigs();

//            try
//            {
//                foreach (var config in configRetro)
//                {
//                    DateTime proximaData;

//                    if (config.Time.RetrospectivaConfiguracao.DataPrecursora < DateTime.Now)
//                    {
//                        proximaData = config.Time.RetrospectivaConfiguracao.ProximaData.Value;
//                    }
//                    else
//                    {
//                        proximaData = config.Time.RetrospectivaConfiguracao.DataPrecursora;
//                    }

//                    DateTime horarioRetro = Convert.ToDateTime(config.Time.RetrospectivaConfiguracao.HorarioRetrospectiva);
//                    TimeSpan avisoAntecedencia = TimeSpan.Parse(config.AntecedenciaMin);
//                    DateTime dataAvisoPrevio = proximaData.Subtract(avisoAntecedencia);
//                    TimeSpan avisoPosterioridade = TimeSpan.Parse(config.PosterioridadeMin);
//                    DateTime dataAvisoPosterior = proximaData.AddMinutes(avisoPosterioridade.TotalMinutes);

//                    if (horarioRetro.Hour < 14 || horarioRetro.Hour > 18)
//                    {
//                        horarioRetro = horarioRetro.AddHours(14 - horarioRetro.Hour);
//                    }

//                    switch (config.Time.RetrospectivaConfiguracao.Periodicidade)
//                    {
//                        case PeriodicidadeEnum.Semanalmente:
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Retrospectiva - ", config.Time.Id), y => y.NotificacaoRetro(config.Id, AgendamentoNotificacaoEnum.Antecedencia, horarioRetro, DateTime.Now), Cron.Monthly(dataAvisoPrevio.Day, horarioRetro.Hour, horarioRetro.Minute), hrBrasilia);
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Retrospectiva - ", config.Time.Id + " Posterior"), y => y.NotificacaoRetro(config.Id, AgendamentoNotificacaoEnum.Posterioridade, horarioRetro, proximaData), Cron.Monthly(dataAvisoPosterior.Day, horarioRetro.Hour, horarioRetro.Minute), hrBrasilia);
//                            break;

//                        case PeriodicidadeEnum.Quinzenalmente:
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Retrospectiva - ", config.Time.Id), y => y.NotificacaoRetro(config.Id, AgendamentoNotificacaoEnum.Antecedencia, horarioRetro, DateTime.Now), Cron.Monthly(dataAvisoPrevio.Day, horarioRetro.Hour, horarioRetro.Minute), hrBrasilia);
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Retrospectiva - ", config.Time.Id + " Posterior"), y => y.NotificacaoRetro(config.Id, AgendamentoNotificacaoEnum.Posterioridade, horarioRetro, proximaData), Cron.Monthly(dataAvisoPosterior.Day, horarioRetro.Hour, horarioRetro.Minute), hrBrasilia);
//                            break;

//                        case PeriodicidadeEnum.Mensalmente:
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Retrospectiva - ", config.Time.Id), y => y.NotificacaoRetro(config.Id, AgendamentoNotificacaoEnum.Antecedencia, horarioRetro, DateTime.Now), Cron.Monthly(dataAvisoPrevio.Day, horarioRetro.Hour, horarioRetro.Minute), hrBrasilia);
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Retrospectiva - ", config.Time.Id + " Posterior"), y => y.NotificacaoRetro(config.Id, AgendamentoNotificacaoEnum.Posterioridade, horarioRetro, proximaData), Cron.Monthly(dataAvisoPosterior.Day, horarioRetro.Hour, horarioRetro.Minute), hrBrasilia);
//                            break;
//                    }
//                }
//            }
//            catch (Exception error)
//            {
//                return;
//            }
//        }

//        [HttpGet("ConfiguraAvisoDePlanning")]
//        public void ConfiguraAvisoDePlanning()
//        {
//            var configPlanning = _jobsService.BuscarPlanningConfigs();

//            try
//            {
//                foreach (var config in configPlanning)
//                {
//                    DateTime proximaData;

//                    if (config.Time.PlanningConfiguracao.DataPrecursora < DateTime.Now)
//                    {
//                        proximaData = config.Time.PlanningConfiguracao.ProximaData.Value;
//                    }
//                    else
//                    {
//                        proximaData = config.Time.PlanningConfiguracao.DataPrecursora;
//                    }

//                    DateTime horarioPlanning = Convert.ToDateTime(config.Time.PlanningConfiguracao.HorarioPlanning);
//                    TimeSpan avisoAntecedencia = TimeSpan.Parse(config.AntecedenciaMin);
//                    DateTime dataAvisoPrevio = proximaData.Subtract(avisoAntecedencia);
//                    TimeSpan avisoPosterioridade = TimeSpan.Parse(config.PosterioridadeMin);
//                    DateTime dataAvisoPosterior = proximaData.AddMinutes(avisoPosterioridade.TotalMinutes);

//                    if (horarioPlanning.Hour < 14 || horarioPlanning.Hour > 18)
//                    {
//                        horarioPlanning = horarioPlanning.AddHours(14 - horarioPlanning.Hour);
//                    }

//                    switch (config.Time.PlanningConfiguracao.Periodicidade)
//                    {
//                        case PeriodicidadeEnum.Semanalmente:
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Planning - ", config.Time.Id), y => y.NotificacaoPlanning(config.Id, AgendamentoNotificacaoEnum.Antecedencia, horarioPlanning, DateTime.Now), Cron.Monthly(dataAvisoPrevio.Day, horarioPlanning.Hour, horarioPlanning.Minute), hrBrasilia);
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Planning - ", config.Time.Id + " Posterior"), y => y.NotificacaoPlanning(config.Id, AgendamentoNotificacaoEnum.Posterioridade, horarioPlanning, proximaData), Cron.Monthly(dataAvisoPosterior.Day, horarioPlanning.Hour, horarioPlanning.Minute), hrBrasilia);
//                            break;

//                        case PeriodicidadeEnum.Quinzenalmente:
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Planning - ", config.Time.Id), y => y.NotificacaoPlanning(config.Id, AgendamentoNotificacaoEnum.Antecedencia, horarioPlanning, DateTime.Now), Cron.Monthly(dataAvisoPrevio.Day, horarioPlanning.Hour, horarioPlanning.Minute), hrBrasilia);
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Planning - ", config.Time.Id + " Posterior"), y => y.NotificacaoPlanning(config.Id, AgendamentoNotificacaoEnum.Posterioridade, horarioPlanning, proximaData), Cron.Monthly(dataAvisoPosterior.Day, horarioPlanning.Hour, horarioPlanning.Minute), hrBrasilia);
//                            break;

//                        case PeriodicidadeEnum.Mensalmente:
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Planning - ", config.Time.Id), y => y.NotificacaoPlanning(config.Id, AgendamentoNotificacaoEnum.Antecedencia, horarioPlanning, DateTime.Now), Cron.Monthly(dataAvisoPrevio.Day, horarioPlanning.Hour, horarioPlanning.Minute), hrBrasilia);
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Planning - ", config.Time.Id + " Posterior"), y => y.NotificacaoPlanning(config.Id, AgendamentoNotificacaoEnum.Posterioridade, horarioPlanning, proximaData), Cron.Monthly(dataAvisoPosterior.Day, horarioPlanning.Hour, horarioPlanning.Minute), hrBrasilia);
//                            break;
//                    }
//                }
//            }
//            catch (Exception error)
//            {
//                return;
//            }
//        }

//        [HttpGet("ConfiguraAvisoDeReview")]
//        public void ConfiguraAvisoDeReview()
//        {
//            var configReview = _jobsService.BuscarReviewConfigs();

//            try
//            {
//                foreach (var config in configReview)
//                {
//                    DateTime proximaData;

//                    if (config.Time.ReviewConfiguracao.DataPrecursora < DateTime.Now)
//                    {
//                        proximaData = config.Time.ReviewConfiguracao.ProximaData.Value;
//                    }
//                    else
//                    {
//                        proximaData = config.Time.ReviewConfiguracao.DataPrecursora;
//                    }

//                    DateTime horarioReview = Convert.ToDateTime(config.Time.ReviewConfiguracao.HorarioReview);
//                    TimeSpan avisoAntecedencia = TimeSpan.Parse(config.AntecedenciaMin);
//                    DateTime dataAvisoPrevio = proximaData.Subtract(avisoAntecedencia);
//                    TimeSpan avisoPosterioridade = TimeSpan.Parse(config.PosterioridadeMin);
//                    DateTime dataAvisoPosterior = proximaData.AddMinutes(avisoPosterioridade.TotalMinutes);

//                    if (horarioReview.Hour < 14 || horarioReview.Hour > 18)
//                    {
//                        horarioReview = horarioReview.AddHours(14 - horarioReview.Hour);
//                    }

//                    switch (config.Time.ReviewConfiguracao.Periodicidade)
//                    {
//                        case PeriodicidadeEnum.Semanalmente:
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Review - ", config.Time.Id), y => y.NotificacaoReview(config.Id, AgendamentoNotificacaoEnum.Antecedencia, horarioReview, DateTime.Now), Cron.Monthly(dataAvisoPrevio.Day, horarioReview.Hour, horarioReview.Minute), hrBrasilia);
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Review - ", config.Time.Id + " Posterior"), y => y.NotificacaoReview(config.Id, AgendamentoNotificacaoEnum.Posterioridade, horarioReview, proximaData), Cron.Monthly(dataAvisoPosterior.Day, horarioReview.Hour, horarioReview.Minute), hrBrasilia);
//                            break;

//                        case PeriodicidadeEnum.Quinzenalmente:
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Review - ", config.Time.Id), y => y.NotificacaoReview(config.Id, AgendamentoNotificacaoEnum.Antecedencia, horarioReview, DateTime.Now), Cron.Monthly(dataAvisoPrevio.Day, horarioReview.Hour, horarioReview.Minute), hrBrasilia);
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Review - ", config.Time.Id + " Posterior"), y => y.NotificacaoReview(config.Id, AgendamentoNotificacaoEnum.Posterioridade, horarioReview, proximaData), Cron.Monthly(dataAvisoPosterior.Day, horarioReview.Hour, horarioReview.Minute), hrBrasilia);
//                            break;

//                        case PeriodicidadeEnum.Mensalmente:
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Review - ", config.Time.Id), y => y.NotificacaoReview(config.Id, AgendamentoNotificacaoEnum.Antecedencia, horarioReview, DateTime.Now), Cron.Monthly(dataAvisoPrevio.Day, horarioReview.Hour, horarioReview.Minute), hrBrasilia);
//                            RecurringJob.AddOrUpdate<JobsController>(string.Concat("Review - ", config.Time.Id + " Posterior"), y => y.NotificacaoReview(config.Id, AgendamentoNotificacaoEnum.Posterioridade, horarioReview, proximaData), Cron.Monthly(dataAvisoPosterior.Day, horarioReview.Hour, horarioReview.Minute), hrBrasilia);
//                            break;
//                    }
//                }
//            }
//            catch (Exception error)
//            {
//                return;
//            }
//        }

//        [HttpGet("TermometroMelhoriaContinuia")]
//        public async Task TermometroMelhoriaContinuia()
//        {
//            try
//            {
//                var times = await _jobsService.BuscarTimesComDicasAgileCoach();
//                times = times.Where(x => x.PontosTemperatura < 5).ToList();
//                foreach (var time in times)
//                {
//                    if (time.PessoasTime.Any())
//                        await _jobsService.EnviarNotificacaoEmailDicasAC(time.IdTime, time.PessoasTime);
//                }
//            }
//            catch (Exception e)
//            {
//                return;
//            }
//        }

//        [HttpGet("NotificacaoDaily")]
//        public void NotificacaoDaily(Guid idNotificacaoPratica, AgendamentoNotificacaoEnum tipo, double tempo = 0)
//        {
//            try
//            {
//                _jobsService.EnviarNotificacaoDaily(idNotificacaoPratica, tipo, tempo);
//            }
//            catch (Exception error)
//            {
//                return;
//            }
//        }

//        [HttpGet("NotificacaoRetro")]
//        public void NotificacaoRetro(Guid idNotificacaoPratica, AgendamentoNotificacaoEnum tipo, DateTime horario, DateTime proximaData)
//        {
//            try
//            {
//                _jobsService.EnviarNotificacaoRetro(idNotificacaoPratica, tipo, horario, proximaData);
//            }
//            catch (Exception error)
//            {
//                return;
//            }
//        }

//        [HttpGet("NotificacaoPlanning")]
//        public void NotificacaoPlanning(Guid idNotificacaoPratica, AgendamentoNotificacaoEnum tipo, DateTime horario, DateTime proximaData)
//        {
//            try
//            {
//                _jobsService.EnviarNotificacaoPlanning(idNotificacaoPratica, tipo, horario, proximaData);
//            }
//            catch (Exception error)
//            {
//                return;
//            }
//        }

//        [HttpGet("NotificacaoReview")]
//        public void NotificacaoReview(Guid idNotificacaoPratica, AgendamentoNotificacaoEnum tipo, DateTime horario, DateTime proximaData)
//        {
//            try
//            {
//                _jobsService.EnviarNotificacaoReview(idNotificacaoPratica, tipo, horario, proximaData);
//            }
//            catch (Exception error)
//            {
//                return;
//            }
//        }
//    }
//}