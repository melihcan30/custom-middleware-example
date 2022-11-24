namespace custom_middleware_example.Middlewares
{
    public class LoggingMiddleware
    {
        readonly RequestDelegate _next;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            finally 
            {
                string logText = $"{context.Request?.Method} {context.Request?.Path.Value} => {context.Response?.StatusCode}{Environment.NewLine}";
                File.AppendAllText("log.txt", logText);
                
            }
        }
    }
}
