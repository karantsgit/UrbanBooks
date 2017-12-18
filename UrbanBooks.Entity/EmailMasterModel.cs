using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UrbanBooks.Common;


namespace UrbanBooks.Entity
{
    public class EmailMasterModel
    {
        public int EmailId { get; set; }

        [Required(ErrorMessage = "Language is Required.")]
        [Display(Name = "Language")]
        public int LanguageId { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "The Email address is not valid")]
        public string Email { get; set; }
        public int UserId { get; set; }
        public string LanguageName { get; set; }
    }
}
