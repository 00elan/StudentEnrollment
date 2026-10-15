using Net6_Controller_And_VIte;
using StudentEnrollmentSystem.Application;
using StudentEnrollmentSystem.Application.Contracts.Repository;
using StudentEnrollmentSystem.Infrastructure;
using StudentEnrollmentSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    //when client request data that isn't supported
    options.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters(); ; //added support for returning data in XML format/handling XML

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCoreServices(); //MediatR is registered in startup to map requests within the assemblies 'AUTOMATICALLY'
builder.Services.AddInfrastructureServices(builder.Configuration, builder.Host);


// In production, the Vite files will be served from this directory
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp/dist";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSpaStaticFiles();


app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseSpa(spa =>
{
    if (app.Environment.IsDevelopment())
        spa.UseViteDevelopmentServer(sourcePath: "ClientApp");
});

app.Run();
