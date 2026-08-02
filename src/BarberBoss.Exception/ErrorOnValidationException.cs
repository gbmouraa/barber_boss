using System.Net;

namespace BarberBoss.Exception
{
    public class ErrorOnValidationException : BarberBossException
    {
        private readonly List<string> Errors;

        public ErrorOnValidationException(List<string> errors) : base(string.Empty)
        {
            Errors = errors;
        }

        public override List<string> GetErrors() => Errors;
        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
    }
}
