using Microsoft.AspNetCore.Mvc;
using UserApi.Application.DTO;
using UserApi.Application.Services;

namespace UserApi.Controller;
[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpPost]
    public ActionResult<UserResponseDTO> Create([FromBody] UserRequestDTO request)
    {
        try
        {
            var user = _service.CreateUser(request);
            return CreatedAtAction(nameof(Create), new { id = user.Id }, user);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }

    [HttpGet("{id:guid}")]
    public ActionResult<UserResponseDTO> GetUserById(Guid id)
    {
        var user = _service.GetUserById(id);
        return Ok(user);
    }

    [HttpGet]
    public ActionResult<UserResponseDTO> GetAllUsers()
    {
        var users = _service.GetAllUsers();
        return Ok(users);
    }


    [HttpPut("{id:guid}")]
    public ActionResult<UserResponseDTO> UpdateUser( [FromRoute]Guid id, [FromBody]UserRequestDTO request)
    {
        try
        {
            var user = _service.UpdateUser(id, request);
            return Ok(user);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }


    [HttpPatch("{id:guid}")]
    public ActionResult<UserResponseDTO> PatchUser([FromRoute] Guid id, [FromBody] UserPatchDTO request)
    {
        try
        {
            var user = _service.Patch(id, request);
            return Ok(user);
        }

        catch (KeyNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }

        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }


    [HttpDelete]
    public ActionResult<UserResponseDTO> DeleteUser(Guid id)
    {
        var user = _service.GetUserById(id);
        if (user is null)
            return NotFound(new { message = ("User not found") });

        _service.DeleteUser(id);
        return Ok(user);
    }
}