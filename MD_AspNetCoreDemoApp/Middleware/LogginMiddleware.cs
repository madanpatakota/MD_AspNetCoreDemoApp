namespace MD_AspNetCoreDemoApp.Middleware
{
    public class LoggindMiddleware
    {

        RequestDelegate _rd;

        public LoggindMiddleware(RequestDelegate rd)
        {
            _rd = rd;
        }



        public async Task InvokeAsync(HttpContext context)
            
        {
            Console.WriteLine("********** Incoming Request **********");
            Console.WriteLine($"Method: {context.Request.Method}");
            Console.WriteLine($"Path: {context.Request.Path}");
            Console.WriteLine($"Headers: {context.Request.Headers}");

            await _rd(context);   //next step

        }



    }
}
