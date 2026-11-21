using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Dtos
{
    public class CursosDto
    {
        public int Id { get; set; }

        public string Grado { get; set; }

        public int CantidadDeVagos { get; set; }

        public int? NivelId { get; set; }


    }
}
