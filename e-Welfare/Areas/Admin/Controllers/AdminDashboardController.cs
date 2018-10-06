using e_Welfare.BLL.BusinessObject;
using e_Welfare.BLL.Interfaces;
using e_Welfare.DTO;
using e_Welfare.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace e_Welfare.Areas.Admin.Controllers
{
    public class AdminDashboardController : Controller
    {
        private HttpClient client;

        /// <summary>
        /// manage client 
        /// </summary>
        private readonly IManageClient _manageClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminDashboardController"/> class.
        /// </summary>
        public AdminDashboardController()
        {
            this._manageClient = new ManageClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminDashboardController"/> class
        /// </summary>
        /// <param name="manageClient">manage Client</param>
        public AdminDashboardController(ManageClient manageClient)
        {
            this._manageClient = manageClient;
        }

        // GET: Admin/AdminDashboard
        public ActionResult AdminDashboard()
        {
            return this.View();
        }

        /// <summary>
        /// Gets the unread message count for a user
        /// </summary>
        /// <returns>message count</returns>
        public ActionResult GetStatusCount()
        {
            var applcntStatusCnt = this._manageClient.GetStatusCount();

            return this.Json(new { Status = applcntStatusCnt }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get Medicine Inventory
        /// </summary>
        /// <returns>medicine inventory</returns>
        public ActionResult GetMedicineInventory()
        {
            var inventory = this._manageClient.GetMedicineInventory();

            return this.Json(new { Inventory = inventory }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Render Applicant List Partial View
        /// </summary>
        /// <param name="tabName">tab Name clicked</param>
        /// <returns>Applicant List Partial View</returns>
        ////[ValidateInput(false)]
        public ActionResult ApplicantListPartialView(string tabName)
        {
            var applicantList = this._manageClient.ApplicantDashboardList(tabName);

            return this.PartialView("ApplicantList_PV", applicantList);
        }

        /// <summary>
        /// To activate the Applicant status
        /// </summary>
        /// <param name="checkdApplicantIds">checkd Applicant Ids</param>
        /// <returns>Applicant List Partial View</returns>
        public ActionResult CheckApprovalStatus(List<string> checkdApplicantIds)
        {
            bool status = this._manageClient.CheckApprovalStatus(checkdApplicantIds);
            return this.Json(new { Status = status }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///Activate Client Section
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Admin Dashboard</returns>
        public ActionResult ActivateClientSection(int userID)
        {
            bool status = this._manageClient.ActivateClientSection(userID);
            return this.Json(new { Status = status }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Load permission
        /// </summary>
        /// <returns>loaded Partial View</returns>
        public ActionResult LoadPermission()
        {
            //List<Permissions> permissionModel = new List<Permissions>();
            List<PermissionsViewModel> permissionModel = new List<PermissionsViewModel>();
            permissionModel = this._manageClient.GetPermissionDetails();

            return this.PartialView("PermissionSetting_PV", permissionModel);
        }

        /// <summary>
        /// Load permission
        /// </summary>
        /// <returns>loaded Partial View</returns>
        [HttpPost]
        public ActionResult SavePermissionDetails(List<PermissionsViewModel> modelList)
        {

            int result = this._manageClient.SavePermissionDetails(modelList);

            if (result == 1)
            {
                this.TempData["SucessAlert"] = "1";


            }
            else
            {
                this.TempData["SucessAlert"] = "0";


            }
            return this.RedirectToAction("AdminDashboard", "AdminDashboard", new { Area = "Admin" });


        }

    }
}