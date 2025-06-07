using HelpNow.Auth.Domain.Dtos;
using HelpNow.Auth.Domain.Interfaces;
using HelpNow.Auth.Domain.Models;
using BCrypt.Net;

namespace HelpNow.Auth.Application.Services;
public class UserService(IUserRepository userRepository,
                         IJwtService jwtService) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtService _jwtService = jwtService;
    public async Task CriarUsuarioAsync(UserRegisterDto dto)
    {
        var user = new UserModel
        {
            Nome = dto.Nome,
            Email = dto.Email,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
            DtCriacao = DateTime.Now,
            DtAtualizacao = DateTime.Now,
            TpAcesso = dto.TpAcesso
        };

        await _userRepository.AdicionarUsuarioAsync(user);
    }

    public async Task<string?> AuthenticateAsync(UserLoginDto loginDto)
    {

        var usuario = await _userRepository.ObterUserPorEmailAsync(loginDto.Email);

        if (usuario == null)
        {
            return null;
        }
            
        bool senhaValida = BCrypt.Net.BCrypt.Verify(loginDto.Senha, usuario.SenhaHash);
        if (!senhaValida)
        {
            return null;
        }
     
        var token = _jwtService.GenerateToken(usuario);

        return token;
    }
}
