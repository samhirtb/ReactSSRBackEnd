using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivingSimple.Model
{
    public class Post
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }
        public string postPreviewContent { get; set; }
        public string postContent { get; set; }
        public int numberOfComments { get; set; }
        public string imgURL { get; set; }
    }
}
