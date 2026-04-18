namespace NfeValidator.Recursos.Documentos.Dto;

public class LoteRespostaDto
{
    public required string LoteId  { get; set; }
    public int TotalDocumentos { get; set; } 
    public int Validos { get; set; }
    public int Invalidos { get; set; }
    public List<DocumentoRespostaDto> Documentos { get; init; } = [];
}