using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.DataContext.Entities
{
    public class ChildSubMenu
    {
        public int Id { get; set; }
        public int Subcategory_id { get; set; }
        public string Description { get; set; }
        public virtual MenuSubcategory MenuOption { get; set; }
        public string Reference { get; set; }
    }
}
