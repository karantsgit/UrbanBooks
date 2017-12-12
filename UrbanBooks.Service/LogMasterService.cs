using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanBooks.Entity;
using UrbanBooks.Data.Repository;
using System.Data;
using UrbanBooks.Common;
namespace UrbanBooks.Service
{
    public class LogMasterService
    {
        public List<LogModel> GetLogMasterList(string IPAddress = null, string FromDate = null, string ToDate = null)
        {
            GenericRepository<LogModel> objGenericRepository = new GenericRepository<LogModel>();
            List<LogModel> list = new List<LogModel>();
            try
            {
                list = objGenericRepository.QuerySQL<LogModel>("sp_LogMasterList", Utility.GetSQLParam("IPAddress", SqlDbType.VarChar, (object)IPAddress ?? DBNull.Value),
                    Utility.GetSQLParam("FromDate", SqlDbType.VarChar, (object)FromDate ?? DBNull.Value),
                    Utility.GetSQLParam("ToDate", SqlDbType.VarChar, (object)ToDate ?? DBNull.Value)
                    ).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
