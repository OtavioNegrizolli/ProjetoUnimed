using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model
{
    public class Exame: ModelComId
    {
        [Required, MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        public DateTime DataRealizacao { get; set; }
        [Required]
        public int PacienteId { get; set; }
        [ForeignKey(nameof(PacienteId))]
        public Paciente Paciente { get; set; }
    }
}
