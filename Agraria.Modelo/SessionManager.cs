using Agraria.Modelo.Entidades;

namespace Agraria.Modelo
{
    public sealed class SessionManager
    {
        private static SessionManager? _instance = null;
        private static readonly Lock _lock = new();
        
        public Usuarios Usuario { get; private set; }
        public bool InicioSesion { get; private set; }

        private SessionManager() 
        {
            Usuario = new Usuarios();
            InicioSesion = false;
        }

        public static SessionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance ??= new SessionManager();
                    }
                }
                return _instance;
            }
        }

        public void SetUsuario(Usuarios usuario)
        {
            if (usuario != null)
            {
                Usuario = usuario;
                InicioSesion = true;
            }
        }

        public void ClearSession()
        {
            Usuario = new Usuarios();
            InicioSesion = false;
        }
    }
}