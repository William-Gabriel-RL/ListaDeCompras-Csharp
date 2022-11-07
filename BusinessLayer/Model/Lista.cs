using BusinessLayer.Model.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Lista : BaseModel
    {
        public DateTime Data { get; set; } = DateTime.Now;
        public double Total { get; set; } = 0;
        public bool EstaAtiva { get; set; } = true;
        public virtual Usuario Usuario { get; set; } = new();

    }
}
