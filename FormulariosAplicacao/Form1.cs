using BusinessLayer.Model.DTO.Usuario;
using BusinessLayer.Services;

namespace FormulariosAplicacao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void botaoCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioCadastroDTO usuario = new()
                {
                    Nome = textoNome.Text,
                    Email = textoEmail.Text,
                    Senha = textoSenha.Text
                };
                new UsuarioService().Cadastrar(usuario);
                textoNome.Clear();
                textoEmail.Clear();
                textoSenha.Clear();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao criar usuário");
            }
        }
    }
}