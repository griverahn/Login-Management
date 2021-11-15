using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.DataContext.Entities
{
    public class MenuSubcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnable { get; set; }
        public int MenuOptionId { get; set; }
        public string Reference { get; set; }

        public virtual MenuOption MenuOption { get; set; }
        public virtual List<ChildSubMenu> ChildSubMenu { get; set; }
    }
}
