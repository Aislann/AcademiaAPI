using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Academia_API.Models
{
    public partial class Aula
    {
        public Aula()
        {
            Presencas = new HashSet<Presenca>();
        }
        [Key]
        public int IdAula { get; set; }
        public string? NomeAula { get; set; }
        public TimeSpan? Horario { get; set; }
        public int? IdInstrutor { get; set; }
        public int? CapacidadeMaxima { get; set; }
        public string? Descricao { get; set; }

        public virtual Instrutor? IdInstrutorNavigation { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
