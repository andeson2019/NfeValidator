namespace NfeValidator.Recursos.Documentos.Dto;

public class DocumentoDto
{
    public string? Id { get; set; }
    public string? Tipo { get; init; }
    public string? Numero { get; set; }
    public string? Serie { get; set; }
    public decimal? Valor { get; init; }
    public string? CnpjEmitente { get; init; }
    public string? CnpjDestinatario { get; init; }
    public DateTime DataEmissao { get; set; }
}