using Library.Persistence;
using Library.Application.Interfaces;
using System.Reflection;
using Library.Application.Common.Mapping;
using Library.Application;
using AutoMapper;
using Library.WebApi.Middleware;
using Microsoft.OpenApi.Models;
using Library.WebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(ILibraryDbContext).Assembly));
});

builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration.GetConnectionString("MsSql"));
builder.Services.AddControllers();

//builder.Services.AddJwtToken(builder.Configuration);

builder.Services.AddConfiguredSwagger();

//builder.Services.AddSwaggerGen(option =>
//{
//    option.CustomSchemaIds(type => type.ToString());

//    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Library API", Version = "v1" });
//    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Description = "Please enter a valid token",
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        BearerFormat = "JWT",
//        Scheme = "Bearer"
//    });
//    option.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type=ReferenceType.SecurityScheme,
//                    Id="Bearer"
//                }
//            },
//            new string[]{}
//        }
//    });
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});




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
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();