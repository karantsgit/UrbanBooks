using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UrbanBooks.Common;


namespace UrbanBooks.Entity
{
    public class FAQModel
    {
        public int FAQId { get; set; }

        
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Language is Required.")]
        [Display(Name = "Language")]
        public int LanguageId { get; set; }

        [Required(ErrorMessage = "Answer is Required.")]
        [Display(Name = "Answer")]
        public string Answer { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Question is Required.")]
        [Display(Name = "Question")]
        public string Question { get; set; }
        public string LanguageName { get; set; }
    }

    public class FAQQuestionModel
    {
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Question is Required.")]
        [Display(Name = "Question(ENG)")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Answer is Required.")]
        [Display(Name = "Answer(ENG)")]
        public string Answer { get; set; }
        public int UserId { get; set; }
    }

    public class FAQCLientModel
    {
        public List<FAQModel> FAQList { get; set; }
    }
}
