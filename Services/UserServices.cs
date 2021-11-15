using LoginManagemet.DataContext;
using LoginManagemet.DataContext.DTOs;
using LoginManagemet.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace LoginManagemet.Services
{
    public class UserServices
    {
        private readonly LoginContext _loginContext;
        private readonly SecurityHelper _securityHelper;

        public UserServices(LoginContext loginContext, SecurityHelper securityHelper)
        {
            this._loginContext = loginContext;
            this._securityHelper = securityHelper;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            IEnumerable<User> usersDb = _loginContext.Users.ToList();
            IEnumerable<Role> roleDb = _loginContext.Roles.ToList();

            List<UserDTO> returnList = new List<UserDTO>();

            foreach (var user in usersDb)
            {
                var addUser = new UserDTO()
                {
                    AccountName = user.AccountName,
                    Name = user.Name,
                    Surname = user.Surname,
                    Email = user.Email,
                    RoleId = user.RoleId,
                    IsEnable = user.IsEnable,
                    Id = user.Id
                };
                foreach (var role in roleDb)
                {
                    if (user.RoleId == role.Id)
                    {
                        addUser.RoleName = role.Description;
                    }                    
                }
                returnList.Add(addUser);
            }
            return returnList;
        }

        public User GetUser(int userId)
        {
            User user = _loginContext.Users.Single(s =>s.Id == userId);
            return user;
        }

        public User GetUserByEmail(string email)
        {
            User user = _loginContext.Users.Single(s => s.Email == email);
            return user;
        }

        public void AddUser(UserDTO userDTO)
        {
            try
            {
                var encodedPassword = _securityHelper.encodePassword(userDTO.Password);
                User newUser = new User()
                {
                    AccountName = userDTO.Name,
                    Name = userDTO.Name,
                    Surname = userDTO.Surname,
                    Password = encodedPassword,
                    Email = userDTO.Email,
                    RoleId = userDTO.RoleId,
                    IsEnable = true
                };

                _loginContext.Users.Add(newUser);
                _loginContext.SaveChanges();
            }
            catch (Exception e)
            {

            }

        }

        public void EditUser(UserDTO userDTO)
        {
            try
            {
                User editUser = _loginContext.Users.Single(s => s.Email == userDTO.Email);

                editUser.Name = userDTO.AccountName;
                editUser.Surname = userDTO.AccountName;

                if (!string.IsNullOrEmpty(userDTO.Password) && !string.IsNullOrWhiteSpace(userDTO.Password))
                {
                    var encodedPassword = _securityHelper.encodePassword(userDTO.Password);
                    editUser.Password = encodedPassword;
                }

                _loginContext.Users.Update(editUser);
                _loginContext.SaveChanges();
            }
            catch (Exception e)
            {

            }

        }

        public void DeleteUser(int idUser)
        {
            try
            {
                User deleteUser = _loginContext.Users.Single(s => s.Id == idUser);
                _loginContext.Users.Remove(deleteUser);
                _loginContext.SaveChanges();
            }
            catch (Exception e)
            {
                var a = e;
            }

        }
    }
}
