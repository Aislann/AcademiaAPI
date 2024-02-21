using System;
using System.Collections.Generic;

namespace Academia_API.Models
{
    public partial class Matricula
    {
        public int IdMatricula { get; set; }
        public DateTime? DataInicio { get; set; }
        public int? IdAluno { get; set; }
        public string? PlanoTreinamento { get; set; }
        public string? StatusMatricula { get; set; }

        public virtual Aluno? IdAlunoNavigation { get; set; }
    }
}
