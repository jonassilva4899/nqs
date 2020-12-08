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

        public IEnumerable<PacienteMySql> ListarTodos()
        {
            string sql = @"select * from paciente";
            return base.Listar<PacienteMySql>(sql);
        }

        public PacienteMySql Obter(PacienteMySql obj)
        {
            string sql = @"select * from paciente where Id = @Id";
            return base.Obter(sql, obj);
        }


        void IPacienteMySqlRepository.Atualizar(PacienteMySql obj)
        {
            string sql = @"UPDATE nqs.paciente
                            SET                            
                            DocumentoIdentificacao = @DocumentoIdentificacao,
                            NomeCompleto = @NomeCompleto,
                            NomeGenitor = @NomeGenitor,
                            DataNascimento = @DataNascimento,
                            CartaoSus = @CartaoSus,
                            Apelido = @Apelido,
                            Rg = @Rg,
                            NomeGenitor2 = @NomeGenitor2,
                            Naturalidade = @Naturalidade,
                            Raca = @Raca,
                            Sexo = @Sexo,
                            Nacionalidade = @Nacionalidade,
                            Escolaridade = @Escolaridade,
                            SituacaoFamiliar = @SituacaoFamiliar,
                            Endereco = @Endereco,
                            Celular = @Celular,
                            Profissao = @Profissao,
                            TelefoneEmergencia = @TelefoneEmergencia,
                            NomeContatoEmergencia = @NomeContatoEmergencia,
                            Email = @Email,
                            Convenio = @Convenio,
                            Especialidade = @Especialidade,
                            AtendimentoPrioritario = @AtendimentoPrioritario,
                            MotivoAtendimento = @MotivoAtendimento,
                            Impressao = @Impressao,
                            Procedencia = @Procedencia,                            
                            OrigemAtendimento = @OrigemAtendimento,
                            DesfechoAtendimento = @DesfechoAtendimento
                            WHERE Id = @Id;";

            base.Atualizar(sql, obj);
        }
    }
}
