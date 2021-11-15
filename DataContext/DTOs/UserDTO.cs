using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagemet.DataContext.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Account Name")]
        public string AccountName { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Role Id")]
        public int RoleId { get; set; }
        [Required]
        [Display(Name = "Enable")]
        public bool IsEnable { get; set; }

        [Display(Name = "User Roles")]
        public List<string> UserRoles { get; set; }


        [Display(Name = "Role Name")]
        public string RoleName { get; set; }


        [Display(Name = "Complete Name")]
        public string CompleteName()
        {
            return string.Concat(Name, ' ', Surname);
        }

        
    }
}
