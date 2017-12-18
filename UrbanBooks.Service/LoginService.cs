using System;
using UrbanBooks.Entity;
using UrbanBooks.Data.Repository;
using UrbanBooks.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace UrbanBooks.Service
{
    public class LoginService
    {
        public UserSessionDetailsModel ValidateUserLogin(UsersModel model)
        {
            GenericRepository<UsersModel> objGenericRepository = new GenericRepository<UsersModel>();
            UserSessionDetailsModel objUser = new UserSessionDetailsModel();

            objUser = objGenericRepository.QuerySQL<UserSessionDetailsModel>("sp_ValidateUserLogin", Utility.GetSQLParam("EmailAddress", SqlDbType.VarChar, model.EmailAddress),
                                                                                                                 Utility.GetSQLParam("Password", SqlDbType.VarChar, Security.Encrypt(model.Password))
                                                                                                                 ).FirstOrDefault();
            return objUser;
        }      
    }
}
