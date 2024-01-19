﻿using Guide.Models.Interfaces;

namespace Guide.Models
{
    public class Backpack : IItem
    {
        public int Id { get; set; }
        public string ImgSource { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
    }
}