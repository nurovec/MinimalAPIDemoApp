using System;
using DataAccess.DBAccess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Data
{

    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<UserModel>> GetUsers() =>_db.LoadData<UserModel, dynamic>(storedProcedure: "spUser_GetAll", new { });
        public async Task<UserModel?> GetUser(int id)
        {
            var result = await _db.LoadData<UserModel, dynamic>(storedProcedure: "spUser_Get", new { Id = id });
            return result.FirstOrDefault();
        }
        public Task InsertUser(UserModel user) => _db.SaveData(storedProcedure: "dbo.spUser_Insert", new { user.FirstName, user.LastName });
        public Task UpdateUser(UserModel user) => _db.SaveData(storedProcedure: "dbo.spUser_Update", user);
        public Task DeleteUser(int id) => _db.SaveData(storedProcedure: "dbo.spUser_Delete", new { Id = id });
    }
}
