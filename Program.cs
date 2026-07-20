using SolidEstudos.Interfaces;
using SolidEstudos.Repositories;
using SolidEstudos.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Como a aplicação trabalha com interfaces, é aqui que defino qual implementação será utilizada.
// Isso facilita trocar uma implementação por outra sem precisar modificar as classes que dependem dela, isso é o principio da inversão de dependência
builder.Services.AddSingleton<IReservaRepository, ReservaRepository>();
builder.Services.AddSingleton<INotificacaoService, EmailNotificacaoService>();
builder.Services.AddScoped<ReservaService>();

builder.Services.AddScoped<SolidEstudos.Factories.TarifaStrategyFactory>();

var app = builder.Build();

app.UseMiddleware<SolidEstudos.Middleware.ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();