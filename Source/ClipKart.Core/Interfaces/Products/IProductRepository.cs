﻿using System;
using ClipKart.Core.Models;

namespace ClipKart.Core.Interfaces.Products
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);

        List<Product> GetProducts();
    }
}
