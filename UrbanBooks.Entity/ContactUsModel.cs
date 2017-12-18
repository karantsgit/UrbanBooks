using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UrbanBooks.Common;

namespace UrbanBooks.Entity
{
    public class ContactUsModel
    {
        public int LanguageId { get; set; }

        [Required(ErrorMessage = "Name is Required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress(ErrorMessage = "The Email address is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is Required.")]
        public string Message { get; set; }
    }
}
