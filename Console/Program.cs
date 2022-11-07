using BusinessLayer.DAL;
using BusinessLayer.Model;
using Newtonsoft.Json;

var user = new Usuario
{
    Nome = "Editado",
    Email = "edicao@email.com",
    Senha = "123editado"
};

Console.WriteLine(JsonConvert.SerializeObject(new UsuarioDAO().Obter(4)));

Console.WriteLine(new UsuarioDAO().Editar(4, user));

Console.WriteLine(JsonConvert.SerializeObject(new UsuarioDAO().Obter(4)));