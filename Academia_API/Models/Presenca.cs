using System;
using System.Collections.Generic;

namespace Academia_API.Models
{
    public partial class Presenca
    {
        public int IdPresenca { get; set; }
        public DateTime? DataAula { get; set; }
        public TimeSpan? Horario { get; set; }
        public int? IdAluno { get; set; }
        public int? IdAula { get; set; }

        public virtual Aluno? IdAlunoNavigation { get; set; }
        public virtual Aula? IdAulaNavigation { get; set; }
    }
}
