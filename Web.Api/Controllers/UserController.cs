using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;

namespace Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _userService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var res = await _userService.GetByIdAsync(id);
        return res is null ? NotFound() : Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDto userDto)
    {
        var res = await _userService.AddAsync(userDto);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UserDto userDto)
    {
        userDto.Id = id;
        var res = await _userService.UpdateAsync(userDto);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var res = await _userService.DeleteAsync(id);
        return Ok(res);
    }
}
