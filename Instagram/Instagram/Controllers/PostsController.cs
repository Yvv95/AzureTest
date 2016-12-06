using System;
using System.Collections.Generic;
using System.Web.Http;
using Instagram.Models;

namespace Instagram.Controllers
{
    public class PostsController : ApiController
    {
        private const string ConnectionString = @"Server=tcp:instakill.database.windows.net,1433;Initial Catalog=Instagramm;Persist Security Info=False;User ID=Valera;Password=Instakill1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=instakill;Integrated Security=True";
        private readonly IDataLayer _dataLayer;
        public PostsController()
        {
            _dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
        }
        [HttpPost]//ok
        public Posts CreatePost(Posts post)
        {
            return _dataLayer.AddPost(post);
        }
        [HttpGet]//ok
        [Route("api/posts/{id}")]
        public Posts GetPost(Guid id)
        {
            return _dataLayer.GetPost(id);
        }
        [HttpGet]//ok
        [Route("api/posts/{id}/comments")]
        public List<Comments> GetPostCom(Guid id)
        {
            return _dataLayer.GetPostComments(id);
        }
        
        [HttpDelete]//ok
        [Route("api/posts/{id}")]
        public void DeletePost(Guid id)
        {
            _dataLayer.DeletePost(id);
        }
        [HttpPost]//ok
        [Route("api/posts/{id}")]
        public Posts UpdatePost(Guid id, Posts newpost)
        {
            _dataLayer.UpdatePost(id, newpost);
            newpost.PostId = id;
            return _dataLayer.GetPost(newpost.PostId);
        }



    }
}