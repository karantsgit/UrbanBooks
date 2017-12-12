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
    public class FAQService
    {
        public List<FAQModel> GetFAQList(int? Question = null, int? Language = null)
        {
            GenericRepository<FAQModel> objGenericRepository = new GenericRepository<FAQModel>();
            List<FAQModel> list = new List<FAQModel>();
            try
            {
                list = objGenericRepository.QuerySQL<FAQModel>("sp_FAQList", Utility.GetSQLParam("Question", SqlDbType.VarChar, (object)Question ?? DBNull.Value),
                     Utility.GetSQLParam("Language", SqlDbType.VarChar, (object)Language ?? DBNull.Value)
                    ).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public string AddEditQuestion(FAQQuestionModel model)
        {
            GenericRepository<FAQQuestionModel> objGenericRepository = new GenericRepository<FAQQuestionModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_AddEditQuestionMaster @QuestionId,@Question,@UserId",
                Utility.GetSQLParam("QuestionId", SqlDbType.Int, model.QuestionId),
                Utility.GetSQLParam("Question", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(model.Question) ? model.Question : (object)DBNull.Value),
                Utility.GetSQLParam("UserId", SqlDbType.Int, model.UserId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }

        public List<FAQQuestionModel> GetQuestionList(string Question = null)
        {
            GenericRepository<FAQQuestionModel> objGenericRepository = new GenericRepository<FAQQuestionModel>();
            List<FAQQuestionModel> list = new List<FAQQuestionModel>();
            try
            {
                list = objGenericRepository.QuerySQL<FAQQuestionModel>("sp_QuestionMasterList",
                     Utility.GetSQLParam("Question", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(Question) ? Question : (object)DBNull.Value)
                     ).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }

        public FAQQuestionModel GetQuestionByQuestionId(int QuestionId)
        {
            GenericRepository<FAQQuestionModel> objGenericRepository = new GenericRepository<FAQQuestionModel>();
            FAQQuestionModel Result = new FAQQuestionModel();
            try
            {
                Result = objGenericRepository.ExecuteSQL<FAQQuestionModel>("sp_GetQuestionMasterByQuestionId @QuestionId",
                Utility.GetSQLParam("QuestionId", SqlDbType.Int, QuestionId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return Result;
        }

        public string DeleteQuestion(int QuestionId,int UserId)
        {
            GenericRepository<FAQQuestionModel> objGenericRepository = new GenericRepository<FAQQuestionModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_DeleteQuestionMaster @QuestionId,@UserId",
                Utility.GetSQLParam("QuestionId", SqlDbType.Int, QuestionId),
                Utility.GetSQLParam("UserId", SqlDbType.Int, UserId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }

        public FAQModel GetFAQByFAQId(int FAQId)
        {
            GenericRepository<FAQModel> objGenericRepository = new GenericRepository<FAQModel>();
            FAQModel Result = new FAQModel();
            try
            {
                Result = objGenericRepository.ExecuteSQL<FAQModel>("sp_GetFAQMasterByFAQId @FAQId",
                Utility.GetSQLParam("FAQId", SqlDbType.Int, FAQId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }

        public string AddEditFAQ(FAQModel model)
        {
            GenericRepository<FAQModel> objGenericRepository = new GenericRepository<FAQModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_AddEditFAQMaster @FAQId,@QuestionId,@LanguageId,@Answer,@UserId",
                Utility.GetSQLParam("FAQId", SqlDbType.Int, model.FAQId),
                Utility.GetSQLParam("QuestionId", SqlDbType.Int, model.QuestionId),
                Utility.GetSQLParam("LanguageId", SqlDbType.Int, model.LanguageId),
                Utility.GetSQLParam("Answer", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(model.Answer) ? model.Answer : (object)DBNull.Value),
                Utility.GetSQLParam("UserId", SqlDbType.Int, model.UserId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }


        public string DeleteFAQ(int FAQId, int UserId)
        {
            GenericRepository<FAQModel> objGenericRepository = new GenericRepository<FAQModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_DeleteFAQMaster @FAQId,@UserId",
                Utility.GetSQLParam("FAQId", SqlDbType.Int, FAQId),
                Utility.GetSQLParam("UserId", SqlDbType.Int, UserId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }



        //New

        public string AddEditAnswerQuestion(FAQQuestionModel model)
        {
            GenericRepository<FAQQuestionModel> objGenericRepository = new GenericRepository<FAQQuestionModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_AddEditAnswerQuestion @QuestionId,@Question,@Answer,@UserId",
                Utility.GetSQLParam("QuestionId", SqlDbType.Int, model.QuestionId),
                Utility.GetSQLParam("Question", SqlDbType.NVarChar, !string.IsNullOrWhiteSpace(model.Question) ? model.Question : (object)DBNull.Value),
                Utility.GetSQLParam("Answer", SqlDbType.NVarChar, !string.IsNullOrWhiteSpace(model.Answer) ? model.Answer : (object)DBNull.Value),
                Utility.GetSQLParam("UserId", SqlDbType.Int, model.UserId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }

        public FAQModel GetQuestionAnswerByLanguange(int LanguangeId, int QuestionId)
        {
            GenericRepository<FAQModel> objGenericRepository = new GenericRepository<FAQModel>();
            FAQModel Result = new FAQModel();
            try
            {
                Result = objGenericRepository.ExecuteSQL<FAQModel>("sp_GetQuestionByLanguange @LanguangeId,@QuestionId",
                Utility.GetSQLParam("LanguangeId", SqlDbType.Int, LanguangeId),
                Utility.GetSQLParam("QuestionId", SqlDbType.Int, QuestionId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
            }
            return Result;
        }


        public string AddEditQuestionAnswerByLanguange(FAQModel model)
        {
            GenericRepository<FAQModel> objGenericRepository = new GenericRepository<FAQModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_AddEditQuestionAnswerByLAnguage @FAQId,@QuestionId,@LanguageId,@Question,@Answer,@UserId",
                Utility.GetSQLParam("FAQId", SqlDbType.Int, model.FAQId),
                Utility.GetSQLParam("QuestionId", SqlDbType.Int, model.QuestionId),
                Utility.GetSQLParam("LanguageId", SqlDbType.Int, model.LanguageId),
                Utility.GetSQLParam("Question", SqlDbType.NVarChar, !string.IsNullOrWhiteSpace(model.Question) ? model.Question : (object)DBNull.Value),
                Utility.GetSQLParam("Answer", SqlDbType.NVarChar, !string.IsNullOrWhiteSpace(model.Answer) ? model.Answer : (object)DBNull.Value),
                Utility.GetSQLParam("UserId", SqlDbType.Int, model.UserId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }


        public string DeleteQuestionAnswer(int QuestionId, int UserId)
        {
            GenericRepository<FAQModel> objGenericRepository = new GenericRepository<FAQModel>();
            string Result = string.Empty;
            try
            {
                Result = objGenericRepository.ExecuteSQL<string>("sp_DeleteQuestionAnswer @QuestionId,@UserId",
                Utility.GetSQLParam("QuestionId", SqlDbType.Int, QuestionId),
                Utility.GetSQLParam("UserId", SqlDbType.Int, UserId)
                ).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Result = ex.Message.ToString();
            }
            return Result;
        }


        public List<FAQQuestionModel> GetQuestionAnswerList(string Question = null)
        {
            GenericRepository<FAQQuestionModel> objGenericRepository = new GenericRepository<FAQQuestionModel>();
            List<FAQQuestionModel> list = new List<FAQQuestionModel>();
            try
            {
                list = objGenericRepository.QuerySQL<FAQQuestionModel>("sp_QuestionAnswerList",
                     Utility.GetSQLParam("Question", SqlDbType.VarChar, !string.IsNullOrWhiteSpace(Question) ? Question : (object)DBNull.Value)
                     ).ToList();
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
