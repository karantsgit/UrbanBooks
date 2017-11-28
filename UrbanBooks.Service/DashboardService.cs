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

        public int SaveHeaderInformation(HeaderInformationModel model)
        {
            int Result = 0;
            GenericRepository<HeaderInformationModel> objGenericRepository = new GenericRepository<HeaderInformationModel>();

            Result = objGenericRepository.ExecuteSQL<int>("SaveLogInformation @Referrer,@IPAddress",
                 Utility.GetSQLParam("Referrer", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(model.Referrer) ? model.Referrer : (object)DBNull.Value),
                 Utility.GetSQLParam("IPAddress", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(model.IPAddress) ? model.IPAddress : (object)DBNull.Value)
                 ).FirstOrDefault();
            return Result;
        }

        public int UpdateFillOutFlag(int LogId)
        {
            int Result = 0;
            GenericRepository<HeaderInformationModel> objGenericRepository = new GenericRepository<HeaderInformationModel>();

            Result = objGenericRepository.ExecuteSQL<int>("UpdateFormFillOutFlag @LogId",
                 Utility.GetSQLParam("LogId", SqlDbType.Int, LogId)
                 ).FirstOrDefault();
            return Result;
        }

        public int UpdatePaymentFlag(int LogId)
        {
            int Result = 0;
            GenericRepository<HeaderInformationModel> objGenericRepository = new GenericRepository<HeaderInformationModel>();

            Result = objGenericRepository.ExecuteSQL<int>("UpdatePaymentFlag @LogId",
                 Utility.GetSQLParam("LogId", SqlDbType.Int, LogId)
                 ).FirstOrDefault();
            return Result;
        }

        public int UpdateVisitedEndTime(int LogId)
        {
            int Result = 0;
            GenericRepository<HeaderInformationModel> objGenericRepository = new GenericRepository<HeaderInformationModel>();

            Result = objGenericRepository.ExecuteSQL<int>("UpdateVisitedEndTime @LogId",
                 Utility.GetSQLParam("LogId", SqlDbType.Int, LogId)
                 ).FirstOrDefault();
            return Result;
        }

        public int SavePurchaseOrder(PurchaseModel model)
        {
            int Result = 0;
            GenericRepository<HeaderInformationModel> objGenericRepository = new GenericRepository<HeaderInformationModel>();

            Result = objGenericRepository.ExecuteSQL<int>("sp_SavePurchaseOrder @Name,@Address,@DeliveryAddress",
                 Utility.GetSQLParam("Name", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(model.Name) ? model.Name : (object)DBNull.Value),
                 Utility.GetSQLParam("Address", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(model.Address) ? model.Address: (object)DBNull.Value),
                 Utility.GetSQLParam("DeliveryAddress", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(model.DeliveryAddress) ? model.DeliveryAddress : (object)DBNull.Value)
                 ).FirstOrDefault();
            return Result;
        }
    }
}
