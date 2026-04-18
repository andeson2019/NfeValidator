namespace NfeValidator.Recursos.Documentos.Dto;

public class DocumentoRespostaDto
{
    public required string Id { get; set; }
    public required string Status { get; init; }
    public required List<string> Erros { get; set; }
}