using System.ComponentModel.DataAnnotations;

namespace BatucaZL.Site.Models
{
    public class ContatoModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Assunto { get; set; }

        [Required]
        [StringLength(500)]
        public string Mensagem { get; set; }
    }
}