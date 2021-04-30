using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvoiceWebApplication.Models;
using InvoiceWebApplication.ViewModel;

namespace InvoiceWebApplication.Repositories
{
    public class OrderRepository
    {
        private InvoiceDBEntities objInvoiceDbEntities;

        public OrderRepository()
        {
            objInvoiceDbEntities = new InvoiceDBEntities();
            
        }

        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Order objOrder = new Order();
            objOrder.CustomerId = objOrderViewModel.CustomerId;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.OrderDate = DateTime.Now;
            objOrder.OrderNumber = String.Format("{0:ddmmmyyyyhhmmss}",DateTime.Now);
            objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;
            objInvoiceDbEntities.Orders.Add(objOrder);
            objInvoiceDbEntities.SaveChanges();
            int OrderId = objOrder.OrderId;

            foreach (var item in objOrderViewModel.ListOfOrderDetailViewModel)
            {
                OrderDetail objOrderDetail = new OrderDetail();
                objOrderDetail.OrderId = OrderId;
                objOrderDetail.Discount = item.Discount;
                objOrderDetail.ItemId = item.ItemId;
                objOrderDetail.Total = item.Total;
                objOrderDetail.UnitPrice = item.UnitPrice;
                objOrderDetail.Quantity = item.Quantity;
                objInvoiceDbEntities.OrderDetails.Add(objOrderDetail);
                objInvoiceDbEntities.SaveChanges();

                Transaction objTransaction = new Transaction();
                objTransaction.ItemId = item.ItemId;
                objTransaction.Quantity = (-1)*item.Quantity;
                objTransaction.TransactionDate = DateTime.Now;
                objTransaction.TypeId = 2;
                objInvoiceDbEntities.Transactions.Add(objTransaction);
                objInvoiceDbEntities.SaveChanges();
            }
            return true;
        }
    }
}