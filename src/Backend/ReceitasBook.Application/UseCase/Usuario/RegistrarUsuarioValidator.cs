
using FluentValidation;
using ReceitasBook.Comunicacao.Request;
using ReceitasBook.Exceptions;
using System.Text.RegularExpressions;

namespace ReceitasBook.Application.UseCase.Usuario;

public class RegistrarUsuarioValidator: AbstractValidator<RequestRegistrarUsuario>
{

    public RegistrarUsuarioValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage(ResourceMessageError.Nome_Vazio);
        RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceMessageError.Email_Usuario_Embranco);
        RuleFor(c => c.Password).NotEmpty().WithMessage(ResourceMessageError.SENHA_EMBRANCO);
        RuleFor(c => c.Telefone).NotEmpty().WithMessage(ResourceMessageError.TELEFONE_EMBRANCO);
        When(c => !string.IsNullOrEmpty(c.Email), () => {
            RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMessageError.Email_INVALIDO);
        });
        When(c => !string.IsNullOrEmpty(c.Password), () =>
        {
            RuleFor(c => c.Password).MinimumLength(6).WithMessage(ResourceMessageError.SENHA_INVALIDA);
        });
        When(c => !string.IsNullOrEmpty(c.Telefone), () =>
        {
            RuleFor(c => c.Telefone).Custom((telefone,context) =>
            {
                string padraotelefone = "[0-9]{3} [0-9]{3}-[0-9]{3}-[0-9]{3}";
                var isMatch=Regex.IsMatch(telefone, padraotelefone);
                if (!isMatch)
                {
                    context.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(telefone), ResourceMessageError.TELEFONE_INVALIDO)); 
                }
            });
        });
    }
}
