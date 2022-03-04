using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaNET.ViewModels.AreasViewModel
{
    public class AreaResponse
    {
        public int IdArea { get; set; }
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
