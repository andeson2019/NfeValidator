using FluentValidation.TestHelper;
using NfeValidator.Recursos.Documentos.Dto;
using NfeValidator.Recursos.Documentos.Validators;

namespace NfeValidatorTest.Documentos;

public class DocumentoValidatorTests
{
    private readonly DocumentoValidator _validator = new();

    [Fact]
    public void Deve_Haver_Erro_Quando_Tipo_Invalido()
    {
        var model = new DocumentoDto { Tipo = "NFSE" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Tipo);
    }

    [Fact]
    public void Deve_Haver_Erro_Quando_Valor_Zero_Ou_Menor()
    {
        var model = new DocumentoDto { Valor = 0 };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Valor);
    }

    [Fact]
    public void Deve_Haver_Erro_Quando_CnpjEmitente_Nao_Tem_14_Digitos()
    {
        var model = new DocumentoDto { CnpjEmitente = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.CnpjEmitente);
    }
    
    [Fact]
    public void Deve_Haver_Erro_Quando_CnpjDestinatario_Nao_Tem_14_Digitos()
    {
        var model = new DocumentoDto { CnpjDestinatario = "123" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.CnpjDestinatario);
    }
    
    [Fact]
    public void Deve_Haver_Erro_Quando_DataEmissao_For_Valor_Padrao()
    {
        // DateTime.MinValue é o valor padrão quando nada é enviado ou a data é inválida no parse
        var model = new DocumentoDto { DataEmissao = default }; 
        var result = _validator.TestValidate(model);
    
        result.ShouldHaveValidationErrorFor(x => x.DataEmissao);
    }

    [Fact]
    public void Deve_Passar_Quando_DataEmissao_For_Valida()
    {
        var model = new DocumentoDto { DataEmissao = DateTime.Now };
        var result = _validator.TestValidate(model);
    
        result.ShouldNotHaveValidationErrorFor(x => x.DataEmissao);
    }
 
    [Fact]
    public void Deve_Haver_Erro_Quando_Numero_For_Vazio()
    {
        var model = new DocumentoDto { Numero = ""};
        var result = _validator.TestValidate(model);
    
        result.ShouldHaveValidationErrorFor(x => x.Numero);
    }
    
}