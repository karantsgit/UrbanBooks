﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanBooks.Common
{
    public class CommonHelper
    {
        public const string PleaseSelect = "---Select---";
        public const string DateFormat = "dd/MM/yyyy";
        public static readonly Dictionary<string, object> CenterColumnStyle = new Dictionary<string, object> { { "align", "center" }, { "style", "text-align:center;vertical-align:middle !important;" } };
        public static readonly Dictionary<string, object> LeftColumnStyle = new Dictionary<string, object> { { "align", "left" }, { "style", "text-align:left;vertical-align:middle !important;" } };
        public const int PazeSize = 50;
        public static IEnumerable<int> PageSizes = new[] { 10, 20, 50, 100 };
    }
}
