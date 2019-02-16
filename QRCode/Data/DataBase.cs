using QRCode.Entities;
using System.Collections.Generic;

namespace QRCode.Data
{
    public class DataBase
    {
        public static List<Product> GetProductsList()
        {

            return new List<Product>()
            {
                new Product { Id = 1,
                              Name = "Dell XPS 9570",
                              Description = "Laptop 15.6'' FHD, " +
                              " 8th Gen Intel Core i7-8750H CPU, " +
                              "16GB RAM, 512GB SSD, " +
                              "GeForce GTX 1050Ti, " +
                              "Thin bzl 400 Nits Display, " +
                              "Silver, Windows 10 Home ",
                              Price = 1499.00M,
                              Url = "https://www.amazon.com/Dell-i7-8750H-GeForce-Display-Windows/dp/B07CTKVGQ5/ref=sr_1_12?qid=1550101906&refinements=p_n_feature_four_browse-bin%3A2289792011&s=pc&sr=1-12"
                            },
                new Product { Id = 2,
                            Name = "SanDisk SSD PLUS",
                            Description = "1TB Internal SSD - SATA III 6 Gb/s, " +
                            "2.5''/7mm - SDSSDA-1T00-G26",
                            Price = 124.99M,
                            Url = "https://www.amazon.com/SanDisk-SSD-PLUS-Internal-SDSSDA-1T00-G26/dp/B07D998212/ref=sr_1_1_sspa?keywords=ssd&qid=1550102200&s=pc&sr=1-1-spons&psc=1"
                            },
                new Product { Id = 3,
                        Name = "Asus MX239H",
                        Description = "2'' LED LCD Monitor - 16:9 - 5 ms",
                        Price = 23988.26M,
                        Url = "https://www.amazon.com/Asus-MX239H-LED-LCD-Monitor/dp/B01IG8TYZO/ref=sr_1_3?keywords=monitor&qid=1550102419&rnid=493964&s=electronics&sr=1-3"
                    }
            };

        }
    }
}
