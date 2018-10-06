using e_Welfare.BLL.BusinessObject;
using e_Welfare.BLL.Interfaces;
using e_Welfare.DTO;
using e_Welfare.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace e_Welfare.Areas.Client.Controllers
{
    public class ClientDashboardController : Controller
    {
        private HttpClient client;

        /// <summary>
        /// manage client 
        /// </summary>
        private readonly IManageClient _manageClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDashboardController"/> class.
        /// </summary>
        public ClientDashboardController()
        {
            this._manageClient = new ManageClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDashboardController"/> class
        /// </summary>
        /// <param name="manageClient">manage Client</param>
        public ClientDashboardController(ManageClient manageClient)
        {
            this._manageClient = manageClient;
        }
        // GET: Client/ClientDashboard
        public ActionResult ClientDashboard(string userStatus)
        {
            if (this.Session["UserStatus"] != null)
            {
                this.TempData["UserStatus"] = Convert.ToString(this.Session["UserStatus"]); ;
            }
            if (this.Session["WelfareSection"] != null)
            {
                this.TempData["WelfareSection"] = Convert.ToString(this.Session["WelfareSection"]);
            }

            return View();
        }

        // GET: Client/ClientDashboard
        public ActionResult ClientDashboardType(string clientDashboardType)
        {
            int userID = 0;
            if (this.Session["UserID"] != null)
            {
                userID = Convert.ToInt32(this.Session["UserID"]);
            }
            if (clientDashboardType == "INP")
            {

                ClientDashboardTypeViewModel model = new ClientDashboardTypeViewModel();
                model = this._manageClient.GetCheckedClientSection(userID);
                return PartialView("ClientInProcessType_PV", model);
            }
            else
            {
                Users user = new Users();
                if (userID != null && userID > 0)
                {
                    user = this._manageClient.GetUserDetails(userID);
                }

                return this.PartialView("ClientAcceptedType_PV", user);


            }

        }

        /// <summary>
        /// To activate the Checked Client Section status Save
        /// </summary>
        /// <param name="chekdSections">chekd Sections</param>
        /// <returns>Client Dashboard PV</returns>
        public ActionResult CheckedClientSection(List<string> chekdSections)
        {
            int userID = 0;
            if (this.Session["UserID"] != null)
            {
                userID = Convert.ToInt32(this.Session["UserID"]);
            }
            bool status = this._manageClient.CheckedClientSection(chekdSections, userID);
            return this.Json(new { Status = status }, JsonRequestBehavior.AllowGet);
        }

    }
}