namespace proyectoProgra6.ModelsDTOs
{
    public class UsuarioDTO
    {

        //a modo de ejemplo los atributos del modelo estarán en INGLES

        //un escenario como este puede servir para que un equipo de trabajo del app
        //que solo sepa español, entienda de qué trata 

        public int IDUser { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string BackupEmail { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Address { get; set; }
        public bool? Active { get; set; }
        public bool? ItsBlocked { get; set; }
        public int IDRol { get; set; }
        public string DescriptionRol { get; set; } = null!;

    }
}

