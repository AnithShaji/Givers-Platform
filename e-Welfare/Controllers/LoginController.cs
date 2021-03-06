﻿using e_Welfare.BLL.BusinessObjects;
using e_Welfare.BLL.Interfaces;
using e_Welfare.DTO.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace e_Welfare.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// Calling Client
        /// </summary>
        private HttpClient client;

        /// <summary>
        /// manage User Login
        /// </summary>
        private readonly IManageUserLogin _manageUserLogin;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        public LoginController()
        {
            this._manageUserLogin = new ManageUserLogin();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class
        /// </summary>
        /// <param name="manageUserLogin">manage User Login</param>
        public LoginController(ManageUserLogin manageUserLogin)
        {
            this._manageUserLogin = manageUserLogin;
        }

        /// <summary>
        /// Show login details
        /// </summary>
        /// <param name="loginType">user or admin type</param>
        /// <returns>login details view</returns>
        [HttpGet]
        public ActionResult LoginDetails(string loginType)
        {
            this.TempData["LoginType"] = loginType;
            return this.View();
        }

        /// <summary>
        /// Show login details
        /// </summary>
        /// <param name="userName">user Name</param>
        /// <param name="passWord">the password</param>
        /// <param name="disclaimerAccept">1 if disclaimer has read</param>
        /// <returns>login details view</returns>
        public ActionResult LoginDetails(string userName, string passWord, int? disclaimerAccept)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
            {
                this.TempData["Message"] = 0;
                return this.View();
            }

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(passWord))
            {
                var userDetails = this._manageUserLogin.AuthenticateTemp(userName, passWord);
                if (userDetails != null)
                {
                    if (userDetails.UserID > 0)
                    {
                        var userType = this._manageUserLogin.GetUserTypeByTypeId(userDetails.UserTypeID);


                        this.Session["LoggedInUser"] = userDetails.FirstName + " " + " " + userDetails.MiddleName + " " + userDetails.LastName;
                        this.Session["UserID"] = userDetails.UserID;
                        this.Session["UserStatus"] = userDetails.UserStatus.UserStatusCode;
                        this.Session["UserType"] = userDetails.UserType.UserTypeCode;
                        this.Session["WelfareSection"] = userDetails.WelfareSection;
                        if (userType.UserTypeName.ToLower() == "admin")
                        {
                            return this.RedirectToAction("AdminDashboard", "AdminDashboard", new { Area = "Admin" });
                        }
                        else
                        {
                            return this.RedirectToAction("ClientDashboard", "ClientDashboard", new { Area = "Client", userStatus = userDetails.UserStatus.UserStatusCode });
                            //if (userType.UserTypeCode == "NPATN")
                            //{
                            //    return this.RedirectToAction("Index", "PatientDashboard", new { Area = "Patient" });
                            //}
                            //else
                            //{
                            //    return this.RedirectToAction("PatientListing", "PatientListing", new { Area = "Client" });
                            //}
                        }

                    }
                }
                else
                {
                    this.TempData["Message"] = -1;
                    return this.View();
                }
            }

            return this.View();
        }

        /// <summary>
        /// Show login details
        /// </summary>
        /// <param name="userName">user Name</param>
        /// <param name="passWord">the password</param>
        /// <returns>response Message</returns>
        public ActionResult LoginDetails_Token(string userName, string passWord)
        {
            ////string url = ConfigurationManager.AppSettings["MonnieAPIUrl"] + "Auth/Api/Authenticate/Authenticate";
            ////HttpClient client = new HttpClient();
            ////client.DefaultRequestHeaders.Accept.Clear();
            ////var byteArray = Encoding.ASCII.GetBytes(userName + ":" + passWord);
            ////client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            ////client.BaseAddress = new Uri(url);
            ////HttpResponseMessage responseMessage = client.GetAsync(url).Result;
            ////if (responseMessage.IsSuccessStatusCode)
            ////{
            ////}

            ////return this.View();
            ////new MonnieAPIService().AuthorizeUser("client", "password");
            return this.RedirectToAction("Navigation");
        }

        /// <summary>
        /// Navigation details
        /// </summary>
        /// <returns>response Message</returns>
        public ActionResult Navigation()
        {
            ////new MonnieAPIService(" ", " ").GetNavigations(1);
            return this.View();
        }

        /// <summary>
        /// Forgot password
        /// </summary>
        /// <returns>forgot password view</returns>
        public ActionResult ForgotPassword()
        {
            return this.View();
        }

        /// <summary>
        /// Logout User
        /// </summary>
        /// <returns>forgot password view</returns>
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return this.RedirectToAction("LoginDetails");
        }
    }
}