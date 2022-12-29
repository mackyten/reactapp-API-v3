using Application.DTOs.UserDTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IUserRepository
    {
        public Task<SignUpResultsDTO> CreateUser(SignUpCredentialsDTO signUpCredentialsDTO);

        public Task<SignInResultDTO> SignIn(SignInCredentialsDTO signInCredentials);
    }
}
