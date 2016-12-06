using System;
using System.Web.Http;
using Instagram.Models;

namespace Instagram.Controllers
{
    public class CommentsController : ApiController
    {
        private const string ConnectionString = @"Server=tcp:instakill.database.windows.net,1433;Initial Catalog=Instagramm;Persist Security Info=False;User ID=Valera;Password=Instakill1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=instakill;Integrated Security=True";
        private readonly IDataLayer _dataLayer;
        public CommentsController()
        {
            _dataLayer = new DataLayer.Sql.DataLayer(ConnectionString);
        }
        [HttpPost]//ok
        [Route("api/comments/{id}")]
        public Comments AddCommentToPost(Guid id, Comments comment)
        {
            return _dataLayer.AddCommentToPost(id, comment);
        }

        [HttpPost]//ok
        [Route("api/comments/")]
        public Comments UpdateComment(Comments com)
        {
            _dataLayer.UpdateComment(com);
            return _dataLayer.GetComment(com.ComId);
        }
        [HttpDelete]//ok
        [Route("api/comments/{id}")]
        public void DeleteComment(Guid id)
        {
            _dataLayer.DeleteComment(id);
        }
        [HttpGet]//ok
        [Route("api/comments/{id}")]
        public Comments GetComment(Guid id)
        {
            return _dataLayer.GetComment(id);
        }
    }
}