using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UrbanBooks.Common;

namespace UrbanBooks.Entity
{
    public class EmailLogModel
    {
        public string ToEmail { get; set; }
        public string EmailBody { get; set; }
        public string EmailSubject { get; set; }
        public string CcEmail { get; set; }
    }
}
