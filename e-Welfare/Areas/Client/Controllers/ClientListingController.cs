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

namespace e_Welfare.Areas.Client.Controllers
{
    public class ClientListingController : Controller
    {
        private HttpClient client;

        /// <summary>
        /// manage client 
        /// </summary>
        private readonly IManageClient _manageClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientListingController"/> class.
        /// </summary>
        public ClientListingController()
        {
            this._manageClient = new ManageClient();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientListingController"/> class
        /// </summary>
        /// <param name="manageClient">manage Client</param>
        public ClientListingController(ManageClient manageClient)
        {
            this._manageClient = manageClient;
        }

        // GET: Client/ClentListing
        public ActionResult Index()
        {
            return View();
        }

        //---e-Welfare Client:Medicine(Patient),Education(Student),Food(Applicant)--

        /// <summary>
        /// Load content to container on side tab click
        /// </summary>
        /// <param name="tab">tab Name clicked</param>
        /// <param name="userType">userType</param>
        /// <param name="extraDetail">the medicine id for edit</param>
        /// <returns>loaded Partial View</returns>
        public ActionResult LoadContent(string tab, string userType, int? extraDetail)
        {
            if (tab == "addMedicineTab")
            {
                MedicineViewModel medicineViewModel = new MedicineViewModel();
                if (extraDetail != null && extraDetail > 0)
                {
                    medicineViewModel = this._manageClient.GetMedicineDetailsById(extraDetail.Value);
                }
                return this.PartialView("AddEditMedicine_PV", medicineViewModel);
            }
            else if (tab == "addFoodItemTab")
            {
                FoodViewModel foodViewModel = new FoodViewModel();
                if (extraDetail != null && extraDetail > 0)
                {
                    foodViewModel = this._manageClient.GetFoodDetailsById(extraDetail.Value);
                }
                return this.PartialView("AddEditFood_PV", foodViewModel);
            }
            else if (tab == "addTrainingTab")
            {
                TrainingViewModel trainingViewModel = new TrainingViewModel();
                if (extraDetail != null && extraDetail > 0)
                {
                    trainingViewModel = this._manageClient.GetTrainingDetailsById(extraDetail.Value);
                }
                return this.PartialView("AddEditTraining_PV", trainingViewModel);
            }
            
            else if (tab == "addPatientTab")
            {
                PatientViewModel patientViewModel = new PatientViewModel();
                int userID = 0;
                if (this.Session["UserType"] != null)
                {
                    if (this.Session["UserType"].ToString() != "ADMN")
                    {
                        if (this.Session["UserID"] != null)
                        {
                            userID = Convert.ToInt32(this.Session["UserID"]);
                        }

                    }
                }

                if (extraDetail != null && extraDetail > 0)
                {
                    patientViewModel = this._manageClient.GetPatientDetailsById(extraDetail.Value);
                }
                else
                {
                    if (userID > 0)
                    {
                        patientViewModel = this._manageClient.GetPatientDetailsById(userID);
                       
                    }

                }

                if (this.Session["UserType"] != null)
                {

                    patientViewModel.UserType = this.Session["UserType"].ToString();
                    
                }
                        return this.PartialView("AddEditPatient_PV", patientViewModel);
            }
            else if (tab == "addFoodApplicantTab")
            {
                ApplicantViewModel applicantViewModel = new ApplicantViewModel();
                int userID = 0;
                if (this.Session["UserType"] != null)
                {
                    if (this.Session["UserType"].ToString() != "ADMN")
                    {
                        if (this.Session["UserID"] != null)
                        {
                            userID = Convert.ToInt32(this.Session["UserID"]);
                        }

                    }
                }

                if (extraDetail != null && extraDetail > 0)
                {
                    applicantViewModel = this._manageClient.GetApplicantDetailsById(extraDetail.Value);
                }
                else
                {
                    if (userID > 0)
                    {
                        applicantViewModel = this._manageClient.GetApplicantDetailsById(userID);
                    }

                }

                return this.PartialView("AddEditApplicant_PV", applicantViewModel);
            }
            else
            {
                var itemList = this._manageClient.LoadContent(tab, userType);


                if (tab == "patientListTab")
                {
                    return this.PartialView("PatientList_PV", itemList.PatientListingInstance);
                }
                else if (tab == "foodApplicantListTab")
                {
                    return this.PartialView("FoodApplicantList_PV", itemList.StudentListingInstance);
                }
                else if (tab == "trainingListTab")
                {
                    return this.PartialView("TrainingList_PV", itemList.TrainingListingInstance);
                }
                else if (tab == "studentListTab")
                {
                    return this.PartialView("StudentList_PV", itemList.StudentListingInstance);
                }
                else if (tab == "medicineListTab")
                {
                    return this.PartialView("MedicineList_PV", itemList.MedicineListingInstance);
                }
                else if (tab == "foodListTab")
                {
                    return this.PartialView("FoodList_PV", itemList.FoodListingInstance);
                }

            }

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { result = "-1" }
            };
        }

        /// <summary>
        /// Add or Edit Medicine details
        /// </summary>
        /// <param name="model">Medicine View Model</param>
        /// <returns>medicine list view</returns>
        public ActionResult SaveMedicineDetails(MedicineViewModel model)
        {
            if (model != null)
            {
                var medicineDetails = this._manageClient.SaveMedicineDetails(model);

                if (medicineDetails.MedicineID == 0)
                {
                    this.TempData["SucessAlert"] = "1";


                }
                else
                {
                    this.TempData["SucessAlert"] = "2";


                }


                if (this.Session["UserType"] != null)
                {
                    if (this.Session["UserType"].ToString() != "ADMN")
                    {
                        return this.RedirectToAction("ClientDashboard", "ClientDashboard", new { Area = "Client", userStatus = this.Session["UserStatus"].ToString() });
                    }
                    else
                    {
                        return this.RedirectToAction("AdminDashboard", "AdminDashboard", new { Area = "Admin" });
                    }
                }
            }

            return this.RedirectToAction("AdminDashboard", "AdminDashboard", new { Area = "Admin" });
        }


        /// <summary>
        ///Save Training details
        /// </summary>
        /// <param name="model">Training View Model</param>
        /// <returns>training list view</returns>
        public ActionResult SaveTrainingDetails(TrainingViewModel model)
        {
            if (model != null)
            {
                var trainingDetails = this._manageClient.SaveTrainingDetails(model);

                if (trainingDetails.TrainingID == 0)
                {
                    this.TempData["SucessAlert"] = "1";


                }
                else
                {
                    this.TempData["SucessAlert"] = "2";


                }


                if (this.Session["UserType"] != null)
                {
                    if (this.Session["UserType"].ToString() != "ADMN")
                    {
                        return this.RedirectToAction("ClientDashboard", "ClientDashboard", new { Area = "Client", userStatus = this.Session["UserStatus"].ToString() });
                    }
                    else
                    {
                        return this.RedirectToAction("AdminDashboard", "AdminDashboard", new { Area = "Admin" });
                    }
                }
            }

            return this.RedirectToAction("AdminDashboard", "AdminDashboard", new { Area = "Admin" });
        }

        /// <summary>
        /// Add or Edit Food details
        /// </summary>
        /// <param name="model">Food View Model</param>
        /// <returns>food item list view</returns>
        public ActionResult SaveFoodItemDetails(FoodViewModel model)
        {
            if (model != null)
            {
                var foodDetails = this._manageClient.SaveFoodItemDetails(model);

                if (foodDetails.FoodID == 0)
                {
                    this.TempData["SucessAlert"] = "1";


                }
                else
                {
                    this.TempData["SucessAlert"] = "2";


                }


                if (this.Session["UserType"] != null)
                {
                    if (this.Session["UserType"].ToString() != "ADMN")
                    {
                        return this.RedirectToAction("ClientDashboard", "ClientDashboard", new { Area = "Client", userStatus = this.Session["UserStatus"].ToString() });
                    }
                    else
                    {
                        return this.RedirectToAction("AdminDashboard", "AdminDashboard", new { Area = "Admin" });
                    }
                }
            }

            return this.RedirectToAction("AdminDashboard", "AdminDashboard", new { Area = "Admin" });
        }


        /// <summary>
        /// Add or Edit Patient details
        /// </summary>
        /// <param name="model">Patient View Model</param>
        /// <returns>patient list view</returns>
        public ActionResult SavePatientDetails(PatientViewModel model)
        {
            if (model != null)
            {
                if (model.UserType == "CLNEW")
                {
                    bool isUploaded = false;
                    if (model.MedReceipt != null && model.MedReceipt.ContentLength > 0)
                    {
                        string fName = Path.GetFileNameWithoutExtension(model.MedReceipt.FileName) + "-" + DateTime.Now.ToString("yyMMddHHmmss") + Path.GetExtension(model.MedReceipt.FileName);
                        string tempFolderName = ConfigurationManager.AppSettings["ReceiptUploaded"];
                        string tempFolderPath = Server.MapPath("~/" + tempFolderName);

                        if (FileHelper.CreateFolderIfNeeded(tempFolderPath))
                        {
                            try
                            {
                                var fileUrl = Path.Combine(tempFolderPath, fName);
                                model.MedReceipt.SaveAs(fileUrl);
                                model.MedFilePath = "~/" + tempFolderName + "/" + fName;
                                isUploaded = true;
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }
                        }
                    }
                }
                var patientDetails = this._manageClient.SavePatientDetails(model);

                if (patientDetails.UserID == 0)
                {
                    this.TempData["SucessAlert"] = "1";
                    return this.RedirectToAction("AdminDashboard", "AdminDashboard", new { Area = "Admin" });
                }
                else
                {
                    this.TempData["SucessAlert"] = "2";
                    return this.RedirectToAction("AdminDashboard", "AdminDashboard", new { Area = "Admin" });
                }
            }
            return this.RedirectToAction("AdminDashboard", "AdminDashboard", new { Area = "Admin" });
        }
    }
}