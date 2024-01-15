using Otodom;
using Otodom.Repositories;
using Otodom.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OtodomContext>();

builder.Services.AddScoped<IAgencjaRepository,AgencjaRepository>();
builder.Services.AddScoped<IAgencjaService,AgencjaService>();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("https://localhost:7085")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();