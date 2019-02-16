using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QRCode.Data;
using QRCode.Entities;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using static QRCoder.PayloadGenerator;

namespace QRCode.Pages.Products
{
    public class CodeQRModel : PageModel
    {
        private readonly IHostingEnvironment hostingEnv;
        public List<Product> productsList { get; set; }

        public CodeQRModel(IHostingEnvironment _hostingEnv)
        {
            hostingEnv = _hostingEnv;
        }

        public void OnGet()
        {
            productsList = GetProductsList();
        }

        public List<Product> GetProductsList()
        {
            List<Product> products = DataBase.GetProductsList();

            foreach (var product in products)
            {
                string path = Path.Combine(hostingEnv.ContentRootPath, "Images", product.Name + ".jpg");

                product.Image = GetImageBase64String(path);
                //product.QRCode = GenerateQRCodeByObject(product.Id);
                product.QRCode = GenerateQRCodeByUrl(product.Url, false);
            }

            return products;

        }

        public string GenerateQRCodeByUrl(string url, bool includeImage)
        {
            Url generator = new Url(url);

            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);
            var imgType = Base64QRCode.ImageType.Jpeg;

            string qrCodeImageAsBase64 = string.Empty;

            if (includeImage)
            {
                string path = Path.Combine(hostingEnv.ContentRootPath, "Images", "KF_Logo.png");

                qrCodeImageAsBase64 = qrCode.GetGraphic(50,
                                        Color.Black,
                                        Color.White,
                                        (Bitmap)Bitmap.FromFile(path));

            }
            else
            {
                qrCodeImageAsBase64 = qrCode.GetGraphic(50,
                                       Color.Black,
                                       Color.White,
                                       true,
                                       imgType);
            }

            return qrCodeImageAsBase64;
        }

        public string GetImageBase64String(string path)
        {
            var image = System.IO.File.ReadAllBytes(path);

            return Convert.ToBase64String(image);
        }

        public string GenerateQRCodeByObject(int id)
        {
            Product product = DataBase.GetProductsList().Where(item => item.Id == id).FirstOrDefault();

            string productInfo = string.Empty;

            if (product.Id > 0)
            {
                productInfo = JsonConvert.SerializeObject(product);
            }
            else
            {
                productInfo = "The product does not exist.";
            }

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(productInfo, QRCodeGenerator.ECCLevel.Q);
            Base64QRCode qrCode = new Base64QRCode(qrCodeData);

            var imgType = Base64QRCode.ImageType.Jpeg;
            var qrCodeImageAsBase64 = qrCode.GetGraphic(50,
                            Color.Black,
                            Color.White,
                            true,
                            imgType);

            return qrCodeImageAsBase64;


        }

    }
}