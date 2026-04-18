using NfeValidator.Recursos.Documentos.Dto;

namespace NfeValidator.Recursos.Documentos.Service;

public interface IDocumentoService
{
    Task<LoteRespostaDto> ProcessarLoteAsync(LoteEntradaDto lote);
}