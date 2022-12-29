using Application.DTOs.UserDTO;
using Application.Features.UserFeatures.Commands;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        CreateNewUserCommand _createNewUser;
        SignInUserCommand _signInUser;
        

        public UserController(CreateNewUserCommand createNewUser, SignInUserCommand signInUser)
        {
            _createNewUser = createNewUser;
            _signInUser = signInUser;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpCredentialsDTO credentials)
        {

            var result = await _createNewUser.CreateNewUser(credentials);
            Debug.WriteLine("+++++++++++++++++++++");
            Debug.WriteLine(result.JWT);

            if (result.JWT != null)
            {
                SignUpResultsDTO currentUser = new SignUpResultsDTO();

                currentUser.JWT = result.JWT;
                currentUser.Email = result.Email;
                currentUser.Firstname = credentials.Firstname;
                currentUser.Lastname = credentials.Lastname;

                return Ok(currentUser);
            }
            else {
                return BadRequest();
            }
        }

        [HttpPost("SigIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInCredentialsDTO credentials) { 
            var result = await _signInUser.SignInUser(credentials);
            if (result.JWT != null)
            {
                return Ok(result);
            }
            else {
                return NotFound(result);
            }
        }
    }
}
