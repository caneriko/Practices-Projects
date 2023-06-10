using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaw.Service.Messages
{
    public static class ResultMessage
    {

        public static class Article
        {
            public static string Add(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla eklenmiştir";
            }

            public static string Update(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla güncellenmiştir";
            }

            public static string Delete(string articleTitle)
            {
                return $"{articleTitle} başlıklı makale başarıyla silinmiştir";
            }

        }

        public static class Writer
        {
            public static string Add(string name)
            {
                return $"{name} isimli yazar başarıyla eklenmiştir";
            }

            public static string Update(string name)
            {
                return $"{name} isimli yazar başarıyla güncellenmiştir";
            }

            public static string Delete(string name)
            {
                return $"{name} isimli yazar başarıyla silinmiştir";
            }



        }

        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla eklenmiştir";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla güncellenmiştir";
            }

            public static string Delete(string categoryName)
            {
                return $"{categoryName} başlıklı kategori başarıyla silinmiştir";
            }



        }

         


        public static class User
        {
            public static string Add(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla eklenmiştir";
            }

            public static string Update(string userName)
            {
                return $"{userName} isimli kullanıcı  başarıyla güncellenmiştir";
            }

            public static string Delete(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla silinmiştir";
            }

            public static string Signup()
            {
                return $" Üyelik başarıyla oluşturulmuştur";
            }

            public static string Login()
            {
                return $"Başarılı giriş gerçekleştirildi";
            }

            public static string PasswordChange()
            {
                return $"Başarılı şifre değiştirme gerçekleştirildi";
            }

        }

        public static class Book
        {
            public static string Add(string name)
            {
                return $"{name} isimli ürün başarıyla eklenmiştir";
            }

            public static string Update(string name)
            {
                return $"{name} isimli ürün başarıyla güncellenmiştir";
            }

            public static string Delete(string name)
            {
                return $"{name} başlıklı makale başarıyla silinmiştir";
            }

        }

        







    }
}
