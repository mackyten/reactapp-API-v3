using Application.Contracts;
using Application.DTOs.UserDTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Infrastructure.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
  
        IGenerateJWTToken _generateToken;

        public UserRepository(IGenerateJWTToken generateToken)
        { 
            _generateToken = generateToken;
        }

        public async Task<bool> CheckEmailIfExisting(string email) {
            var db = new AppDbContext();
            var user =  db.Users.FirstOrDefault(u => u.Email == email);


            if (user != null) {
                return false;
            }
            else{
                return true;
            }
        }

        public async Task<SignUpResultsDTO> CreateUser(SignUpCredentialsDTO signUpCredentialsDTO)
        {
            var db = new AppDbContext();
            SignUpResultsDTO result = new SignUpResultsDTO();

            result.Email = null;
            result.JWT = null;

            var isUnique = await CheckEmailIfExisting(signUpCredentialsDTO.Email);

            if (isUnique)
            {
                User new_user = new User();


                try
                {
                    new_user.DateCreated = DateTime.Now;
                    new_user.FirstName = signUpCredentialsDTO.Firstname;
                    new_user.LastName = signUpCredentialsDTO.Lastname;
                    new_user.Email = signUpCredentialsDTO.Email;
                    new_user.Password = signUpCredentialsDTO.Password;

                    var addingResult = await db.Users.AddAsync(new_user);

                    var saving_result = db.SaveChanges();

                    if (saving_result >= 1)
                    {
                        var token = _generateToken.Generate(new_user);

                        result.Email = signUpCredentialsDTO.Email;
                        result.JWT = token;
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
                catch (Exception)
                {
                    return result;
                }
            }
            else {
                return result;
            }            
        }

        public async Task<SignInResultDTO> SignIn(SignInCredentialsDTO signInCredentials)
        {
            SignInResultDTO signInResult = new SignInResultDTO();
            signInResult.JWT = null;

            var db = new AppDbContext();

            var result = db.Users.FirstOrDefault(u => u.Email == signInCredentials.Email && u.Password == signInCredentials.Password);

            try {

                if (result != null)
                {
                    var token =  _generateToken.Generate(result);
                    signInResult.JWT = token;
                    signInResult.Firstname = result.FirstName;
                    signInResult.Lastname = result.LastName;
                    signInResult.Email = result.Email;

            
                    return  signInResult;

                }
                else
                {
                    return  signInResult;
                }
            }
            catch (Exception) {
                return signInResult;
            
            }

        }
    }
}
