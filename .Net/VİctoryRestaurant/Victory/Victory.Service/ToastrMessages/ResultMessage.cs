using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victory.Service.ToastrMessages
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

        public static class Reservation
        {
            public static string Add()
            {
                return " Rezervasyonunuz başarıyla eklenmiştir";
            }

            public static string Update(string fullName)
            {
                return $"{fullName} isimli müşterinin rezervasyonu başarıyla güncellenmiştir";
            }

            public static string Delete()
            {
                return "Rezervasyon başarıyla silinmiştir";
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

        public static class Contact
        {
            public static string Add()
            {
                return "Mesajınız başarıyla eklenmiştir";
            }

            public static string Update()
            {
                return $"Mesaj başarıyla güncellenmiştir";
            }

            public static string Delete()
            {
                return "Mesaj başarıyla silinmiştir";
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
                return $"{userName} email adresli kullanıcı  başarıyla güncellenmiştir";
            }

            public static string Delete(string userName)
            {
                return $"{userName} email adresli kullanıcı başarıyla silinmiştir";
            }

        }

        public static class Product
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

        public static class Signup
        {
            public static string Add()
            {
                return $"Aboneliğiniz başarıyla eklenmiştir";
            }

            public static string Update()
            {
                return $"Abonelik başarıyla güncellenmiştir";
            }

            public static string Delete()
            {
                return $"Abonelik başarıyla silinmiştir";
            }

        }







    }
}
