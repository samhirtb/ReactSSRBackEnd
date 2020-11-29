using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivingSimple.DataAccess;
using LivingSimple.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LivingSimple.Controllers
{
    [ApiController]
    [Route("LivingSimple/[controller]")]
    public class PostsController : ControllerBase
    {
        private LivingSimpleDbContext _dbContext;

        public PostsController(LivingSimpleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _dbContext.Posts.ToArray();
        }

        [EnableCors("AllowOrigin")]
        [HttpGet]
        [Route("{id}")]
        public Post Get(int id)
        {
            return _dbContext.Posts.Where(x => x.id == id).FirstOrDefault();
        }
        [EnableCors("AllowOrigin")]
        [HttpPost]
        public bool Post(Post p)
        {
            Post updatePost = _dbContext.Posts.Where(x => x.id == p.id).FirstOrDefault();

            updatePost.postContent = p.postContent;

            _dbContext.SaveChanges();

            return true;
        }

    }
}
