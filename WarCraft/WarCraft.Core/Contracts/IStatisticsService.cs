﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCraft.Core.Contracts
{
    public interface IStatisticsService
    {
        int CountProducts();
        int CountClients();
        int CountOrders();
        decimal SumOrders();
    }
}
