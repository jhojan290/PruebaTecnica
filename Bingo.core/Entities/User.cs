using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public int IdSorteo { get; set; }
        public int Numero { get; set; }
    
    }
}
