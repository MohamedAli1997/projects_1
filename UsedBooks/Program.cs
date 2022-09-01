using Microsoft.AspNetCore.Identity;
using Serilog;
using UsedBooks;
using UsedBooks.Data;
using UsedBooks.Features.User;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");


var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console(
        outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder
    .ConfigureServices()
    .ConfigurePipeline();


app.UseCors(MyAllowSpecificOrigins);
app.UseSwagger();

app.UseSwaggerUI();

using var scope = app.Services.CreateScope();
Log.Information("Seeding database");
var services = scope.ServiceProvider;
var context = services.GetRequiredService<ApplicationDbContext>();
var userManager = services.GetService<UserManager<ApplicationUser>>();
var roleManager = services.GetService<RoleManager<IdentityRole>>();
DbInitializer.Init(context, userManager, roleManager, app.Environment.IsProduction());


app.Run();