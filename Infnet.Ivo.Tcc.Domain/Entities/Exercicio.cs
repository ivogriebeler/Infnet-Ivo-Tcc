using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Domain.Entities
{
    public class Exercicio : Entity
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Duracao { get; set; }

        public int SerieId { get; set; }
        public virtual Serie Serie { get; set; }
    }
}
