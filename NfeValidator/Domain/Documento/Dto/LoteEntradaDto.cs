namespace NfeValidator.Domain.Documento.Dto;

public class LoteEntradaDto(string loteId, List<DocumentoDto> documentos)
{
    public string LoteId { get; set; } = loteId;
    public List<DocumentoDto> Documentos { get; set; } = documentos;
}