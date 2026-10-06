

using MD_AspNetCoreDemoApp.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//builder.Services.AddControllers()
//.AddXmlSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();


app.UseMiddleware<HttpContextMiddleware>();
app.UseMiddleware<LoggindMiddleware>();


app.UseSwagger();   //https://localhost:7114/swagger/swagger.json 

app.UseSwaggerUI();



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();   //api/HttpContextDemo/ShowContext

app.Run();
