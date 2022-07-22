using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MinimalAPIDemo
{
    public static class Api
    {
       
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet(pattern: "/Users", GetUsers);
            app.MapGet(pattern:"/Users/{id}",GetUser);
            app.MapPost(pattern:"/Users",InsertUser);
            app.MapPut(pattern: "/Users", UpdateUser);
            app.MapDelete(pattern: "/Users", DeleteUser);
        }
        private static async Task <IResult>GetUsers(IUserData data)
        {
            try
            {
                return Results.Ok(await data.GetUsers());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetUser(int id,IUserData data)
        {
            try
            {
                var result = await data.GetUser(id);
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {

               return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> InsertUser(UserModel user , IUserData data)
        {
            try
            {
                await data.InsertUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> UpdateUser(UserModel user,IUserData data)
        {
            try
            {
                await data.UpdateUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeleteUser( int id,IUserData data)
        {
            try
            {
                await data.DeleteUser(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
        
    } 
}
