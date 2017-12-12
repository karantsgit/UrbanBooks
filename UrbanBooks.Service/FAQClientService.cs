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
    public class FAQClientService
    {
        public List<FAQModel> GetFAQList(string LanguageId)
        {
            GenericRepository<FAQModel> objGenericRepository = new GenericRepository<FAQModel>();
            List<FAQModel> list = new List<FAQModel>();
            try
            {
                list = objGenericRepository.QuerySQL<FAQModel>("sp_GetFAQListForClient", Utility.GetSQLParam("LanguageId", SqlDbType.VarChar, LanguageId)).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
