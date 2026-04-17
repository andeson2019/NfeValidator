namespace NfeValidator.Domain.Documento.Dto;

public class DocumentoRespostaDto
{
    public required string Id { get; set; }
    public required string Status { get; init; }
    public required List<string> Erros { get; set; }
}