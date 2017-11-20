using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanBooks.Common;
using UrbanBooks.Data.Repository;
using UrbanBooks.Entity;

namespace UrbanBooks.Service
{
    public class DashboardService
    {
        public List<LanguageModel> GetLanguageList()
        {
            GenericRepository<LanguageModel> objGenericRepository = new GenericRepository<LanguageModel>();
            return objGenericRepository.QuerySQL<LanguageModel>("GetLanguageList").ToList();
        }

        public List<ResourceModel> GetResourceList(string LanguageCode)
        {
            GenericRepository<ResourceModel> objGenericRepository = new GenericRepository<ResourceModel>();
            return objGenericRepository.QuerySQL<ResourceModel>("GetResourceList", Utility.GetSQLParam("LanguageCode", System.Data.SqlDbType.VarChar, LanguageCode)).ToList();
            //List<ResourceModel> listCustomerModel = new List<ResourceModel>();
            //listCustomerModel = objGenericRepository.QuerySQL<ResourceModel>("GetResourceList", LanguageCode).ToList();
            //return listCustomerModel;
        }
    }
}
