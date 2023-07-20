using ReceitasBook.Comunicacao.Request.Usuario;
using ReceitasBook.Comunicacao.Response.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Application.UseCase.Usuario;

public interface IRegistrarUsuarioUseCase
{
    Task<ResponseRegistrarUsuario> Execute(RequestRegistrarUsuario user);
}
