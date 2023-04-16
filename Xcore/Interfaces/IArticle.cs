﻿using Xcore.Models.Entities;

namespace Xcore.Interfaces
{
    public interface IArticle
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
