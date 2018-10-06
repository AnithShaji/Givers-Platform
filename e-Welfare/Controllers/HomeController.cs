using e_Welfare.BLL.BusinessObject;
using e_Welfare.BLL.Interfaces;
using e_Welfare.DTO.ViewModel;
using e_Welfare.Web.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace e_Welfare.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Calling Client
        /// </summary>
        private HttpClient client;

        /// <summary>
        /// manage client 
        /// </summary>
        private readonly IManageClient _manageClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        public HomeController()
        {
            this._manageClient = new ManageClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class
        /// </summary>
        /// <param name="manageClient">manage Client</param>
        public HomeController(ManageClient manageClient)
        {
            this._manageClient = manageClient;
        }

        public ActionResult Index(string dashboardTab)
        {
            if (dashboardTab == "About")
            {
                return this.PartialView("_AboutPV");
            }
            else if (dashboardTab == "Contact")
            {
                return this.PartialView("_ContactPV");
            }

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Register User details
        /// </summary>
        /// <param name="model">user Registration View Model</param>
        /// <returns>registration details view</returns>
        public ActionResult RegisterUser(UserRegistrationViewModel model)
        {
            var md = model;
            bool isUploaded = false;
            //if (this.Session["LoggedInUser"] != null)
            //{
            //    UserLoginViewModel loggedInUser = (UserLoginViewModel)HttpContext.Session["LoggedInUser"];
            //    model.CreatedByID = loggedInUser.UserID;
            //    model.ModifiedByID = loggedInUser.UserID;
            //}

            if (model != null)
            {
                if (model.FileUpload != null && model.FileUpload.ContentLength > 0)
                {
                    string fName = Path.GetFileNameWithoutExtension(model.FileUpload.FileName) + "-" + DateTime.Now.ToString("yyMMddHHmmss") + Path.GetExtension(model.FileUpload.FileName);
                    string tempFolderName = ConfigurationManager.AppSettings["FileUploaded"];
                    string tempFolderPath = Server.MapPath("~/" + tempFolderName);

                    if (FileHelper.CreateFolderIfNeeded(tempFolderPath))
                    {
                        try
                        {
                            var fileUrl = Path.Combine(tempFolderPath, fName);
                            model.FileUpload.SaveAs(fileUrl);
                            model.FilePath = "~/" + tempFolderName + "/" + fName;
                            isUploaded = true;
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                }
                var userDetails = this._manageClient.RegisterClient(model);
                if (userDetails.UserExistStatus == 0)
                {
                    this.TempData["SucessAlert"] = "1";
                    return View("Register");
                }
                else
                {
                    this.TempData["SucessAlert"] = "-1";
                    return View("Index");
                }
            }

            return View("Register");
        }

        /// <summary>
        /// Render File Upload Partial View
        /// </summary>
        /// <returns>File Upload Partial View</returns>
        [ValidateInput(false)]
        public ActionResult FileUploadPartialView()
        {
            //var applicantList = this._manageClient.ApplicantDashboardList(tabName);

            return this.PartialView("FileUploadPV");
        }
    }
}