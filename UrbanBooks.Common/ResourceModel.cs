using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanBooks.Common
{
    public class ResourceModel
    {
        public int LabelId { get; set; }
        public string LabelKey { get; set; }
        public string LanguageCode { get; set; }
        public string ResourceValue { get; set; }
    }
}
