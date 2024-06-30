using Bide_API.Models;
using Bide_API.Repositories;
using Microsoft.EntityFrameworkCore;
using Bide_API;
using Bide_API.Helpers;
using Bide_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));

builder.Services.AddControllers();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<IConnectionRepo, ConnectionRepo>();
builder.Services.AddSingleton<IGameRepo, GameRepo>();
builder.Services.AddSingleton<IUserRepo, UserRepo>();
builder.Services.AddSingleton<IUserRepo, UserRepo>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication()
    .AddScheme<SessionTokenAuthSchemeOptions, AuthSchemeHandler>(
        "SessionTokens",
        opts => { });

var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseCors(x => x.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithExposedHeaders("Authentication"));
app.UseAuthentication();
app.Run();
