﻿namespace T_Car_Shop.DataAccess.Entities
{
    public class ImageEntity : BaseEntity
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public Guid CarId { get; set; }
        public CarEntity Car { get; set; }
    }
}