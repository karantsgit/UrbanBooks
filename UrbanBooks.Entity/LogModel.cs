using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UrbanBooks.Common;

namespace UrbanBooks.Entity
{
    public class LogModel
    {
        public int LogId { get; set; }
        public string Referrer { get; set; }
        public string IPAddress { get; set; }
        public string FormFilled { get; set; }
        public string PaymentFilled { get; set; }
        public string VisitedStart { get; set; }
        public string VisitedEnd { get; set; }
        public string VisitedDifferent { get; set; }
    }
}
