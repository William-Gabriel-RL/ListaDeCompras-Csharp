using BusinessLayer.DAL.Base;
using BusinessLayer.DAL.Interfaces;
using BusinessLayer.Model;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace BusinessLayer.DAL
{
    public class UsuarioDAO : BaseDAO, IUsuarioDAO
    {
        public Usuario Adicionar(Usuario usuario)
        {
            using (var con = this.Con)
            {
                Con.Open();
                try
                {
                    this.SqlString = "INSERT INTO usuario (nome, email, senha) values (@nome,@email,@senha)";
                    using (var cmd = new SqlCommand(this.SqlString, con))
                    {
                        cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("@email", usuario.Email);
                        cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao criar usuário: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
            usuario.Id = Convert.ToInt32(GetLastIdInserted(usuario.Email));
            return usuario;
        }

        private int? GetLastIdInserted(string email)
        {
            int? result = null;
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                var sqlString = $"SELECT u.id FROM Usuario u WHERE u.email = '{email}';";
                using (var cmd = new SqlCommand(sqlString, con))
                {
                    try
                    {
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        result = (int?)dr.GetInt32(0);
                        {
                            return Convert.ToInt32(dr["id"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return result;
        }

        public Usuario Editar(int id, Usuario usuario)
        {
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                try
                {
                    this.SqlString = "UPDATE usuario SET  " +
                        " nome = @nome, " +
                        " senha = @senha ";
                    if (usuario.Email != null)
                        this.SqlString += " ,email = @email ";
                    this.SqlString += " WHERE id = @id;";

                    using (var cmd = new SqlCommand(this.SqlString, con))
                    {

                        cmd.Parameters.AddWithValue("nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("senha", usuario.Senha);
                        if (usuario.Email != null)
                            cmd.Parameters.AddWithValue("email", usuario.Email);

                        cmd.Parameters.AddWithValue("id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"300500 Erro não mapeado ao criar Usuario: {ex.Message}");
                }
                finally
                {
                    con.Close();
                }
            }
            usuario.Id = Convert.ToInt32(GetLastIdInserted(usuario.Email));
            return usuario;
        }
        public void Excluir(int id) //Testado e funcionando
        {
            using (SqlConnection con = new(this.ConnectionString))
            {
                try
                {
                    string sqlString = "Delete from usuario where id = @id";
                    SqlCommand cmd = new(sqlString, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                    throw new Exception($"Não foi possível excluir usuário: {ex.Message}");
                }
                finally { con.Close(); }
            }
        }

        public List<Usuario> Listar()
        {
            List<Usuario> lstusuario = new();
            using (SqlConnection con = new(this.ConnectionString))
            {
                con.Open();
                var sqlString = "SELECT * FROM usuario";
                using SqlCommand cmd = new(sqlString, con);
                try
                {
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Usuario usuario = new()
                        {
                            Id = Convert.ToInt32(dr["id"].ToString()),
                            Nome = dr["nome"].ToString(),
                            Email = dr["email"].ToString()
                        };

                        lstusuario.Add(usuario);
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
            return lstusuario;
        }

        public Usuario? Obter(int id)
        {
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                try
                {
                    this.SqlString = "SELECT id, nome, email, senha FROM usuario WHERE id = @id";
                    using (var cmd = new SqlCommand(this.SqlString, con))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        var dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            return new Usuario
                            {
                                Id = Convert.ToInt32(dr["id"].ToString()),
                                Nome = dr["nome"].ToString(),
                                Email = dr["email"].ToString(),
                                Senha = dr["senha"].ToString()
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
        public Usuario? Login(string email, string senha)
        {
            using (var con = new SqlConnection(this.ConnectionString))
            {
                try
                {
                    this.SqlString = "SELECT id, nome, email, senha FROM usuario WHERE email = @email AND senha = @senha;";
                    using (var cmd = new SqlCommand(this.SqlString, con))
                    {
                        cmd.Parameters.AddWithValue("email", email); 
                        cmd.Parameters.AddWithValue("senha", senha);
                        con.Open();
                        var dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            return new Usuario
                            {
                                Id = Convert.ToInt32(dr["id"].ToString()),
                                Nome = dr["nome"].ToString(),
                                Email = dr["email"].ToString(),
                                Senha = dr["senha"].ToString()
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
