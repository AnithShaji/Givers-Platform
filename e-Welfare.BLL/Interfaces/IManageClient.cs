using e_Welfare.DTO;
using e_Welfare.DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace e_Welfare.BLL.Interfaces
{
    /// <summary>
    /// Interface for client
    /// </summary>
    public interface IManageClient
    {
        /// <summary>
        /// Saves the patient Education
        /// </summary>
        /// <param name="model">patient Education view model</param>
        /// <returns>ID of saved object</returns>

        UserRegistrationViewModel RegisterClient(UserRegistrationViewModel model);

        /// <summary>
        /// Gets user details by user ID
        /// </summary>
        /// <param name="userID">user ID</param>
        /// <returns>Return user by id</returns>
        Users GetUserDetails(int userID);

        /// <summary>
        /// Get Status Applicant Count
        /// </summary>
        /// <returns>message count</returns>
        List<int> GetStatusCount();

        /// <summary>
        /// Get Permission details
        /// </summary>
        /// <returns>Return applicant list</returns>
        List<PermissionsViewModel> GetPermissionDetails();

        /// <summary>
        /// Gets user details by email Address
        /// </summary>
        /// <param name="emailAddress">email Address</param>
        /// <returns>Return user by id</returns>
        Users GetUserDetailsByEmail(string emailAddress);

        /// <summary>
        /// save user 
        /// </summary>
        /// <param name="model">user model</param>
        /// <returns>Return user</returns>
        Users SaveUser(Users model);

        /// <summary>
        /// Applicant Dashboard List
        /// </summary>
        /// <param name="tabName">tab Name</param>
        /// <returns>Return applicant list</returns>
        List<ApplicantListingViewModel> ApplicantDashboardList(string tabName);

        /// <summary>
        /// Load content for container
        /// </summary>
        /// <param name="tab">tab</param>
        /// <param name="userType">userType</param>
        /// <returns>Return list</returns>
        SelectListInsatnceViewModel LoadContent(string tab, string userType);

        /// <summary>
        /// To activate the Applicant status
        /// </summary>
        /// <param name="chekdApplicantIds">chekd Applicant Ids</param>
        /// <returns>return true if updated</returns>
        bool CheckApprovalStatus(List<string> chekdApplicantIds);

        /// <summary>
        /// To activate the Applicant status
        /// </summary>
        /// <param name="chekdSections">chekd Sections</param>
        /// <param name="userID">user id</param>
        /// <returns>return true if updated</returns>
        bool CheckedClientSection(List<string> chekdSections, int userID);

        /// <summary>
        /// Get Checked Client Section  
        /// </summary>
        /// <param name="userID">userID</param>
        /// <returns>Return list</returns>
        ClientDashboardTypeViewModel GetCheckedClientSection(int userID);


        /// <summary>
        /// To activate the Applicant section
        /// </summary>
        /// <param name="userID">user id</param>
        /// <returns>return true if updated</returns>
        bool ActivateClientSection(int userID);

        /// <summary>
        /// save medicine details 
        /// </summary>
        /// <param name="model">medicine view model</param>
        /// <returns>Return medicine detail</returns>
        MedicineViewModel SaveMedicineDetails(MedicineViewModel medicineViewModel);

        /// <summary>
        /// get medicine details 
        /// </summary>
        /// <param name="medicineID"> medicineID</param>
        /// <returns>Return medicine detail</returns>
        MedicineViewModel GetMedicineDetailsById(int medicineID);


        /// <summary>
        /// get patient details 
        /// </summary>
        /// <param name="patientID"> patientID</param>
        /// <returns>Return patient detail</returns>
        PatientViewModel GetPatientDetailsById(int patientID);

        /// <summary>
        /// save patient details 
        /// </summary>
        /// <param name="model">patient view model</param>
        /// <returns>Return patient detail</returns>
        PatientViewModel SavePatientDetails(PatientViewModel patientViewModel);

        /// <summary>
        /// Gets all medicine names
        /// </summary>
        /// <returns>list of medicines</returns>
        List<SelectListItem> GetAllMedicines();

        /// <summary>
        /// get food details 
        /// </summary>
        /// <param name="foodID"> foodID</param>
        /// <returns>Return food detail</returns>
        FoodViewModel GetFoodDetailsById(int foodID);

        /// <summary>
        /// save food item details 
        /// </summary>
        /// <param name="foodViewModel">food view model</param>
        /// <returns>Return medicine detail</returns>
        FoodViewModel SaveFoodItemDetails(FoodViewModel foodViewModel);


        /// <summary>
        /// Gets all food names by applicant id
        /// </summary>
        /// <param name="applicantID">applicantID</param>
        /// <returns>list of food  items</returns>
        List<SelectListItem> GetAllFoodByUserID(int applicantID);

        /// <summary>
        /// Gets all food names
        /// </summary>
        /// <returns>list of food</returns>
        List<SelectListItem> GetAllFoodItems();


        /// <summary>
        /// get applicant details 
        /// </summary>
        /// <param name="applicantID"> applicantID</param>
        /// <returns>Return applicant detail</returns>
        ApplicantViewModel GetApplicantDetailsById(int applicantID);

        /// <summary>
        /// save training item details 
        /// </summary>
        /// <param name="trainingViewModel">training view model</param>
        /// <returns>Return training detail</returns>
        TrainingViewModel SaveTrainingDetails(TrainingViewModel trainingViewModel);

        /// <summary>
        /// get training details 
        /// </summary>
        /// <param name="trainingID"> trainingID</param>
        /// <returns>Return training detail</returns>
        TrainingViewModel GetTrainingDetailsById(int trainingID);

        /// <summary>
        /// Saves the permission details
        /// </summary>
        /// <param name="modelList">permission view model</param>
        /// <returns>success or not</returns>
        int SavePermissionDetails(List<PermissionsViewModel> modelList);

        /// <summary>
        /// Get Medicine Inventory
        /// </summary>
        /// <returns> Medicine Inventory</returns>
        List<Medicine> GetMedicineInventory();
    }
}
