using Microsoft.AspNetCore.Mvc;
using ReceitasBook.Application.UseCase.Usuario;
using ReceitasBook.Comunicacao.Request;

namespace ReceitasBook.Api.Controllers;
[Route("api/user")]
public class UsuarioController:ControllerBase
{

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromServices] IRegistrarUsuarioUseCase _registrarUsuarioUseCase, [FromBody] RequestRegistrarUsuario request)
    {
        var token= await _registrarUsuarioUseCase.Execute(request);

       return Ok(token);
    }
}
