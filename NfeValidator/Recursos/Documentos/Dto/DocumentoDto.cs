namespace NfeValidator.Recursos.Documentos.Dto;

public class DocumentoDto
{
    public required string Id { get; set; }
    public required string Tipo { get; set; }
    public required string Numero { get; set; }
    public required string Serie { get; set; }
    public required decimal Valor { get; set; }
    public required string CnpjEmitente { get; set; }
    public required string CnpjDestinatario { get; set; }
    public required DateTime DataEmissao { get; set; }
}