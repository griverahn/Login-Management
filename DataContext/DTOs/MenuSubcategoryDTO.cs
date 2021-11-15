using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.DataContext.DTOs
{
    public class MenuSubcategoryDTO
    {
  
        [Display(Name = "Subcategory Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Subcategory")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Enable")]
        public bool IsEnable { get; set; }      
        [Display(Name = "Menu Id")]
        public int MenuOptionId { get; set; }

        [Display(Name = "Reference")]
        public string Reference { get; set; }


        public MenuOptionDTO MenuOption { get; set; }
        public List<ChildSubMenuDTO> ChildSubMenu { get; set; }
    }
}
