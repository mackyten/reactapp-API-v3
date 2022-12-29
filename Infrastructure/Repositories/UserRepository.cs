using Application.Contracts;
using Application.DTOs.UserDTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<SignUpResultsDTO> CreateUser(SignUpCredentialsDTO signUpCredentialsDTO)
        {
            User new_user = new User();
            SignUpResultsDTO result = new SignUpResultsDTO();

            using (var db = new AppDbContext())
            {
                try
                {
                    new_user.DateCreated = DateTime.Now;
                    new_user.FirstName = signUpCredentialsDTO.Firstname;
                    new_user.LastName = signUpCredentialsDTO.Lastname;
                    new_user.Email = signUpCredentialsDTO.Email;
                    new_user.Password = signUpCredentialsDTO.Password;

                    await db.Users.AddAsync(new_user);

                    result.Email = signUpCredentialsDTO.Email;
                    result.JWT = "123";
                    result.Result = "Successful";

                    db.SaveChanges();


                    return result;
                }
                catch (Exception)
                {

                    result.Email = signUpCredentialsDTO.Email;
                    result.JWT = "123";
                    result.Result = "Unsuccessful";

                    return result;
                }
            }
        }
    }
}
