using Library.Persistence;
using Library.Application.Interfaces;
using Library.Application;
using AutoMapper;
using Library.WebApi.Middleware;
using Library.WebApi.Helpers;
using Library.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguredAutoMapper();

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