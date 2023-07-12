using AutoMapper;
using ReceitasBook.Application.Service.Criptografia;
using ReceitasBook.Application.Service.JWT;
using ReceitasBook.Comunicacao.Request;
using ReceitasBook.Comunicacao.Response.Usuario;
using ReceitasBook.Domain.Entity;
using ReceitasBook.Domain.Repository;
using ReceitasBook.Exceptions;
using ReceitasBook.Exceptions.ExceptionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasBook.Application.UseCase.Usuario
{
    public class RegistrarUsuarioUseCase: IRegistrarUsuarioUseCase
    {
        private readonly IUsuarioWriteOnlyRepository _usuarioWriteOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioReadOnlyRepository _usuarioReadOnlyRepository;
        private readonly EncriptadorPassword _encriptador;
        private readonly TokenController _Token;

        public RegistrarUsuarioUseCase(IUsuarioWriteOnlyRepository usuarioWriteOnlyRepository,IMapper mapper, IUnitOfWork unitOfWork, EncriptadorPassword encriptadorPassword, IUsuarioReadOnlyRepository usuarioReadOnlyRepository, TokenController tokenController)
        {
            _usuarioWriteOnlyRepository = usuarioWriteOnlyRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _encriptador = encriptadorPassword;
            _usuarioReadOnlyRepository = usuarioReadOnlyRepository;
            _Token = tokenController;

        }

        public async Task<ResponseRegistrarUsuario> Execute(RequestRegistrarUsuario request)
        {
           await  Validar(request);
            var user = _mapper.Map<ReceitasBook.Domain.Entity.Usuario>(request);

            user.Password = _encriptador.Criptografar(request.Password);

            await _usuarioWriteOnlyRepository.Adicionar(user);

            await _unitOfWork.Commit();

            var token = _Token.GerarToken(user.Name, user.Email);

            return new ResponseRegistrarUsuario
            {
                Token = token
            };

        }

        private async Task Validar(RequestRegistrarUsuario request)
        {
            var validator = new RegistrarUsuarioValidator();
            var result = validator.Validate(request);

            var UserDuplicate = await _usuarioReadOnlyRepository.ExisteUsuarioComEmail(request.Email);

            if (UserDuplicate)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure("Username", ResourceMessageError.Email_Já_Registrado));
            }

            if (!result.IsValid)
            {
                var ErrorMessage = result.Errors.Select(error =>error.ErrorMessage).ToList();

                throw new ValidationErrorEceptions(ErrorMessage);
            }
        }
    }
}
