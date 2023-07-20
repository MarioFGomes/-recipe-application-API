using Microsoft.AspNetCore.Mvc;
using ReceitasBook.Application.UseCase.Login;
using ReceitasBook.Comunicacao.Request.Login;
using ReceitasBook.Comunicacao.Response.Login;

namespace ReceitasBook.Api.Controllers;

public class LoginController: ReceitasBookController
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseLoginJson), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromServices] ILoginUseCase usecase, [FromBody] RequestLoginJson requisicao)
    {
        var resposta = await usecase.Execute(requisicao);
        return Ok(resposta);
    }
}
