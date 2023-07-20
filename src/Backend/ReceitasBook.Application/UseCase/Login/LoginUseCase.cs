using ReceitasBook.Application.Service.Criptografia;
using ReceitasBook.Application.Service.JWT;
using ReceitasBook.Comunicacao.Request.Login;
using ReceitasBook.Comunicacao.Response.Login;
using ReceitasBook.Domain.Repository;
using ReceitasBook.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Application.UseCase.Login;

public class LoginUseCase: ILoginUseCase
{
    private readonly EncriptadorPassword _encriptadorDeSenha;
    private readonly TokenController _tokenController;
    private readonly IUsuarioReadOnlyRepository _UsuarioReadOnlyRepositorio;

    public LoginUseCase(IUsuarioReadOnlyRepository usuarioReadOnlyRepositorio, EncriptadorPassword encriptadorDeSenha, TokenController tokenController)
    {
        _UsuarioReadOnlyRepositorio = usuarioReadOnlyRepositorio;
        _encriptadorDeSenha = encriptadorDeSenha;
        _tokenController = tokenController;
    }
    public async Task<ResponseLoginJson> Execute(RequestLoginJson requisicao)
    {
        var senhaCriptografada = _encriptadorDeSenha.Criptografar(requisicao.Senha);
        var usuario = await _UsuarioReadOnlyRepositorio.Login(requisicao.Email, senhaCriptografada);

        if (usuario == null)
        {
            throw new LoginInvalidoException();
        }
        return new ResponseLoginJson
        {
            Nome = usuario.Name,
            Token = _tokenController.GerarToken(usuario.Name, usuario.Email)
        };
    }
}
