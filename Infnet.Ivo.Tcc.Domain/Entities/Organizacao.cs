using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Domain.Entities
{
    public class Organizacao : Entity
    {
        public string Nome { get; set; }

        public virtual IList<Usuario> Usuarios { get; set; }
    }
}
