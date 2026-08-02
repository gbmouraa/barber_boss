using System.Net;

namespace BarberBoss.Exception
{
    public abstract class BarberBossException : System.Exception
    {
        protected BarberBossException(string errorMessage) : base(errorMessage) { }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
