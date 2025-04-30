using Microsoft.AspNetCore.Mvc;
using Application.DTOs;
using Application.Interfaces;

namespace Web.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var res = await userService.GetAllAsync();
        return Ok(res);
    }

    [HttpGet("UserId/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var res = await userService.GetAsync(id);
        return res.IsFailure ? NotFound(res) : Ok(res);
    }

    [HttpGet("UserEMail/{email}")]
    public async Task<IActionResult> Get(string email)
    {
        var res = await userService.GetAsync(email);
        return res.IsFailure ? NotFound(res) : Ok(res);
    }

    [HttpGet("UserName/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var res = await userService.GetByNameAsync(name);
        return res.IsFailure ? NotFound(res) : Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDto userDto)
    {
        var res = await userService.AddAsync(userDto);
        return Ok(res);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UserDto userDto)
    {
        userDto.Id = id;
        var res = await userService.UpdateAsync(userDto);
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(UserDto userDto)
    {
        var res = await userService.DeleteAsync(userDto);
        return Ok(res);
    }
}
