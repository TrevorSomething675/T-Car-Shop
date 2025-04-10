﻿namespace T_Car_Shop.Core.Models.DataAccess
{
    public class ColorEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public Guid CarId { get; set; }
        public CarEntity Car { get; set; }
    }
}
