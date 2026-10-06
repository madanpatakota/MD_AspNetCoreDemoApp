namespace MD_AspNetCoreDemoApp.Middleware
{
    public class HttpContextMiddleware
    {

        RequestDelegate _rd;

        public HttpContextMiddleware(RequestDelegate rd)
        {
            _rd = rd;
        }



        public async Task InvokeAsync(HttpContext context)
            
        {
            // ConsoleLoggerExtensions.lwriteloi("heelow);

            //var context = ;


            var headers = context.Request.Headers;
            var body = context.Request.Body;
            var path = context.Request.Path;
            var query = context.Request.Query;


            context.Response.Headers.Append("demo-response", "THis is from asp.entcore ");
            context.Response.Headers.Append("demo-messagestatus", "received all data");



            //context contains the your http request & rsponse related information
            await _rd(context);   //next step

        }



    }
}
