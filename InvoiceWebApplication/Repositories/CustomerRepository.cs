using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceWebApplication.Models;


namespace InvoiceWebApplication.Repositories
{
    public class CustomerRepository
    {
        private InvoiceDBEntities objInvoiceDbEntities;
        public CustomerRepository()
        {
            objInvoiceDbEntities = new InvoiceDBEntities();
        }

        //public IEnumerable<SelectListItem> GetAllCustomers()
        //{
        //    var objSelectListItems = new List<SelectListItem>();
        //    objSelectListItems = (from obj in objInvoiceDbEntities.Customers
        //                          select new SelectListItem()
        //                          {
        //                              Text = obj.CustomerName,
        //                              Value = obj.CustomerID.ToString(),
        //                              Selected = true
        //                          }).ToList();
        //    return objSelectListItems;
        //}

        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objInvoiceDbEntities.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      //Value = obj.CustomerID.ToString(),
                                      Value = SqlFunctions.StringConvert((decimal)obj.CustomerID),

                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}