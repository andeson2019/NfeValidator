using FluentValidation;
using NfeValidator.Recursos.Documentos.Dto;
using NfeValidator.Recursos.Documentos.Service;
using NfeValidator.Recursos.Documentos.Validators;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptionsWithValidateOnStart<LoteEntradaValidator>();
builder.Services.AddScoped<IDocumentoService, DocumentoService>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

builder.Services.AddScoped<IValidator<LoteEntradaDto>, LoteEntradaValidator>();
builder.Services.AddScoped<IValidator<DocumentoDto>, DocumentoValidator>();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();