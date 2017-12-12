using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UrbanBooks.Common;

namespace UrbanBooks.Entity
{
    public class UsersModel
    {
        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "FirstNameRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "FirstNameInvalid")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "LastNameRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "LastNameInvalid")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "EmailAddressRequired")]
        [RegularExpression(RegularExpression.RegExEmail, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "EmailInvalid")]
        [StringLength(100, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "EmailInvalid")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PasswordRequired")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PasswordInvalid")]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MobileNoRequired")]
        [Display(Name = "Mobile No")]
        [RegularExpression(RegularExpression.RegExTelephone, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MobileNoInvalid")]
        [StringLength(20, ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "MobileNoInvalid")]
        public string MobileNo { get; set; }

        [Display(Name = "Messengers")]
        public string Messangers { get; set; }




        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "ReportingToRequired")]
        [Display(Name = "Reporting To")]
        public int ReportingTo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "RoleRequired")]
        [Display(Name = "Role")]
        public Byte RoleId { get; set; }


        public string RoleName { get; set; }
        public string OldPassword { get; set; }

        public Byte Status { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }

        [Display(Name = "Remember Me")]
        [UIHint("checkbox")]
        public bool RememberMe { get; set; }
        public string Key { get; set; }
        public DateTime? EndDate { get; set; }

        public int TotalRecords { get; set; }
    }


    public class UserSessionDetailsModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
