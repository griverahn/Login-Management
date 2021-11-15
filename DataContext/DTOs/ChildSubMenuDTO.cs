using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.DataContext.DTOs
{
    public class ChildSubMenuDTO
    {
        [Display(Name = "Child Id")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Subcategory Id")]
        public int Subcategory_id { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Reference")]
        public string Reference { get; set; }

    }
}
