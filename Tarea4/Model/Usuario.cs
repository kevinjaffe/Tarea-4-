namespace Tarea4.Model
{
    public class Usuario
    {
        public String Email { get; set; }
        public String Password { get; set; }

        public Usuario(String email, String pass)
        {
            this.Email = email;
            this.Password = pass;
        }

        public Boolean EsUsuarioValido() { return true; }        
        public Boolean NecesitarVerificacion() { return true; }  

    }
}
