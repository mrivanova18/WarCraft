﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarCraft.Infrastructure.Data.Entities;

namespace WarCraft.Core.Contracts
{
    public interface IManufacturerService
    {
        List<Manufacturer> GetManufacturers();
        Manufacturer GetManufacturerById(int manufacturerId);
        List<Product> GetProductsByManufacturer(int manufacturerId);
    }
}
