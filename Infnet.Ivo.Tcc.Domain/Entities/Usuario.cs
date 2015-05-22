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
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome de Usuário obrigatório!")]
        [MaxLength(100)]
        public string Nome { get; set; }

        public int? Idade { get; set; }
    }
}
