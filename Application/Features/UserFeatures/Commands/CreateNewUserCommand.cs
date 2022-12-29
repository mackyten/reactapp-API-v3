using Application.Contracts;
using Application.DTOs.UserDTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands
{
    public class CreateNewUserCommand
    {
        IUserRepository _userRepository;

        public CreateNewUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<SignUpResultsDTO> CreateNewUser(SignUpCredentialsDTO signUpCredentialsDTO)
        {
            var result = await _userRepository.CreateUser(signUpCredentialsDTO);
            return result;

        }
    }
}
