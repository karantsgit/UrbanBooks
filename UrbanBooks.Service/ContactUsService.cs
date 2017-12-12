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
    public class ContactUsService
    {
        public string AddEditContactDetails(ContactUsModel model)
        {
            GenericRepository<ContactUsModel> objGenericRepository = new GenericRepository<ContactUsModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_AddContactUsDetails @LanguageId,@Name,@Email,@Message",
                Utility.GetSQLParam("LanguageId", SqlDbType.Int, model.LanguageId),
                Utility.GetSQLParam("Name", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(model.Name) ? model.Name : (object)DBNull.Value),
                Utility.GetSQLParam("Email", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(model.Email) ? model.Email : (object)DBNull.Value),
                Utility.GetSQLParam("Message", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(model.Message) ? model.Message : (object)DBNull.Value)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }

        public string GetEmailMasterByLanguageId(int LanguageId)
        {
            GenericRepository<EmailMasterModel> objGenericRepository = new GenericRepository<EmailMasterModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_GetEmailMasterByLanguageId @LanguageId",
                Utility.GetSQLParam("LanguageId", SqlDbType.Int, LanguageId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = "";
            }
            return Result;
        }
    }
}
