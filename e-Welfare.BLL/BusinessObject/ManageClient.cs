using e_Welfare.BLL.BusinessObjects.Common;
using e_Welfare.BLL.Interfaces;
using e_Welfare.BLL.Persistence;
using e_Welfare.DTO;
using e_Welfare.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.WebPages.Html;

namespace e_Welfare.BLL.BusinessObject
{
    /// <summary> 
    /// Class for managing client 
    /// </summary>
    public class ManageClient : IManageClient
    {
        #region Private Fields

        /// <summary> 
        /// Unit of work
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Contructor

        /// <summary> 
        /// Initializes a new instance of the <see cref="ManageClient"/> class.
        /// </summary>
        public ManageClient()
        {
            this.unitOfWork = new UnitOfWork();
        }

        /// <summary> 
        /// Initializes a new instance of the <see cref="ManageClient"/> class.
        /// </summary>
        /// <param name="uWork">the unit of work</param>
        public ManageClient(IUnitOfWork uWork)
        {
            this.unitOfWork = uWork;
        }

        #endregion


        #region Public member methods.

        /// <summary>
        /// Saves the patient Education
        /// </summary>
        /// <param name="model">patient Education view model</param>
        /// <returns>ID of saved object</returns>
        //[HttpPost]
        //[ActionName("RegisterClient")]
        public UserRegistrationViewModel RegisterClient(UserRegistrationViewModel model)
        {
            Users obj;
            if (model.UserID == 0)
            {
                obj = new Users();
                obj.CreatedDate = DateTime.Now;
                obj.CreatedByID = 1;
                obj.UserStatusID = 1;
                obj.UserTypeID = 5;
            }
            else
            {
                obj = this.GetUserDetails(model.UserID);
            }

            obj.FirstName = model.FirstName;
            obj.MiddleName = model.MiddleName;
            obj.LastName = model.LastName;
            obj.EmailAddress = model.EmailAddress;
            obj.Telephone = model.Telephone;
            obj.Mobile = model.Mobile;

            obj.DOB = model.DOB;
            obj.RegDocumentPath = model.FilePath;
            obj.FlatHouseNameNumber = model.FlatHouseNameNumber;
            obj.Address1 = model.Address1;
            obj.Address2 = model.Address2;
            obj.City = model.City;

            obj.ModifiedByID = 1;
            obj.ModifiedDate = DateTime.Now;
            var userInstance = this.GetUserDetailsByEmail(model.EmailAddress);

            if (userInstance != null)
            {
                model.UserExistStatus = 0;//Already registered
                return model;
            }
            else
            {
                obj = this.SaveUser(obj);
                model.UserID = obj.UserID;
                model.UserExistStatus = 1;
                return model;
            }
        }

        /// <summary>
        /// Saves the permission details
        /// </summary>
        /// <param name="modelList">Permissions View model</param>
        /// <returns>success or not</returns>
        //[HttpPost]
        public int SavePermissionDetails(List<PermissionsViewModel> modelList)
        {
            Permissions obj;
            if (modelList != null && modelList.Count > 0)
            {
                foreach (var val in modelList)
                {
                    obj = this.unitOfWork.PermissionRepository.GetByID(val.PermissionId);
                    obj.Add = val.Add;
                    obj.Edit = val.Edit;
                    this.unitOfWork.PermissionRepository.Update(obj);
                    this.unitOfWork.Save();
                }
                return 1;

            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Get Status Applicant Count
        /// </summary>
        /// <returns>message count</returns>
        public List<int> GetStatusCount()
        {
            List<int> dataList = this.unitOfWork.UserRepository.GetQuery(x => x.UserType.UserTypeCode != "ADMN").Select(x => x.UserStatusID).ToList();

            List<int> satusList = new List<int>();
            if (dataList != null && dataList.Count > 0)
            {
                var countNew = dataList.Contains(1) ? dataList.Where(x => x == 1).Count() : 0;// New
                satusList.Add(countNew);
                var countInprocess = dataList.Contains(2) ? dataList.Where(x => x == 2).Count() : 0;// In process
                satusList.Add(countInprocess);
                var countAccepted = dataList.Contains(3) ? dataList.Where(x => x == 3).Count() : 0;// Accepted
                satusList.Add(countAccepted);
                var countRejected = dataList.Contains(4) ? dataList.Where(x => x == 4).Count() : 0;// Rejected
                satusList.Add(countRejected);

            }

            return satusList;
        }

        /// <summary>
        /// Get Medicine Inventory
        /// </summary>
        /// <returns> Medicine Inventory</returns>
        public List<Medicine> GetMedicineInventory()
        {
            List<Medicine> dataList = this.unitOfWork.MedicineRepository.GetQuery(null).ToList();

            return dataList;
        }

        /// <summary>
        /// Gets user details by user ID
        /// </summary>
        /// <param name="userID">user ID</param>
        /// <returns>Return user by id</returns>
        public Users GetUserDetails(int userID)
        {
            return this.unitOfWork.UserRepository.GetQuery(p => p.UserID == userID).FirstOrDefault();
        }

        /// <summary>
        /// Gets user details by email Address
        /// </summary>
        /// <param name="emailAddress">email Address</param>
        /// <returns>Return user by id</returns>
        public Users GetUserDetailsByEmail(string emailAddress)
        {
            return this.unitOfWork.UserRepository.GetQuery(p => p.EmailAddress == emailAddress).FirstOrDefault();
        }

        /// <summary>
        /// save user 
        /// </summary>
        /// <param name="model">user model</param>
        /// <returns>Return user</returns>
        public Users SaveUser(Users model)
        {
            if (model.UserID == 0)
            {
                this.unitOfWork.UserRepository.Insert(model);
            }
            else
            {
                this.unitOfWork.UserRepository.Update(model);
            }

            this.unitOfWork.Save();
            var userId = model.UserID;
            return model;
        }

        /// <summary>
        /// Applicant Dashboard List
        /// </summary>
        /// <param name="tabName">tab Name</param>
        /// <returns>Return applicant list</returns>
        public List<ApplicantListingViewModel> ApplicantDashboardList(string tabName)
        {
            var userList = this.unitOfWork.UserRepository.GetQuery(x => x.UserType.UserTypeCode != "ADMN" && x.UserStatus.UserStatusCode == tabName).ToList();
            List<ApplicantListingViewModel> applicantList = new List<ApplicantListingViewModel>();
            if (userList != null && userList.Count > 0)
            {
                foreach (var user in userList)
                {
                    ApplicantListingViewModel applicant = new ApplicantListingViewModel();
                    applicant.ApplicantID = "EW_00" + user.UserID;
                    applicant.UserID = user.UserID;
                    applicant.ApplicantName = user.FirstName + " " + user.MiddleName + " " + user.LastName;
                    applicant.RequstedDate = user.CreatedDate.ToShortDateString();
                    applicant.SectionName = user.UserType.UserTypeCode;
                    applicant.AttachmentPath = user.RegDocumentPath;
                    applicant.ApprovalStatus = false;
                    if (!string.IsNullOrEmpty(user.WelfareSection))
                    {
                        applicant.MedicalSection = user.WelfareSection.Contains("M");
                        applicant.EducationSection = user.WelfareSection.Contains("E");
                        applicant.FoodSection = user.WelfareSection.Contains("F");
                    }
                    applicant.UserStatusCode = tabName;
                    applicantList.Add(applicant);
                }
            }
            return applicantList;
        }

        /// <summary>
        /// Get Permission details
        /// </summary>
        /// <returns>Return applicant list</returns>
        public List<PermissionsViewModel> GetPermissionDetails()
        {
            var permissionDetailList = this.unitOfWork.PermissionRepository.GetQuery(null).ToList();

            List<PermissionsViewModel> applntPermissionList = new List<PermissionsViewModel>();
            if (permissionDetailList != null && permissionDetailList.Count > 0)
            {
                foreach (var permission in permissionDetailList)
                {
                    PermissionsViewModel applicant = new PermissionsViewModel();
                    applicant.ApplicantStringID = "EW_00" + permission.UserID;
                    applicant.UserID = permission.UserID;
                    applicant.PermissionId = permission.PermissionId;
                    applicant.ApplicantName = permission.User.FirstName + " " + permission.User.MiddleName + " " + permission.User.LastName;
                    applicant.Add = permission.Add;
                    applicant.Edit = permission.Edit;

                    applntPermissionList.Add(applicant);
                }
            }

            return applntPermissionList;
        }


        /// <summary>
        /// Load content for container
        /// </summary>
        /// <param name="tab">tab</param>
        /// <param name="userType">userType</param>
        /// <returns>Return list</returns>
        public SelectListInsatnceViewModel LoadContent(string tab, string userType)
        {
            SelectListInsatnceViewModel listType = new SelectListInsatnceViewModel();
            listType.PatientListingInstance = new List<PatientListingViewModel>();
            listType.MedicineListingInstance = new List<MedicineListingViewModel>();
            listType.FoodListingInstance = new List<FoodListingViewModel>();
            listType.ApplicantListingInstance = new List<FoodApplicantListingViewModel>();
            listType.StudentListingInstance = new List<StudentListingViewModel>();
            listType.TrainingListingInstance = new List<TrainingListingViewModel>();

            if (tab == "patientListTab")
            {
                var itemList = this.unitOfWork.UserRepository.GetQuery(x => x.UserType.UserTypeCode != "ADMN" && x.WelfareSection != null && x.WelfareSection.Contains("M")).ToList();

                if (itemList != null && itemList.Count > 0)
                {
                    foreach (var patient in itemList)
                    {
                        PatientListingViewModel patientInstance = new PatientListingViewModel();
                        patientInstance.PatientStringID = "EW_00" + patient.UserID;
                        patientInstance.PatientID = patient.UserID;
                        patientInstance.PatientName = patient.FirstName + " " + patient.MiddleName + " " + patient.LastName;
                        patientInstance.RequstedDate = String.Format("{0:d}", patient.CreatedDate).Replace("-", "/");
                        patientInstance.DOB = String.Format("{0:d}", patient.DOB).Replace("-", "/");
                        //patientInstance.SectionName = patient.UserType.UserTypeCode;
                        patientInstance.Attachment = patient.MedicineReceipt;
                        patientInstance.Checked = false;
                        if (!string.IsNullOrEmpty(patient.DeliveredSupport))
                        {
                            patientInstance.DeliveryChecked = patient.DeliveredSupport.Contains("M");
                        }

                        var valstring = this.GetAllMedicinesByUserID(patient.UserID);
                        if (valstring != null && valstring.Count > 0)
                        {
                            patientInstance.MedicineString = (string.Join(",", valstring.Select(x => x.Text).ToArray()));

                        }

                        listType.PatientListingInstance.Add(patientInstance);
                    }
                }
            }
            else if (tab == "medicineListTab")
            {
                var itemList = this.unitOfWork.MedicineRepository.GetQuery(null).ToList();

                if (itemList != null && itemList.Count > 0)
                {
                    foreach (var medicine in itemList)
                    {
                        MedicineListingViewModel medicineInstance = new MedicineListingViewModel();
                        medicineInstance.MedicineStringID = "EW_00" + medicine.MedicineID;
                        medicineInstance.MedicineID = medicine.MedicineID;
                        medicineInstance.MedicineName = medicine.MedicineName;
                        medicineInstance.Price = medicine.Price;
                        medicineInstance.Quantity = medicine.Quantity.ToString();
                        medicineInstance.IssueDate = medicine.IssueDate.ToShortDateString();
                        listType.MedicineListingInstance.Add(medicineInstance);
                    }
                }
            }
            else if (tab == "foodListTab")
            {
                var itemList = this.unitOfWork.FoodRepository.GetQuery(null).ToList();

                if (itemList != null && itemList.Count > 0)
                {
                    foreach (var food in itemList)
                    {
                        FoodListingViewModel foodInstance = new FoodListingViewModel();
                        foodInstance.FoodStringID = "EW_00" + food.FoodID;
                        foodInstance.FoodID = food.FoodID;
                        foodInstance.FoodName = food.FoodName;
                        foodInstance.Price = food.Price;
                        foodInstance.Quantity = food.Quantity;
                        foodInstance.IssueDate = food.IssueDate.ToShortDateString();
                        listType.FoodListingInstance.Add(foodInstance);
                    }
                }
            }
            else if (tab == "foodApplicantListTab")
            {
                var itemList = this.unitOfWork.UserRepository.GetQuery(x => x.UserType.UserTypeCode != "ADMN" && x.WelfareSection != null && x.WelfareSection.Contains("F")).ToList();

                if (itemList != null && itemList.Count > 0)
                {
                    foreach (var applicnt in itemList)
                    {
                        FoodApplicantListingViewModel applicantInstance = new FoodApplicantListingViewModel();
                        applicantInstance.ApplicantStringID = "EW_00" + applicnt.UserID;
                        applicantInstance.ApplicantID = applicnt.UserID;
                        applicantInstance.ApplicantName = applicnt.FirstName + " " + applicnt.MiddleName + " " + applicnt.LastName;
                        applicantInstance.RequstedDate = String.Format("{0:d}", applicnt.CreatedDate).Replace("-", "/");
                        applicantInstance.DOB = String.Format("{0:d}", applicnt.DOB).Replace("-", "/");
                        //patientInstance.SectionName = patient.UserType.UserTypeCode;
                        applicantInstance.Attachment = applicnt.MedicineReceipt;
                        applicantInstance.Checked = false;
                        if (!string.IsNullOrEmpty(applicnt.DeliveredSupport))
                        {
                            applicantInstance.DeliveryChecked = applicnt.DeliveredSupport.Contains("M");
                        }

                        var valstring = this.GetAllMedicinesByUserID(applicnt.UserID);
                        if (valstring != null && valstring.Count > 0)
                        {
                            applicantInstance.FoodItemString = (string.Join(",", valstring.Select(x => x.Text).ToArray()));

                        }

                        listType.ApplicantListingInstance.Add(applicantInstance);
                    }

                }

            }
            else if (tab == "trainingListTab")
            {
                var itemList = this.unitOfWork.TrainingRepository.GetQuery(null).ToList();

                if (itemList != null && itemList.Count > 0)
                {
                    foreach (var training in itemList)
                    {
                        TrainingListingViewModel trainingInstance = new TrainingListingViewModel();
                        trainingInstance.TrainingStringID = "EW_00" + training.TrainingID;
                        trainingInstance.TrainingID = training.TrainingID;
                        trainingInstance.TrainingName = training.TrainingName;
                        trainingInstance.StartDate = training.StartDate.Value.ToShortDateString();
                        trainingInstance.EndDate = training.EndDate.Value.ToShortDateString();
                        listType.TrainingListingInstance.Add(trainingInstance);
                    }
                }
            }
            else if (tab == "studentListTab")
            {
                var itemList = this.unitOfWork.UserRepository.GetQuery(x => x.UserType.UserTypeCode != "ADMN" && x.WelfareSection != null && x.WelfareSection.Contains("E")).ToList();

                if (itemList != null && itemList.Count > 0)
                {
                    foreach (var applicnt in itemList)
                    {
                        StudentListingViewModel applicantInstance = new StudentListingViewModel();
                        applicantInstance.StudentStringID = "EW_00" + applicnt.UserID;
                        applicantInstance.StudentID = applicnt.UserID;
                        applicantInstance.StudentName = applicnt.FirstName + " " + applicnt.MiddleName + " " + applicnt.LastName;
                        applicantInstance.RequstedDate = String.Format("{0:d}", applicnt.CreatedDate).Replace("-", "/");
                        applicantInstance.DOB = String.Format("{0:d}", applicnt.DOB).Replace("-", "/");
                        //patientInstance.SectionName = patient.UserType.UserTypeCode;
                        applicantInstance.Attachment = applicnt.MedicineReceipt;
                        applicantInstance.Checked = false;
                        if (!string.IsNullOrEmpty(applicnt.DeliveredSupport))
                        {
                            applicantInstance.DeliveryChecked = applicnt.DeliveredSupport.Contains("E");
                        }

                        listType.StudentListingInstance.Add(applicantInstance);
                    }

                }

            }

            return listType;
        }

        /// <summary>
        /// To activate the Applicant status
        /// </summary>
        /// <param name="chekdApplicantIds">chekd Applicant Ids</param>
        /// <returns>return true if updated</returns>
        public bool CheckApprovalStatus(List<string> chekdApplicantIds)
        {
            List<int> listofApplicantIds = chekdApplicantIds.ConvertAll(s => Int32.Parse(s));
            foreach (var applicantID in listofApplicantIds)
            {
                Users applicnt = this.unitOfWork.UserRepository.GetByID(Convert.ToInt32(applicantID));
                if (applicnt != null)
                {
                    applicnt.UserStatusID = 2;//INPROCESS master tbl UserStatusID=2
                    applicnt.Username = applicnt.EmailAddress;
                    applicnt.Password = GenerateRandomPassword(applicnt.EmailAddress);

                    this.unitOfWork.UserRepository.Update(applicnt);
                    this.unitOfWork.Save();
                    this.SendMailToUser(applicnt);
                }
            }
            return true;
        }

        /// <summary>
        /// To activate the Applicant status
        /// </summary>
        /// <param name="chekdSections">chekd Sections</param>
        /// <param name="userID">user id</param>
        /// <returns>return true if updated</returns>
        public bool CheckedClientSection(List<string> chekdSections, int userID)
        {
            if (chekdSections != null && chekdSections.Count > 0)
            {
                if (userID > 0)
                {
                    var chekdSectionString = String.Join(",", chekdSections);
                    Users applicnt = this.unitOfWork.UserRepository.GetByID(Convert.ToInt32(userID));

                    if (applicnt != null)
                    {
                        applicnt.WelfareSection = chekdSectionString;

                        this.unitOfWork.UserRepository.Update(applicnt);
                        this.unitOfWork.Save();
                    }
                }

            }


            return true;
        }

        /// <summary>
        /// To activate the Applicant section
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>return true if updated</returns>
        public bool ActivateClientSection(int userID)
        {
            if (userID > 0)
            {
                Users applicnt = this.unitOfWork.UserRepository.GetByID(Convert.ToInt32(userID));

                if (applicnt != null)
                {
                    applicnt.UserStatusID = 3;//update status to accepted
                    this.unitOfWork.UserRepository.Update(applicnt);
                    this.unitOfWork.Save();

                    //chek if permission exist previously
                    var exist = this.unitOfWork.PermissionRepository.Get(x => x.UserID == applicnt.UserID).Select(x => x.PermissionId).ToList();

                    if (exist != null && exist.Count > 0)
                    {
                        foreach (var usrPermisionID in exist)
                        {
                            this.unitOfWork.PermissionRepository.Delete(usrPermisionID);
                            this.unitOfWork.Save();
                        }
                    }

                    //once an applicant is accepted add him to permission table
                    Permissions applicntPermission = new Permissions();
                    applicntPermission.UserID = applicnt.UserID;
                    applicntPermission.Add = false;
                    applicntPermission.Edit = false;

                    this.unitOfWork.PermissionRepository.Insert(applicntPermission);
                    this.unitOfWork.Save();
                }

            }
            return true;
        }

        /// <summary>
        /// Get Checked Client Section  
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Return list</returns>
        public ClientDashboardTypeViewModel GetCheckedClientSection(int userID)
        {
            var user = this.unitOfWork.UserRepository.GetQuery(x => x.UserID == userID).FirstOrDefault();
            ClientDashboardTypeViewModel clientDetail = new ClientDashboardTypeViewModel();
            if (user != null)
            {
                if (!string.IsNullOrEmpty(user.WelfareSection))
                {
                    clientDetail.MedicalSection = user.WelfareSection.Contains("M");
                    clientDetail.EducationSection = user.WelfareSection.Contains("E");
                    clientDetail.FoodSection = user.WelfareSection.Contains("F");
                }
            }
            return clientDetail;
        }

        /// <summary>
        /// Creates a new password from email
        /// </summary>
        /// <param name="email">email address </param>
        /// <returns>Returns newly generated username</returns> 
        public string GenerateRandomPassword(string email)
        {
            string strPwdchar = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // string of character from which we will choose username's characters

            string result = email.Substring(0, 3);
            string strPassword = result;  //// string to store randomly generated password
            Random rnd = new Random();
            //// no. of iteration will be equal to username length [here username length is 8]
            for (int i = 0; i <= 3; i++)
            {
                int iRandom = rnd.Next(0, strPwdchar.Length - 1);
                strPassword += strPwdchar.Substring(iRandom, 1);
            }

            return strPassword;
        }

        /// <summary> 
        /// Send Mail to user 
        /// </summary>
        /// <param name="userModel">User model</param>
        public void SendMailToUser(Users userModel)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            string path = HttpContext.Current.Request.Url.AbsolutePath;
            string newpth = url.Replace(path, "/Login/LoginDetails?loginType=User");


            CommonClass objCommon = new CommonClass();
            string subject = "E-Welfare : Login credentials  for your account";
            string bodyMessage = string.Empty;
            bodyMessage = "Hi " + userModel.FirstName + " " + userModel.LastName + ","
              + "<br/><br/>"
              + "Please login to the site using following credentials."
              + "<br/>"
              + "Username : " + userModel.Username
              + "<br/>"
              + "Password : " + userModel.Password
              + "</br><br/>"
              + "Yours sincerely,"
              + "<br/>"
              + "E-Welfare Team"
              + "<br/>"
              + "Please Login to the site :  <a href='" + newpth + "' title='Login' class='btn btn-link'> Login</a>";

            bool mailSend = objCommon.SendEmailNotification(subject, bodyMessage, userModel.EmailAddress);
        }

        /// <summary>
        /// save medicine details 
        /// </summary>
        /// <param name="medicineViewModel">medicine view model</param>
        /// <returns>Return medicine detail</returns>
        public MedicineViewModel SaveMedicineDetails(MedicineViewModel medicineViewModel)
        {
            Medicine medicineInstance;

            if (medicineViewModel.MedicineID == 0)
            {
                medicineInstance = new Medicine();
                medicineInstance.CreatedDate = DateTime.Now;
            }
            else
            {
                medicineInstance = this.unitOfWork.MedicineRepository.GetByID(medicineViewModel.MedicineID);
            }

            medicineInstance.MedicineName = medicineViewModel.MedicineName;
            medicineInstance.Price = Convert.ToInt32(medicineViewModel.Price);
            medicineInstance.Quantity = Convert.ToInt32(medicineViewModel.Quantity);
            medicineInstance.IssueDate = DateTime.ParseExact(medicineViewModel.IssueDate, "mm/dd/yyyy", CultureInfo.InvariantCulture);

            if (medicineViewModel.MedicineID == 0)
            {
                this.unitOfWork.MedicineRepository.Insert(medicineInstance);
            }
            else
            {
                this.unitOfWork.MedicineRepository.Update(medicineInstance);
            }

            this.unitOfWork.Save();
            return medicineViewModel;
        }

        /// <summary>
        /// save food item details 
        /// </summary>
        /// <param name="foodViewModel">food view model</param>
        /// <returns>Return medicine detail</returns>
        public FoodViewModel SaveFoodItemDetails(FoodViewModel foodViewModel)
        {
            Food foodInstance;

            if (foodViewModel.FoodID == 0)
            {
                foodInstance = new Food();
                foodInstance.CreatedDate = DateTime.Now;
            }
            else
            {
                foodInstance = this.unitOfWork.FoodRepository.GetByID(foodViewModel.FoodID);
            }

            foodInstance.FoodName = foodViewModel.FoodName;
            foodInstance.Price = foodViewModel.Price;
            foodInstance.Quantity = foodViewModel.Quantity;
            //medicineInstance.IssueDate = DateTime.Parse(medicineViewModel.IssueDate.Replace("/","-"));
            foodInstance.IssueDate = DateTime.ParseExact(foodViewModel.IssueDate, "mm/dd/yyyy", CultureInfo.InvariantCulture);

            if (foodViewModel.FoodID == 0)
            {
                this.unitOfWork.FoodRepository.Insert(foodInstance);
            }
            else
            {
                this.unitOfWork.FoodRepository.Update(foodInstance);
            }

            this.unitOfWork.Save();
            return foodViewModel;
        }

        /// <summary>
        /// get medicine details 
        /// </summary>
        /// <param name="medicineID"> medicineID</param>
        /// <returns>Return medicine detail</returns>
        public MedicineViewModel GetMedicineDetailsById(int medicineID)
        {
            var medicineDetails = this.unitOfWork.MedicineRepository.GetByID(medicineID);
            MedicineViewModel medicineViewModel = new MedicineViewModel();
            medicineViewModel.MedicineID = medicineDetails.MedicineID;
            medicineViewModel.MedicineName = medicineDetails.MedicineName;
            medicineViewModel.Price = medicineDetails.Price.ToString();
            medicineViewModel.Quantity = medicineDetails.Quantity.ToString();

            medicineViewModel.IssueDate = String.Format("{0:d}", medicineDetails.IssueDate).Replace("-", "/");
            medicineViewModel.CreatedDate = medicineDetails.CreatedDate;
            return medicineViewModel;
        }

        /// <summary>
        /// get food details 
        /// </summary>
        /// <param name="foodID"> foodID</param>
        /// <returns>Return food detail</returns>
        public FoodViewModel GetFoodDetailsById(int foodID)
        {
            var foodDetails = this.unitOfWork.FoodRepository.GetByID(foodID);
            FoodViewModel foodViewModel = new FoodViewModel();
            foodViewModel.FoodID = foodDetails.FoodID;
            foodViewModel.FoodName = foodDetails.FoodName;
            foodViewModel.Price = foodDetails.Price;
            foodViewModel.Quantity = foodDetails.Quantity;
            foodViewModel.IssueDate = String.Format("{0:d}", foodDetails.IssueDate).Replace("-", "/");
            foodViewModel.CreatedDate = foodDetails.CreatedDate;
            return foodViewModel;
        }

        /// <summary>
        /// get training details 
        /// </summary>
        /// <param name="trainingID"> trainingID</param>
        /// <returns>Return training detail</returns>
        public TrainingViewModel GetTrainingDetailsById(int trainingID)
        {
            var trainingDetails = this.unitOfWork.TrainingRepository.GetByID(trainingID);
            TrainingViewModel trainingViewModel = new TrainingViewModel();
            trainingViewModel.TrainingID = trainingDetails.TrainingID;
            trainingViewModel.TrainingName = trainingDetails.TrainingName;
            trainingViewModel.StartDate = String.Format("{0:d}", trainingDetails.StartDate).Replace("-", "/");
            trainingViewModel.EndDate = String.Format("{0:d}", trainingDetails.EndDate).Replace("-", "/");
            return trainingViewModel;
        }

        /// <summary>
        /// save training item details 
        /// </summary>
        /// <param name="trainingViewModel">training view model</param>
        /// <returns>Return training detail</returns>
        public TrainingViewModel SaveTrainingDetails(TrainingViewModel trainingViewModel)
        {
            Training trainingInstance;

            if (trainingViewModel.TrainingID == 0)
            {
                trainingInstance = new Training();
            }
            else
            {
                trainingInstance = this.unitOfWork.TrainingRepository.GetByID(trainingViewModel.TrainingID);
            }

            trainingInstance.TrainingName = trainingViewModel.TrainingName;

            trainingInstance.StartDate = DateTime.ParseExact(trainingViewModel.StartDate, "mm/dd/yyyy", CultureInfo.InvariantCulture);
            trainingInstance.EndDate = DateTime.ParseExact(trainingViewModel.EndDate, "mm/dd/yyyy", CultureInfo.InvariantCulture);

            if (trainingViewModel.TrainingID == 0)
            {
                this.unitOfWork.TrainingRepository.Insert(trainingInstance);
            }
            else
            {
                this.unitOfWork.TrainingRepository.Update(trainingInstance);
            }

            this.unitOfWork.Save();
            return trainingViewModel;
        }

        /// <summary>
        /// get patient details 
        /// </summary>
        /// <param name="patientID"> patientID</param>
        /// <returns>Return patient detail</returns>
        public PatientViewModel GetPatientDetailsById(int patientID)
        {
            var patientDetails = this.unitOfWork.UserRepository.GetByID(patientID);
            PatientViewModel patientViewModel = new PatientViewModel();
            patientViewModel.UserID = patientDetails.UserID;
            patientViewModel.FirstName = patientDetails.FirstName;
            patientViewModel.MiddleName = patientDetails.MiddleName;
            patientViewModel.Telephone = patientDetails.Telephone;
            patientViewModel.Mobile = patientDetails.Mobile;
            patientViewModel.LastName = patientDetails.LastName;
            patientViewModel.FlatHouseNameNumber = patientDetails.FlatHouseNameNumber;
            patientViewModel.City = patientDetails.City;
            patientViewModel.Country = patientDetails.Country;
            patientViewModel.Address1 = patientDetails.Address1;
            patientViewModel.Address2 = patientDetails.Address2;
            patientViewModel.DOB = String.Format("{0:d}", patientDetails.DOB).Replace("-", "/");
            patientViewModel.PostCode = patientDetails.PostCode;
            patientViewModel.UserType = patientDetails.UserType.UserTypeCode;
            patientViewModel.Attachment = patientDetails.MedicineReceipt;

            if (!string.IsNullOrEmpty(patientDetails.DeliveredSupport))
            {
                patientViewModel.DeliveryChecked = patientDetails.DeliveredSupport.Contains("M");
            }
            patientViewModel.MedicineList = this.GetAllMedicines();

            var list = this.GetAllMedicinesByUserID(patientID);
            if (list != null && list.Count > 0)
            {
                patientViewModel.MedicineSelectedIds = list.Select(x => x.Value).ToList();
            }

            return patientViewModel;
        }

        /// <summary>
        /// get applicant details 
        /// </summary>
        /// <param name="applicantID"> applicantID</param>
        /// <returns>Return applicant detail</returns>
        public ApplicantViewModel GetApplicantDetailsById(int applicantID)
        {
            var applicantDetails = this.unitOfWork.UserRepository.GetByID(applicantID);
            ApplicantViewModel applicantViewModel = new ApplicantViewModel();
            applicantViewModel.UserID = applicantDetails.UserID;
            applicantViewModel.FirstName = applicantDetails.FirstName;
            applicantViewModel.MiddleName = applicantDetails.MiddleName;
            applicantViewModel.Telephone = applicantDetails.Telephone;
            applicantViewModel.Mobile = applicantDetails.Mobile;
            applicantViewModel.LastName = applicantDetails.LastName;
            applicantViewModel.FlatHouseNameNumber = applicantDetails.FlatHouseNameNumber;
            applicantViewModel.City = applicantDetails.City;
            applicantViewModel.Country = applicantDetails.Country;
            applicantViewModel.Address1 = applicantDetails.Address1;
            applicantViewModel.Address2 = applicantDetails.Address2;
            applicantViewModel.DOB = String.Format("{0:d}", applicantDetails.DOB).Replace("-", "/");
            applicantViewModel.PostCode = applicantDetails.PostCode;
            applicantViewModel.UserType = applicantDetails.UserType.UserTypeCode;
            applicantViewModel.Attachment = applicantDetails.RegDocumentPath;

            if (!string.IsNullOrEmpty(applicantDetails.DeliveredSupport))
            {
                applicantViewModel.DeliveryChecked = applicantDetails.DeliveredSupport.Contains("F");
            }
            applicantViewModel.FoodList = this.GetAllFoodItems();

            var list = this.GetAllFoodByUserID(applicantID);
            if (list != null && list.Count > 0)
            {
                applicantViewModel.FoodSelectedIds = list.Select(x => x.Value).ToList();
            }

            return applicantViewModel;
        }

        /// <summary>
        /// save patient details 
        /// </summary>
        /// <param name="model">patient view model</param>
        /// <returns>Return patient detail</returns>
        public PatientViewModel SavePatientDetails(PatientViewModel patientViewModel)
        {

            Users usersInstance = this.unitOfWork.UserRepository.GetByID(patientViewModel.UserID);

            usersInstance.FirstName = patientViewModel.FirstName;
            usersInstance.MiddleName = patientViewModel.MiddleName;
            usersInstance.LastName = patientViewModel.LastName;
            usersInstance.Address1 = patientViewModel.Address1;
            usersInstance.Address2 = patientViewModel.Address2;
            usersInstance.FlatHouseNameNumber = patientViewModel.FlatHouseNameNumber;
            usersInstance.City = patientViewModel.City;
            usersInstance.Country = patientViewModel.Country;
            usersInstance.PostCode = patientViewModel.PostCode;
            usersInstance.Telephone = patientViewModel.FirstName;
            usersInstance.Mobile = patientViewModel.Telephone;
            usersInstance.DOB = DateTime.ParseExact(patientViewModel.DOB, "mm/dd/yyyy", CultureInfo.InvariantCulture);
            usersInstance.DeliveredSupport = patientViewModel.DeliveryChecked ? "M" : null;//set the status delivered for medicine true

            if (patientViewModel.MedReceipt != null)
            {
                usersInstance.MedicineReceipt = patientViewModel.MedFilePath;
            }

            this.unitOfWork.UserRepository.Update(usersInstance);
            this.unitOfWork.Save();


            User_MedicineRelation userMedInstance = new User_MedicineRelation();
            if ((patientViewModel.MedicineListIds != null && patientViewModel.MedicineListIds.Count > 0 && !string.IsNullOrEmpty(patientViewModel.MedicineListIds[0])))
            {
                var exist = this.GetPatientMedicines().Where(x => x.UserID == patientViewModel.UserID).Select(x => x.UserMedicineRelationID).ToList();

                if (exist != null && exist.Count > 0)
                {
                    foreach (var userMedRelID in exist)
                    {
                        this.unitOfWork.User_MedicineRelationRepository.Delete(userMedRelID);
                        this.unitOfWork.Save();
                    }
                }
                foreach (var val in patientViewModel.MedicineListIds)
                {
                    userMedInstance.UserID = patientViewModel.UserID;
                    userMedInstance.MedicineID = Convert.ToInt32(val);
                    this.unitOfWork.User_MedicineRelationRepository.Insert(userMedInstance);
                    this.unitOfWork.Save();
                }
            }

            return patientViewModel;
        }

        /// <summary>
        /// Get Patient Medicines
        /// </summary>
        /// <returns>list of assigned medicines</returns>
        public IEnumerable<User_MedicineRelation> GetPatientMedicines()
        {
            return this.unitOfWork.User_MedicineRelationRepository.GetQuery(null);
        }
        /// <summary>
        /// Gets all medicine names
        /// </summary>
        /// <returns>list of medicines</returns>
        public List<SelectListItem> GetAllMedicines()
        {
            List<SelectListItem> MedicineList = new List<SelectListItem>();
            var Medicines = this.unitOfWork.MedicineRepository.GetQuery(null);
            if (Medicines != null && Medicines.Count() > 0)
            {
                foreach (var medicine in Medicines)
                {
                    MedicineList.Add(new SelectListItem() { Text = medicine.MedicineName, Value = medicine.MedicineID.ToString() });

                }
            }


            return MedicineList;
        }

        /// <summary>
        /// Gets all food names
        /// </summary>
        /// <returns>list of food</returns>
        public List<SelectListItem> GetAllFoodItems()
        {
            List<SelectListItem> FoodItemList = new List<SelectListItem>();
            var FoodItems = this.unitOfWork.FoodRepository.GetQuery(null);
            if (FoodItems != null && FoodItems.Count() > 0)
            {
                foreach (var item in FoodItems)
                {
                    FoodItemList.Add(new SelectListItem() { Text = item.FoodName, Value = item.FoodID.ToString() });

                }
            }


            return FoodItemList;
        }

        /// <summary>
        /// Gets all medicine names by patient id
        /// </summary>
        /// <param name="patientID">patientID</param>
        /// <returns>list of medicines</returns>
        public List<SelectListItem> GetAllMedicinesByUserID(int patientID)
        {
            List<SelectListItem> MedicineList = new List<SelectListItem>();
            var Medicines = this.unitOfWork.User_MedicineRelationRepository.GetQuery(x => x.UserID == patientID).ToList();
            //var itemList = this.unitOfWork.UserRepository.GetQuery(x => x.UserType.UserTypeCode != "ADMN" && x.WelfareSection != null && x.WelfareSection.Contains("M")).ToList();

            if (Medicines != null && Medicines.Count() > 0)
            {
                foreach (var medicine in Medicines)
                {
                    MedicineList.Add(new SelectListItem() { Text = medicine.Medicine.MedicineName, Value = medicine.Medicine.MedicineID.ToString() });

                }
            }


            return MedicineList;
        }



        /// <summary>
        /// Gets all food names by applicant id
        /// </summary>
        /// <param name="applicantID">applicantID</param>
        /// <returns>list of food  items</returns>
        public List<SelectListItem> GetAllFoodByUserID(int applicantID)
        {
            List<SelectListItem> FoodItemList = new List<SelectListItem>();
            var FoodItems = this.unitOfWork.User_FoodRelationRepository.GetQuery(x => x.UserID == applicantID).ToList();
            //var itemList = this.unitOfWork.UserRepository.GetQuery(x => x.UserType.UserTypeCode != "ADMN" && x.WelfareSection != null && x.WelfareSection.Contains("M")).ToList();

            if (FoodItems != null && FoodItems.Count() > 0)
            {
                foreach (var food in FoodItems)
                {
                    FoodItemList.Add(new SelectListItem() { Text = food.Food.FoodName, Value = food.Food.FoodID.ToString() });

                }
            }


            return FoodItemList;
        }
        #endregion
    }
}
