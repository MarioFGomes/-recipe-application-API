using ReceitasBook.Comunicacao.Request.Login;
using ReceitasBook.Comunicacao.Response.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Application.UseCase.Login;

public interface ILoginUseCase
{
    Task<ResponseLoginJson> Execute(RequestLoginJson requisicao);
}
