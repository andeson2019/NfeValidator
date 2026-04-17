using NfeValidator.Domain.Documento.Dto;

namespace NfeValidator.Domain.Documento.Service;

public interface IDocumentoService
{
    Task<LoteRespostaDto> ProcessarLoteAsync(LoteEntradaDto lote);
}