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
        List<OrderInforVM> getOrderDetail(int? ID);
    }
}
