using Microsoft.EntityFrameworkCore;
using LarClientes.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o contexto de banco de dados com MySQL
builder.Services.AddDbContext<LarClientesContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 21)))); // Ajuste a versão do MySQL conforme necessário

// Adicionando serviços MVC e controladores
builder.Services.AddControllers(); // Adiciona controladores, incluindo APIs
builder.Services.AddControllersWithViews();

// Adicionando o Swagger para documentação da API (opcional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LarClientes API", Version = "v1" });
});

var app = builder.Build();

// Configurando o Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LarClientes API v1"));
}

// Configurando o pipeline de solicitação HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
