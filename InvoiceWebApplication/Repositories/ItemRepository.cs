using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceWebApplication.Models;

namespace InvoiceWebApplication.Repositories
{
    public class ItemRepository
    {
        private InvoiceDBEntities objInvoiceDbEntities;
        public ItemRepository()
        {
            objInvoiceDbEntities = new InvoiceDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objInvoiceDbEntities.Items
                select new SelectListItem()
                {
                    Text = obj.ItemName,
                    //Value = obj.ItemID.ToString(),
                    Value = SqlFunctions.StringConvert((decimal)obj.ItemID),

                    Selected = false
                }).ToList();
            return objSelectListItems;
        }
    }
}