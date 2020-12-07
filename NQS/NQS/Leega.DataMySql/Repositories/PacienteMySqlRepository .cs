using Leega.DataMySql.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leega.DataMySql.Repositories.Interfaces
{
    public class PacienteMySqlRepository : BaseMySqlRepository<PacienteMySql>,IPacienteMySqlRepository
    {
        public void Adicionar(PacienteMySql obj)
        {
            string sql = @"INSERT INTO nqs.paciente
                            (Id,DocumentoIdentificacao,NomeCompleto,NomeGenitor,DataNascimento,
                                CartaoSus,Apelido,Rg,NomeGenitor2,Naturalidade,Raca,Sexo,Nacionalidade,
                                Escolaridade,SituacaoFamiliar,Endereco,Celular,Profissao,TelefoneEmergencia,
                                NomeContatoEmergencia,Email,Convenio,Especialidade,AtendimentoPrioritario,
                                MotivoAtendimento,Impressao,Procedencia,OrigemAtendimento,DesfechoAtendimento)
                        VALUES
                            (@Id,@DocumentoIdentificacao,@NomeCompleto,@NomeGenitor,@DataNascimento,
                                @CartaoSus,@Apelido,@Rg,@NomeGenitor2,@Naturalidade,@Raca,@Sexo,@Nacionalidade,
                                @Escolaridade,@SituacaoFamiliar,@Endereco,@Celular,@Profissao,@TelefoneEmergencia,
                                @NomeContatoEmergencia,@Email,@Convenio,@Especialidade,@AtendimentoPrioritario,
                                @MotivoAtendimento,@Impressao,@Procedencia, @OrigemAtendimento,@DesfechoAtendimento);";

            base.Adicionar(sql, obj);
        }
    }
}
