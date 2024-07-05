using Practica9APIs.Modelos.Dto;

namespace Practica9APIs.Datos
{
    public class EPStore
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public static List<EPDto> EPList = new List<EPDto>
        {
            new EPDto{Id=1, Nombre="Vista a la piscina"},
            new EPDto{Id=2, Nombre="Vista a la playa"}
        };
    }
}
