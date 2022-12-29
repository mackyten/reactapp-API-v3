using Application.Contracts;
using Application.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class SignInUserCommand
    {
        IUserRepository _userRepository;

        public SignInUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<SignInResultDTO> SignInUser(SignInCredentialsDTO credentials)
        {
            var result = await _userRepository.SignIn(credentials);
            return result;

        }
    }
}
