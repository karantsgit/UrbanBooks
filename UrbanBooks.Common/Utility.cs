using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UrbanBooks.Common
{
    public class Utility
    {
        public static SqlParameter GetSQLParam(string paramName, SqlDbType type, dynamic value)
        {
            SqlParameter sqlParam = new SqlParameter(paramName, type);
            sqlParam.Value = value ?? (object)DBNull.Value;
            return sqlParam;
        }

        public static SqlParameter GetSQLParam(string paramName, SqlDbType type, dynamic value, [Optional] string typeName)
        {
            SqlParameter sqlParam = new SqlParameter(paramName, type);
            sqlParam.Value = value;
            if (typeName != null)
            {
                sqlParam.TypeName = typeName;
            }
            return sqlParam;
        }

        public static string GetSortOrder(string SortBy, string SortDirection)
        {
            return SortBy + " " + (SortDirection.ToLower() == "descending" ? "DESC" : "");
        }

        public static string GetResourceValue(string labelKey)
        {
            var resourceKey = SessionHelper.SelectedLanguageResource.FirstOrDefault(m => m.LabelKey == labelKey);
            if (resourceKey == null)
            {
                resourceKey = SessionHelper.SelectedLanguageResource.FirstOrDefault(m => m.LabelKey == "eng");
            }
            return resourceKey.ResourceValue;
        }
    }
}
