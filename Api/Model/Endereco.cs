using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model
{

    [Table(nameof(Endereco))]
    public class Endereco: ModelComId
    {
        [Required(AllowEmptyStrings = false)]
        public string Logradoro { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Numero { get; set; }

        public string Bairro { get; set; }
        public string Cidade { get; set; }

        [Required, StringLength(maximumLength: 8, MinimumLength = 8)]
        public string CEP { get; set; }

        public string Complemento { get; set; }
        public int PacienteId { get; set; }

        [ForeignKey(nameof(PacienteId))]
        public Paciente Paciente { get; set; }
    }

}
