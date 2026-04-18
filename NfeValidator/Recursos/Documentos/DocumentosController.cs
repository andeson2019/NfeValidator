using Microsoft.AspNetCore.Mvc;
using NfeValidator.Recursos.Documentos.Dto;
using NfeValidator.Recursos.Documentos.Service;

namespace NfeValidator.Recursos.Documentos;

[ApiController]
[Route("/api/v1/[controller]")]
public class DocumentosController(IDocumentoService documentoService) : Controller
{
    
    [HttpPost]
    public async Task<IActionResult> ValidarLote([FromBody] LoteEntradaDto? lote)
    {
        if (lote == null) return BadRequest();
        var resultado = await documentoService.ProcessarLoteAsync(lote);
        return Ok(resultado);
    }
}