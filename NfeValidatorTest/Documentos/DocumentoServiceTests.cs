using FluentValidation;
using FluentValidation.Results;
using Moq;
using NfeValidator.Recursos.Documentos.Dto;
using NfeValidator.Recursos.Documentos.Service;

namespace NfeValidatorTest.Documentos;

public class DocumentoServiceTests
{
    private readonly Mock<IValidator<LoteEntradaDto>> _mockValidator;
    private readonly DocumentoService _service;

    public DocumentoServiceTests()
    {
        _mockValidator = new Mock<IValidator<LoteEntradaDto>>();
        _service = new DocumentoService(_mockValidator.Object);
    }

    [Fact]
    public async Task ProcessarLoteAsync_Deve_Retornar_Relatorio_Correto()
    {
        var lote = new LoteEntradaDto
        {
            LoteId = "LOTE-001",
            Documentos =
            [
                new DocumentoDto { Id = "DOC-1", Tipo = "NFE" },
                new DocumentoDto { Id = "DOC-2", Tipo = "NFE" }
            ]
        };

        var validationFailures = new List<ValidationFailure>
        {
            new("Documentos[1].Numero", "numero nao informado")
        };

        var validationResult = new ValidationResult(validationFailures);

        _mockValidator
            .Setup(v => v.ValidateAsync(It.IsAny<LoteEntradaDto>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(validationResult);

        var resultado = await _service.ProcessarLoteAsync(lote);

        Assert.NotNull(resultado);
        Assert.Equal(2, resultado.TotalDocumentos);
        Assert.Equal(1, resultado.Validos);
        Assert.Equal(1, resultado.Invalidos);
    }
}