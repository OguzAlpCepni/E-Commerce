﻿using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GelAll();
        void add(Product product);
        void Delete(Product product);
        void update(Product product);
        
    }
}
