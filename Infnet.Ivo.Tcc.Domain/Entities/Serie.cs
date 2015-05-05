using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ivo.Tcc.Domain.Entities
{
    public class Serie : IDomain
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public NivelSerie Nivel { get; set; }

        public virtual ICollection<Exercicio> Exercicios { get; set; }
    }

    public enum NivelSerie
    {
        [Display(Name = "Fácil")]
        Facil = 1,

        [Display(Name = "Médio")]
        Medio = 2,

        [Display(Name = "Difícil")]
        Dificil = 3
    }
}
