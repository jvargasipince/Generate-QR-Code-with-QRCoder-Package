﻿namespace QRCode.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string QRCode { get; set; }
    }
}
