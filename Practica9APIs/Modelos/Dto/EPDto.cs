using System.ComponentModel.DataAnnotations;

namespace Practica9APIs.Modelos.Dto
{
    public class EPDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nombre { get; set; }
    }
}
