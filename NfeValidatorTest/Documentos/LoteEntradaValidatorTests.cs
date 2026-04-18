using FluentValidation.TestHelper;
using NfeValidator.Recursos.Documentos.Dto;
using NfeValidator.Recursos.Documentos.Validators;

namespace NfeValidatorTest.Documentos;

public class LoteEntradaValidatorTests
{
    private readonly LoteEntradaValidator _validator = new();

    [Fact]
    public void Deve_Haver_Erro_Quando_Houver_Duplicidade_No_Lote()
    {
        var lote = new LoteEntradaDto()
        {
            LoteId = "001",
            Documentos =
            [
                new DocumentoDto
                {
                    Id = "1", Tipo = "NFE", Valor = 10, CnpjEmitente = "12345678901234", Serie = "1", Numero = "100",
                    CnpjDestinatario = "12345678901234", DataEmissao = DateTime.Now
                },
                new DocumentoDto
                {
                    Id = "1", Tipo = "NFE", Valor = 10, CnpjEmitente = "12345678901234", Serie = "1", Numero = "100",
                    CnpjDestinatario = "12345678901234", DataEmissao = DateTime.Now
                }
            ]
        };

        var result = _validator.TestValidate(lote);
        result.ShouldHaveValidationErrors();
    }
}