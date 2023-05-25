using MyBlog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.Entities
{
    public class Visitor : IEntityBase
    {
        public Visitor() { }
        public Visitor(string ipAdress,string userAgent )
        {
            IpAddress= ipAdress;
            UserAgent= userAgent;
        }

        public int Id { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }



    }
}
