using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL.Interfaces
{
    public interface ISupermercadoDAO
    {
        public Supermercado Adicionar(Supermercado supermercado);
        public Supermercado? Obter(int id);
        public Supermercado Editar(int id,Supermercado supermercado);
        public void Excluir(int id);
        public List<Supermercado> Listar();
    }
}
