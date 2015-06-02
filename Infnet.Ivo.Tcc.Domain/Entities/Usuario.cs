using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }

        public int? Idade { get; set; }

        public int OrganizacaoId { get; set; }
        public virtual Organizacao Organizacao { get; set; }

        public string Observacoes { get; set; }
    }
}
