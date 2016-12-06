using System;
using System.Collections.Generic;
using System.Web.Http;
using Instagram.Models;

namespace Instagram.Controllers
{
    public class UsersController : ApiController
    {

        // private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=instakill;Integrated Security=True";
        private const string ConnectionString = @"Server=tcp:instakill.database.windows.net,1433;Initial Catalog=Instagramm;Persist Security Info=False;User ID=Valera;Password=Instakill1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private readonly IDataLayer _dataLayer;
        public UsersController()
        {
            _dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
        }


        [HttpPost] //ok            
        public Users CreateUser(Users user)
        {
            return _dataLayer.AddUser(user);
        }
        [HttpGet]//???
        [Route("api/users/{id}/posts")]
        public List<Posts> GeUserPosts(Guid id)
        {
            return _dataLayer.GetLatestPosts(id);
        }
        [HttpDelete]//ok
        [Route("api/users/{id}")]
        public void DelUser(Guid id)
        {
            _dataLayer.DeleteUser(id);
            //return !(_dataLayer.IsUser(id));
        }
        [HttpGet] //ok
        [Route("api/users/{id}")]
        public Users GetUser(Guid id)
        {
            return _dataLayer.GetUser(id);
        }
        [HttpGet] //???
        [Route("api/users/name/{name}")]
        public Users GetUserName(string name)
        {
            return _dataLayer.GetUserByName(name);
        }

        [HttpPost] //ok
        [Route("api/users/{id}")]
        public Users UpdateUser(Guid id, Users newuser)
        {
            newuser.UserId = id;
            _dataLayer.UpdateUser(id, newuser);
            return _dataLayer.GetUser(id);
        }

    }
}