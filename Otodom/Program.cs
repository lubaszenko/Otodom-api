using Otodom;
using Otodom.Repositories;
using Otodom.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OtodomContext>();

builder.Services.AddScoped<IAgencjaRepository,AgencjaRepository>();
builder.Services.AddScoped<IAgencjaService,AgencjaService>();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();