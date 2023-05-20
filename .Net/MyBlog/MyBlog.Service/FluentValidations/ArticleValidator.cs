
using FluentValidation;
using MyBlog.Entity.Entities;
using MyBlog.Entity.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.FluentValidations
{
    public class ArticleValidator : AbstractValidator<Article> 
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull()
            .MinimumLength(3).MaximumLength(150).WithName("Başlık");

            RuleFor(x => x.Content).NotEmpty().NotNull()
                .MinimumLength(3).MaximumLength(150).WithName("İçerik");
        }
    }
}
