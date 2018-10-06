using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel
{
    /// <summary>
    /// Applicant details view model
    /// </summary>
    public class SelectListInsatnceViewModel
    {
        /// <summary>
        /// list of patient view models
        /// </summary>
        public List<PatientListingViewModel> PatientListingInstance { get; set; }

        /// <summary>
        /// list of applicant view models
        /// </summary>
        public List<FoodApplicantListingViewModel> ApplicantListingInstance { get; set; }

        /// <summary>
        /// list of student listing view models
        /// </summary>
        public List<StudentListingViewModel> StudentListingInstance { get; set; }

        /// <summary>
        /// list of medicine view models
        /// </summary>
        public List<MedicineListingViewModel> MedicineListingInstance { get; set; }

        /// <summary>
        /// list of food view models
        /// </summary>
        public List<FoodListingViewModel> FoodListingInstance { get; set; }

        /// <summary>
        /// list of training view models
        /// </summary>
        public List<TrainingListingViewModel> TrainingListingInstance { get; set; }

    }
}
