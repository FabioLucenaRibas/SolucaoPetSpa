using Biblioteca.ClassesBasicas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Biblioteca.Dados
{
    public class DadosAgenda : Conexao
    {
        #region selecionando os registros da tabela
        public List<Agenda> SelecionarAgenda()
        {
            List<Agenda> retorno = new List<Agenda>();
            try
            {
                this.abrirConexao();
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand("SELECT CodigoAgenda, Hora, Data FROM Agenda ", sqlConn);
                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();
                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    Agenda A = new Agenda();
                    //acessando os valores das colunas do resultado
                    A.CodigoAgenda = DbReader.GetInt32(DbReader.GetOrdinal("CodigoAgenda"));
                    A.Hora = DbReader.GetString(DbReader.GetOrdinal("Hora"));
                    A.Data = DbReader.GetString(DbReader.GetOrdinal("Data"));
                    retorno.Add(A);
                }
                //fechando o leitor de resultados
                DbReader.Close();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar e selecionar " + ex.Message);
            }
            return retorno;
        }
        #endregion

        #region Inserindo registro na tabela
        public void InserirAgenda(Agenda A)
        {

            try
            {
                this.abrirConexao();
                string sql = "INSERT INTO Agenda (Hora, Data, CodigoAnimal, CodigoServico, CPF) values('" + A.Hora + "','" + A.Data + "'," + A.Animal.CodigoAnimal + "," + A.Servico.CodigoServico + ",'" + A.Cliente.Cpf + "')";
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar e inserir " + ex.Message);
            }
        }

        #endregion

        #region Atualizar registro na tabela
        public void AtualizarAgenda(Agenda A)
        {

            try
            {
                this.abrirConexao();
                string sql = "UPDATE Agenda SET Hora = '" + A.Hora + "', Data = '" + A.Data + "' WHERE CodigoAgenda =" + A.CodigoAgenda;
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar e atualizar " + ex.Message);
            }
        }

        #endregion

        #region Delete registro na tabela
        public void DeleteAgenda(Agenda A)
        {

            try
            {
                this.abrirConexao();
                string sql = "DELETE FROM Agenda WHERE CodigoAgenda =" + A.CodigoAgenda;
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conectar e deletar " + ex.Message);
            }
        }

        #endregion

    }
}
