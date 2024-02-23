using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academia_API.Models
{
    public partial class Instrutor
    {
        public Instrutor()
        {
            Aulas = new HashSet<Aula>();
        }
        [Key]
        public int IdInstrutor { get; set; }
        public string? Nome { get; set; }
        public string? Especialidade { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Aula> Aulas { get; set; }
    }
}
