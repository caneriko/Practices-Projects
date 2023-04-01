using AutoMapper;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.AutoMapper.Articles
{
    public class ArticleProfile :Profile
    {
        public ArticleProfile() 
        {
            CreateMap<Article, ArticleViewModel>().ReverseMap();
        }
    }
}
