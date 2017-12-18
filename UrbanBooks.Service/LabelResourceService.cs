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
    public class LabelResourceService
    {
        public List<LabelModel> GetLabelList()
        {
            GenericRepository<LabelModel> objGenericRepository = new GenericRepository<LabelModel>();
            List<LabelModel> list = new List<LabelModel>();
            try
            {
                list = objGenericRepository.QuerySQL<LabelModel>("sp_LabelMasterList").ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public string AddEditLabel(LabelModel model)
        {
            GenericRepository<LabelModel> objGenericRepository = new GenericRepository<LabelModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_AddEditLabelMaster @LabelId,@LabelKey,@UserId",
                Utility.GetSQLParam("LabelId", SqlDbType.Int, model.LabelId),
                Utility.GetSQLParam("LabelKey", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(model.LabelKey) ? model.LabelKey : (object)DBNull.Value),
                Utility.GetSQLParam("UserId", SqlDbType.Int, model.UserId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }

        public LabelModel GetLabelByLabelId(int LabelId)
        {
            GenericRepository<LabelModel> objGenericRepository = new GenericRepository<LabelModel>();
            LabelModel Result = new LabelModel();
            try
            {
                Result = objGenericRepository.ExecuteSQL<LabelModel>("sp_GetLabelMasterByLabelId @LabelId",
                Utility.GetSQLParam("LabelId", SqlDbType.Int, LabelId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }

        public string DeleteLabel(int LabelId, int UserId)
        {
            GenericRepository<FAQQuestionModel> objGenericRepository = new GenericRepository<FAQQuestionModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_DeleteLabelMaster @LabelId,@UserId",
                Utility.GetSQLParam("LabelId", SqlDbType.Int, LabelId),
                Utility.GetSQLParam("UserId", SqlDbType.Int, UserId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }

        //Label Resource

        public List<LabelResourceModel> GetLabelResourceList(int? LabelKey = null, string Language = null)
        {
            GenericRepository<LabelResourceModel> objGenericRepository = new GenericRepository<LabelResourceModel>();
            List<LabelResourceModel> list = new List<LabelResourceModel>();
            try
            {
                list = objGenericRepository.QuerySQL<LabelResourceModel>("sp_LabelResourceMasterList", Utility.GetSQLParam("LabelKey", SqlDbType.VarChar, (object)LabelKey ?? DBNull.Value),
                            Utility.GetSQLParam("Language", SqlDbType.VarChar, (object)Language ?? DBNull.Value)).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public string AddEditLabelResource(LabelResourceModel model)
        {
            GenericRepository<LabelResourceModel> objGenericRepository = new GenericRepository<LabelResourceModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_AddEditLabelResourceMaster @ResourceId,@LabelId,@LanguageCode,@ResourceValue,@UserId",
                Utility.GetSQLParam("ResourceId", SqlDbType.Int, model.ResourceId),
                Utility.GetSQLParam("LabelId", SqlDbType.Int, model.LabelId),
                Utility.GetSQLParam("LanguageCode", SqlDbType.VarChar, model.LanguageCode),
                Utility.GetSQLParam("ResourceValue", SqlDbType.NVarChar, !string.IsNullOrWhiteSpace(model.ResourceValue) ? model.ResourceValue : (object)DBNull.Value),
                Utility.GetSQLParam("UserId", SqlDbType.Int, model.UserId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }

        public LabelResourceModel GetLabelResourceByResourceId(int ResourceId)
        {
            GenericRepository<LabelResourceModel> objGenericRepository = new GenericRepository<LabelResourceModel>();
            LabelResourceModel Result = new LabelResourceModel();
            try
            {
                Result = objGenericRepository.ExecuteSQL<LabelResourceModel>("sp_GetLabelResourceByResourceId @ResourceId",
                Utility.GetSQLParam("ResourceId", SqlDbType.Int, ResourceId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }

        public string DeleteLabelResource(int ResourceId, int UserId)
        {
            GenericRepository<LabelResourceModel> objGenericRepository = new GenericRepository<LabelResourceModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_DeleteLabelResourceMaster @ResourceId,@UserId",
                Utility.GetSQLParam("ResourceId", SqlDbType.Int, ResourceId),
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
