using LoginManagemet.DataContext;
using LoginManagemet.DataContext.DTOs;
using LoginManagemet.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.Services
{
    public class AccessServices
    {
        private readonly LoginContext _loginContext;

        public AccessServices(LoginContext loginContext)
        {
            this._loginContext = loginContext;
        }

        public IEnumerable<RoleAccessDTO> GetPermissionsByRole(int roleId)
        {

            IEnumerable<RoleAccess> permissionsDb = _loginContext.RoleAccess.Where(c => c.RoleId == roleId).ToList();

            var returnList = new List<RoleAccessDTO>();

            foreach (var access in permissionsDb)
            {
                var addPermission = new RoleAccessDTO()
                {
                    RoleId = access.RoleId,
                    LevelOptionId = access.LevelOptionId,
                    LevelName = access.LevelName
                                        
                };
                returnList.Add(addPermission);
            }
            return returnList;
        }

        public void DeletePermissionsByRole(int roleId)
        {
            IEnumerable<RoleAccess> permissionsDb = _loginContext.RoleAccess.Where(c => c.RoleId == roleId).ToList();

            _loginContext.RoleAccess.RemoveRange(permissionsDb);
            _loginContext.SaveChanges();

        }

        public void AddPermission(RoleAccessDTO userPermissionsDTO)
        {
            var newAccess = new RoleAccess()
            {
                RoleId = userPermissionsDTO.RoleId,
                LevelName = userPermissionsDTO.LevelName,
                LevelOptionId = userPermissionsDTO.LevelOptionId
            };

            _loginContext.RoleAccess.Add(newAccess);
            _loginContext.SaveChanges();

        }

    }
}
