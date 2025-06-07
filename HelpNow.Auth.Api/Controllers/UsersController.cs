using HelpNow.Auth.Domain.Dtos;
using HelpNow.Auth.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HelpNow.Auth.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;


    [HttpPost]
    [Route("criar-usuario")]
    public async Task<IActionResult> CriarUsuario([FromBody] UserRegisterDto dto)
    {
        await _userService.CriarUsuarioAsync(dto);
        return Created("", new { message = "Usuário criado com sucesso!" });
    }

    [HttpPost]
    [Route("logar")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
    {
        var token = await _userService.AuthenticateAsync(loginDto);
        if (token == null)
            return Unauthorized("Email ou senha inválidos.");

        return Ok(new { Token = token });
    }

    [HttpGet]
    [Route("validar-token")]
    [Authorize]
    public IActionResult ValidateToken()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        return Ok(new { valid = true, email });
    }
}
