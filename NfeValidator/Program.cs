using FluentValidation;
using NfeValidator.Domain.Documento.Dto;
using NfeValidator.Domain.Documento.Service;
using NfeValidator.Domain.Documento.Validators;
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