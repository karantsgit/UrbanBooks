using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanBooks.Common
{
    public class Enums
    {
        public enum NotifyType
        {
            [Description("Success Message")]
            SuccessMessage = 1,

            [Description("Error Message")]
            ErrorMessage = 2,

            [Description("Warning Message")]
            WarningMessage = 3,

            [Description("System Error Message")]
            SystemErrorMessage = 4
        }
    }
}
