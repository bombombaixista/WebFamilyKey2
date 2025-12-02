using Microsoft.EntityFrameworkCore;
using WebFamilyKey2.Data;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a Controllers de API
builder.Services.AddControllers();

// Configuração do DbContext com PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger para testar os endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Aplica migrations automaticamente no startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// Configure o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebFamilyKey2 API v1");
        c.RoutePrefix = string.Empty; // 👉 faz o Swagger abrir direto na raiz "/"
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebFamilyKey2 API v1");
        c.RoutePrefix = string.Empty; // 👉 também abre direto em produção
    });

    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Mapeia os controllers da API
app.MapControllers();

app.Run();
