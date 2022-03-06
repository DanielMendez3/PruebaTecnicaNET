namespace PruebaTecnicaNET.DAL.Models
{
    public class Jerarquia
    {
        public int IdEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public int Nivel { get; set; }
        public string NombreJefe { get; set; }
        public int IdJefe { get; set; }
    }
}
