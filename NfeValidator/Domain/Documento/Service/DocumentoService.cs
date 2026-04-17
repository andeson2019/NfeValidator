using FluentValidation;
using NfeValidator.Domain.Documento.Dto;

namespace NfeValidator.Domain.Documento.Service;

public class DocumentoService(IValidator<LoteEntradaDto> validator) : IDocumentoService
{
    public async Task<LoteRespostaDto> ProcessarLoteAsync(LoteEntradaDto lote)
    {
        var resultadoValidacao = await validator.ValidateAsync(lote);
        var resposta = new LoteRespostaDto
        {
            LoteId = lote.LoteId,
            TotalDocumentos = lote.Documentos.Count,
            Documentos = lote.Documentos.Select((doc, index) =>
                MapearDocumentoResposta(doc, index, resultadoValidacao)).ToList()
        };
        resposta.Validos = resposta.Documentos.Count(d => d.Status == "VALIDO");
        resposta.Invalidos = resposta.Documentos.Count(d => d.Status == "INVALIDO");

        return resposta;
    }

    private static DocumentoRespostaDto MapearDocumentoResposta(DocumentoDto doc, int index,
        FluentValidation.Results.ValidationResult resultado)
    {
        var prefixo = $"Documentos[{index}]";
        var errosDoDoc = resultado.Errors
            .Where(e => e.PropertyName.StartsWith(prefixo) || e.PropertyName == "")
            .Select(e => e.ErrorMessage)
            .ToList();

        return new DocumentoRespostaDto(){Id= doc.Id, Status = errosDoDoc.Count != 0 ? "INVALIDO" : "VALIDO", Erros = errosDoDoc};
    }
}