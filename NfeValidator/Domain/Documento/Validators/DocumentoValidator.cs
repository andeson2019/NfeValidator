using FluentValidation;
using NfeValidator.Domain.Documento.Dto;

namespace NfeValidator.Domain.Documento.Validators;

public class DocumentoValidator : AbstractValidator<DocumentoDto>
{
    public DocumentoValidator()
    {
        RuleFor(x => x.Tipo)
            .Must(t => t is "NFE")
            .WithMessage("tipo deve ser igual a NFE");

        RuleFor(x => x.Numero).NotEmpty().WithMessage("numero nao pode ser vazio");
        RuleFor(x => x.Serie).NotEmpty().WithMessage("serie nao pode ser vazia");
        RuleFor(x => x.Valor).GreaterThan(0).WithMessage("valor deve ser maior que zero");

        RuleFor(x => x.CnpjEmitente)
            .Matches(@"^\d{14}$").WithMessage("cnpjEmitente deve conter 14 dígitos numéricos");

        RuleFor(x => x.CnpjDestinatario)
            .Matches(@"^\d{14}$")
            .When(x => !string.IsNullOrEmpty(x.CnpjDestinatario))
            .WithMessage("cnpjDestinatario deve conter 14 dígitos numéricos");

        RuleFor(x => x.DataEmissao)
            .NotEmpty().WithMessage("dataEmissao deve ser uma data válida");
    }
}