using MyStore.Models;
using MyStore.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Repository
{
    interface IOrder
    {
        OrderModel getOrderByID(int? ID);

        OrderModel addOrder(OrderModel order);
    }
}
