using Library.Persistence;
using Library.Application.Interfaces;
using System.Reflection;
using Library.Application.Common.Mapping;
using Library.Application;
using AutoMapper;
using Library.WebApi.Middleware;
using Microsoft.OpenApi.Models;
using Library.WebApi.Helpers;
using Library.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(ILibraryDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration.GetConnectionString("MsSql"));
builder.Services.AddControllers();

builder.Services.AddConfiguredCors();

builder.Services.AddJwtToken(builder.Configuration);
builder.Services.AddConfiguredIdentityCore();

builder.Services.AddConfiguredSwagger();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", policy =>
//    {
//        policy.AllowAnyHeader();
//        policy.AllowAnyMethod();
//        policy.AllowAnyOrigin();
//    });
//});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
    DbInitializer.Initialize(db);

    var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
    mapper.ConfigurationProvider.AssertConfigurationIsValid();
}


app.UseCustomExceptionHandler();
app.UseRouting();
//app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.MapControllers();

app.Run();