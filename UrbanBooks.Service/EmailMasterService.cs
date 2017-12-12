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
    public class EmailMasterService
    {
        public EmailMasterModel GetEmailMasterByEmailId(int EmailId)
        {
            GenericRepository<EmailMasterModel> objGenericRepository = new GenericRepository<EmailMasterModel>();
            EmailMasterModel Result = new EmailMasterModel();
            try
            {
                Result = objGenericRepository.ExecuteSQL<EmailMasterModel>("sp_GetEmailMasterByEmailId @EmailId",
                Utility.GetSQLParam("EmailId", SqlDbType.Int, EmailId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }


        public List<EmailMasterModel> GetEmailMasterList(int? Language = null)
        {
            GenericRepository<EmailMasterModel> objGenericRepository = new GenericRepository<EmailMasterModel>();
            List<EmailMasterModel> list = new List<EmailMasterModel>();
            try
            {
                list = objGenericRepository.QuerySQL<EmailMasterModel>("sp_EmailMasterList", Utility.GetSQLParam("Language", SqlDbType.VarChar, (object)Language ?? DBNull.Value)).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public string AddEditEmailMaster(EmailMasterModel model)
        {
            GenericRepository<EmailMasterModel> objGenericRepository = new GenericRepository<EmailMasterModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_AddEditEmailMaster @EmailId,@LanguageId,@Email,@UserId",
                Utility.GetSQLParam("EmailId", SqlDbType.Int, model.EmailId),
                Utility.GetSQLParam("LanguageId", SqlDbType.Int, model.LanguageId),
                Utility.GetSQLParam("Email", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(model.Email) ? model.Email : (object)DBNull.Value),
                Utility.GetSQLParam("UserId", SqlDbType.Int, model.UserId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }

        public string DeleteEmailMaster(int EmailId, int UserId)
        {
            GenericRepository<EmailMasterModel> objGenericRepository = new GenericRepository<EmailMasterModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_DeleteEmailMaster @EmailId,@UserId",
                Utility.GetSQLParam("EmailId", SqlDbType.Int, EmailId),
                Utility.GetSQLParam("UserId", SqlDbType.Int, UserId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }
    }
}
