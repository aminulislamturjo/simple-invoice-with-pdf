using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceWebApplication.Models;
using InvoiceWebApplication.Repositories;
using InvoiceWebApplication.ViewModel;
using Rotativa;

namespace InvoiceWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private InvoiceDBEntities objInvoiceDbEntities;

        public HomeController()
        {
            objInvoiceDbEntities = new InvoiceDBEntities();
        }
        //
        // GET: /Home/
        public ActionResult Index()
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentType());
            return View(objMultipleModels);
        }

        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objInvoiceDbEntities.Items.Single(model => model.ItemID == itemId).ItemPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(objOrderViewModel);
            return Json("Order created", JsonRequestBehavior.AllowGet);
        }

        public ActionResult PrintInvoice()
        {
            var printPdf = new ActionAsPdf("Index");
            return printPdf;
        }

	}
}