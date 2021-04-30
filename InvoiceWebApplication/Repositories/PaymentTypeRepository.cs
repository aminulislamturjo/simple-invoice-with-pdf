using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceWebApplication.Models;

namespace InvoiceWebApplication.Repositories
{
    public class PaymentTypeRepository
    {
        private InvoiceDBEntities objInvoiceDbEntities;
        public PaymentTypeRepository()
        {
            objInvoiceDbEntities = new InvoiceDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objInvoiceDbEntities.PaymentTypes
                select new SelectListItem()
                {
                    Text = obj.PaymentTypeName,
                    //Value = obj.PaymentTypeID.ToString(),
                    Value = SqlFunctions.StringConvert((decimal)obj.PaymentTypeID),

                    Selected = true
                }).ToList();
            return objSelectListItems;
        }
    }
}