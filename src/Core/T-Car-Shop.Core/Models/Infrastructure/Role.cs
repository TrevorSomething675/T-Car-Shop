﻿namespace T_Car_Shop.Core.Models.Infrastructure
{
    public class Role : BaseModel
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}