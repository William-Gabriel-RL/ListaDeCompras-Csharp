using BusinessLayer.DAL.Base;
using BusinessLayer.DAL.Interfaces;
using BusinessLayer.Model;
using System.Data.SqlClient;

namespace BusinessLayer.DAL
{
    public class SupermercadoDAO : BaseDAO, ISupermercadoDAO
    {
        public Supermercado Adicionar(Supermercado supermercado)
        {
            using (var con = this.Con)
            {
                Con.Open();
                try
                {
                    this.SqlString = "INSERT INTO supermercado (nome, cidade, logradouro, bairro, estado, cep) values (@nome, @cidade, @logradouro, @bairro, @estado, @cep)";
                    using (var cmd = new SqlCommand(this.SqlString, con))
                    {
                        cmd.Parameters.AddWithValue("@nome", supermercado.Nome);
                        cmd.Parameters.AddWithValue("@cidade", supermercado.Cidade);
                        cmd.Parameters.AddWithValue("@logradouro", supermercado.Logradouro);
                        cmd.Parameters.AddWithValue("@bairro", supermercado.Bairro);
                        cmd.Parameters.AddWithValue("@estado", supermercado.Estado);
                        cmd.Parameters.AddWithValue("@cep", supermercado.CEP);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao criar supermercado: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
            return supermercado;
        }

        public Supermercado Editar(int id, Supermercado supermercado)
        {
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                try
                {
                    this.SqlString = "UPDATE supermercado SET " +
                        "nome = @nome, " +
                        "cidade = @cidade, " +
                        "logradouro = @logradouro, " +
                        "bairro = @bairro, " +
                        "estado = @estado, " +
                        "cep = @cep " +
                        "WHERE id = @id;";
                    using (var cmd = new SqlCommand(this.SqlString, con))
                    {

                        cmd.Parameters.AddWithValue("@nome", supermercado.Nome);
                        cmd.Parameters.AddWithValue("@cidade", supermercado.Cidade);
                        cmd.Parameters.AddWithValue("@logradouro", supermercado.Logradouro);
                        cmd.Parameters.AddWithValue("@bairro", supermercado.Bairro);
                        cmd.Parameters.AddWithValue("@estado", supermercado.Estado);
                        cmd.Parameters.AddWithValue("@cep", supermercado.CEP);
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro não ao editar supermercado: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
            return supermercado;
        }

        public void Excluir(int id)
        {
            using (SqlConnection con = new(this.ConnectionString))
            {
                try
                {

                    string sqlString = "Delete from supermercado where id = @id";
                    SqlCommand cmd = new(sqlString, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw;
                }
                finally { con.Close(); }
            }
        }

        public List<Supermercado> Listar()
        {
            List<Supermercado> lstsupermercado = new();
            using (SqlConnection con = new(this.ConnectionString))
            {
                con.Open();
                var sqlString = "SELECT * FROM supermercado";
                using SqlCommand cmd = new(sqlString, con);
                try
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Supermercado supermercado = new()
                        {
                            Id = Convert.ToInt32(dr["id"].ToString()),
                            Nome = dr["nome"].ToString(),
                            Cidade = dr["cidade"].ToString(),
                            Logradouro = dr["logradouro"].ToString(),
                            Bairro = dr["bairro"].ToString(),
                            Estado = dr["estado"].ToString(),
                            CEP = dr["cep"].ToString()
                        };

                        lstsupermercado.Add(supermercado);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
            return lstsupermercado;
        }

        public Supermercado? Obter(int id)
        {
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                try
                {
                    this.SqlString = "SELECT id, nome, cidade, logradouro, bairro, estado, cep FROM supermercado WHERE id = @id";
                    using (var cmd = new SqlCommand(this.SqlString, con))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        var dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            return new Supermercado
                            {
                                Id = Convert.ToInt32(dr["id"].ToString()),
                                Nome = dr["nome"].ToString(),
                                Cidade = dr["cidade"].ToString(),
                                Logradouro = dr["logradouro"].ToString(),
                                Bairro = dr["bairro"].ToString(),
                                Estado = dr["estado"].ToString(),
                                CEP = dr["cep"].ToString()
                            };
                        };
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception($"Erro não mapeado ao criar usuário: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
            return null;
        }
    }
}
