using LoginManagemet.DataContext;
using LoginManagemet.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.Services
{
    public class RoleServices
    {
        private readonly LoginContext _loginContext;

        public RoleServices(LoginContext loginContext)
        {
            this._loginContext = loginContext;
        }

        public IEnumerable<Role> GetAll()
        {
            IEnumerable<Role> roles = _loginContext.Roles.ToList();
            return roles;
        }

    }
}
