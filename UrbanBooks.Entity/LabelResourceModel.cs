using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanBooks.Entity
{
    public class LabelResourceModel
    {
        public int ResourceId { get; set; }

        [Required(ErrorMessage = "Label key is Required.")]
        [Display(Name = "Label Key")]
        public int LabelId { get; set; }

        [Required(ErrorMessage = "Language is Required.")]
        [Display(Name = "Language")]
        public string LanguageCode { get; set; }

        [Required(ErrorMessage = "Resource Value is Required.")]
        [Display(Name = "Resource Value")]
        public string ResourceValue { get; set; }
        public int UserId { get; set; }
        public string LabelKey { get; set; }
        public string LanguageName { get; set; }
    }
    public class LabelModel
    {
        public int LabelId { get; set; }

        [Required(ErrorMessage = "Label key is Required.")]
        [Display(Name = "Label Key")]
        public string LabelKey { get; set; }
        public int UserId { get; set; }
    }
}
