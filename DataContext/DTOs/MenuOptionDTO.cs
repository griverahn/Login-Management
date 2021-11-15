using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.DataContext.DTOs
{
    public class MenuOptionDTO
    {
        [Display(Name = "Menu Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Menu Option")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Account Name")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Enable")]
        public bool IsEnable { get; set; }

        [Display(Name = "Reference")]
        public string Reference { get; set; }


        public List<MenuSubcategoryDTO> MenuSubcategories { get; set; }
    }
}
