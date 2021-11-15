using LoginManagemet.DataContext;
using LoginManagemet.DataContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.Services
{
    public class MenuServices
    {
        private readonly LoginContext _loginContext;

        public MenuServices(LoginContext loginContext)
        {
            this._loginContext = loginContext;
        }

        public IEnumerable<MenuOption> GetMenuOptions()
        {
            return _loginContext.MenuOptions.ToList();
        }

        public IEnumerable<MenuSubcategory> GetSubcategory(int optionId)
        {
            return _loginContext.MenuSubcategories.Where(s => s.MenuOptionId == optionId).ToList();
        }

        public IEnumerable<ChildSubMenu> GetSubcategoryChild(int subCategoryId)
        {
            return _loginContext.ChildSubMenu.Where(s => s.Subcategory_id == subCategoryId).ToList();
        }
    }
}
