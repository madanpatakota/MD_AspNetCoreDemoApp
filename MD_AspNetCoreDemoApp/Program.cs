using MD_AspNetCoreDemoApp.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


//builder.Services.AddControllers()
//.AddXmlSerializerFormatters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddScoped<IEmployeeV2Repository, EmployeeV2Repository>();
//builder.Services.AddTransient<IEmployeeV2Repository, EmployeeV2Repository>();
builder.Services.AddSingleton<IEmployeeV2Repository, EmployeeV2Repository>();

//IEmployeeV2Repository iemp = new EmployeeV2Repository();


// in furute wen ever if you refer the IEmployeeV2Repository so u wil get the instance of EmployeeV2Repository



var app = builder.Build();


app.UseSwagger();   //https://localhost:7114/swagger/swagger.json 

app.UseSwaggerUI();



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
