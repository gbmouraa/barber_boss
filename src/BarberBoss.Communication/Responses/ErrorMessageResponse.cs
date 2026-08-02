namespace BarberBoss.Communication.Responses
{
    public class ErrorMessageResponse
    {
        public List<string> Errors { get; set; }

        public ErrorMessageResponse(List<string> errors)
        {
            Errors = errors;
        }

        public ErrorMessageResponse(string error)
        {
            Errors = new List<string> { error };
        }
    }
}
