using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model
{
    [Table(nameof(Paciente))]
    public class Paciente: ModelComId
    {
        [Required, StringLength(maximumLength: 100, MinimumLength = 8)]
        public string Nome { get; set; }
        [Required, StringLength(maximumLength: 11, MinimumLength = 11)]
        public string CPF { get; set; }
        [Required, StringLength(maximumLength: 100, MinimumLength = 8)]
        public string NomeMae { get; set; }
        [Required]
        public string NumeroCarteirinha { get; set; }
        public DateTime DataNascimento { get; set; }

        public Endereco Endereco { get; set; }
        public Plano PlanoAtivo { get; set; }
        public ICollection<Exame> Exames { get; set; }
    }

}
