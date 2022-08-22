using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;
using SelfieAWookie.API.Extensions;
using Microsoft.AspNetCore.Identity;
using SelfieAWookie.Core.Selfies.Infrastructures.Logs;
using SelfieAWookie.API.MiddleWares;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
string ConnectionString = builder.Configuration.GetConnectionString("defaultConnexion");
builder.Services.AddDbContext<Contexte>(options => options.UseSqlServer(ConnectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<Contexte>();

builder.Services.AddInjections()
                .AddCustomSecurity(builder.Configuration)
                .AddCustomOptions(builder.Configuration);

builder.Logging.AddProvider(new CustomLoggerProvider());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseMiddleware<LogRequestMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseCors(SecuriteMethodes.DEFAULT_POLICY);

app.MapControllers();

app.Run();
