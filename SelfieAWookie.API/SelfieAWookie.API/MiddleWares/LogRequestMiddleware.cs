namespace SelfieAWookie.API.MiddleWares
{
    public class LogRequestMiddleware
    {
        private RequestDelegate _Next = null;
        private ILogger<LogRequestMiddleware> _Log = null;
        public LogRequestMiddleware(RequestDelegate next, ILogger<LogRequestMiddleware> log)
        {
            _Next = next;
            _Log = log;
        }

        public async Task Invoke(HttpContext contexte)
        {
            _Log.LogWarning(contexte.Request.Path.Value);
            await _Next(contexte);
        }
    }
}
