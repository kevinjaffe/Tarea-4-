using Tarea4.Model;
using Microsoft.AspNetCore.SignalR;

namespace Tarea4.Hubs
{
    public class LoginConVerificacionHub : Hub
    {
        private readonly ILogger<LoginConVerificacionHub> _logger;

        public LoginConVerificacionHub(ILogger<LoginConVerificacionHub> logger)
        {
            _logger = logger;
        }

        public void Login(String email, String pass)
        {
            _logger.LogInformation("SignalR identificación del usuario: " + Context.ConnectionId);
            Usuario usr = new Usuario(email, pass);
            if (usr.EsUsuarioValido() && usr.NecesitarVerificacion())
            {
                string usrId = Context.ConnectionId;
                _logger.LogInformation($"**** Copiar la siguiente url para probar");
                _logger.LogInformation($"https://localhost:7232/verificar/usuario/{usrId}");
            }
        }
    }
}
