﻿using RetailAdminHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.DTOs.Product
{
    public class CategoryDetailDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<ProductDTO> Products { get; set; }
    }
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<SummaryCategoryDTO> Categories { get; set; }
    }

    public class SummaryProductDTO
    {
        public Guid Id { get; set; }
    }
    public class SummaryCategoryDTO
    {
        public Guid Id { get; set; }
    }
}


