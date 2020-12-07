using Leega.DataMySql.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace Leega.DataMySql.Tests.Tests
{
    public class PacienteTests : BaseTests
    {
        public void Executar()
        {
            Adicionar();
            Console.WriteLine("Adicionado");

        }

        private void Adicionar()
        {
            try
            {
                //_usuarioMySqlService

                _PacienteMySqlService.Adicionar(new PacienteMySql
                {
                    Apelido = "Fran",
                    AtendimentoPrioritario = false,
                    CartaoSus = "cartaoSus123",
                    Celular = "1198999555",
                    DataNascimento = DateTime.Now,
                    DesfechoAtendimento = null,
                    DocumentoIdentificacao = "docIdentf",
                    Email = "franc@gmail.com",
                    Endereco = "endereco123",
                    Id = Guid.NewGuid().ToString(),
                    Convenio = 1,
                    Escolaridade = 1,
                    Especialidade = 1,
                    Impressao = 1,
                    MotivoAtendimento = 1,
                    Nacionalidade = 1,
                    Naturalidade = 1,
                    OrigemAtendimento = 1,
                    Procedencia = 1,
                    Raca = 1,
                    Sexo = 1,
                    SituacaoFamiliar = 1,
                    NomeCompleto = "francisco diogo",
                    NomeContatoEmergencia = "joelita",
                    NomeGenitor = "barrerito",
                    NomeGenitor2 = "joelma",
                    Profissao = "dev",
                    Rg = "123rg",
                    TelefoneEmergencia = "11999999"
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            //PacienteMySql paciente = new PacienteMySql();
            //paciente.Apelido = "Fran";
            //paciente.AtendimentoPrioritario = false;
            //paciente.CartaoSus = "cartaoSus123";
            //paciente.Celular = "1198999555";
            //paciente.DataNascimento = DateTime.Now;
            //paciente.DesfechoAtendimento = null;
            //paciente.DocumentoIdentificacao = "docIdentf";
            //paciente.Email = "franc@gmail.com";
            //paciente.Endereco = "endereco123";
            //paciente.Id = Guid.NewGuid().ToString();
            //paciente.Convenio = 1;
            //paciente.Escolaridade = 1;
            //paciente.Especialidade = 1;
            //paciente.Impressao = 1;
            //paciente.MotivoAtendimento = 1;
            //paciente.Nacionalidade = 1;
            //paciente.Naturalidade = 1;
            //paciente.OrigemAtendimento = 1;
            //paciente.Procedencia = 1;
            //paciente.Raca = 1;
            //paciente.Sexo = 1;
            //paciente.SituacaoFamiliar = 1;
            //paciente.NomeCompleto = "francisco diogo";
            //paciente.NomeContatoEmergencia = "joelita";
            //paciente.NomeGenitor = "barrerito";
            //paciente.NomeGenitor2 = "joelma";
            //paciente.Profissao = "dev";
            //paciente.Rg = "123rg";
            //paciente.TelefoneEmergencia = "11999999";

            //Adicionar(paciente);
            //Console.WriteLine("Adicionado");


        }

    }
}
