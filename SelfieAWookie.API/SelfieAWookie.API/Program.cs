using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;
using SelfieAWookie.Core.Selfies.Infrastructures.Repositories;
using SelfieAWookie.API.Extensions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string ConnectionString = builder.Configuration.GetConnectionString("defaultConnexion");
builder.Services.AddDbContext<Contexte>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<Contexte>();

builder.Services.AddInjections();

builder.Services.AddCustomSecurity(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseCors(SecuriteMethodes.DEFAULT_POLICY);

app.MapControllers();

app.Run();
