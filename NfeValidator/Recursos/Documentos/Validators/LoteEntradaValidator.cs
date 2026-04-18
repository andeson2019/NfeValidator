using FluentValidation;
using NfeValidator.Recursos.Documentos.Dto;

namespace NfeValidator.Recursos.Documentos.Validators;

public class LoteEntradaValidator : AbstractValidator<LoteEntradaDto>
{
    public LoteEntradaValidator()
    {
        RuleFor(x => x.LoteId)
            .NotEmpty().WithMessage("LoteId é obrigatório.");

        // 1. Valida cada documento individualmente 
        RuleForEach(x => x.Documentos)
            .SetValidator(new DocumentoValidator());

        // 2. Valida duplicidade dentro da lista
        // O primeiro parâmetro do Must é o objeto Raiz (LoteEntradaDto)
        // O segundo parâmetro é a lista
        RuleForEach(x => x.Documentos)
            .Must((lote, documentoAtual) =>
            {
                var duplicados = lote.Documentos.Count(d =>
                    d.Tipo == documentoAtual.Tipo &&
                    d.CnpjEmitente == documentoAtual.CnpjEmitente &&
                    d.Serie == documentoAtual.Serie &&
                    d.Numero == documentoAtual.Numero);

                return duplicados <= 1;
            })
            .WithMessage("duplicidade detectada para a combinação tipo, cnpjEmitente, serie e numero");
    }
}