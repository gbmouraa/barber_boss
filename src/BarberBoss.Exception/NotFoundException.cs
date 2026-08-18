using System.Net;

namespace BarberBoss.Exception
{
    public class NotFoundException : BarberBossException
    {
        public NotFoundException(string error) : base(error) { }

        public override List<string> GetErrors() => new List<string> { Message };

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
    }
}
