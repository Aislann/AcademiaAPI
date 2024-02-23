using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academia_API.Models
{
    public partial class Aluno
    {
        public Aluno()
        {
            Matriculas = new HashSet<Matricula>();
            Presencas = new HashSet<Presenca>();
        }

        [Key]
        public int IdAluno { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Genero { get; set; }
        public string? Endereco { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
