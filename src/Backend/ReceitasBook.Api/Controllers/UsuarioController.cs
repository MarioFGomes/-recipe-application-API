using Microsoft.AspNetCore.Mvc;
using ReceitasBook.Application.UseCase.Usuario;
using ReceitasBook.Comunicacao.Request.Usuario;
using ReceitasBook.Comunicacao.Response.Login;
using ReceitasBook.Comunicacao.Response.Usuario;

namespace ReceitasBook.Api.Controllers;

public class UsuarioController: ReceitasBookController
{

    [HttpPost("create")]
    [ProducesResponseType(typeof(ResponseRegistrarUsuario), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromServices] IRegistrarUsuarioUseCase _registrarUsuarioUseCase, [FromBody] RequestRegistrarUsuario request)
    {
        var token= await _registrarUsuarioUseCase.Execute(request);

       return Created(string.Empty, token);
    }
}
