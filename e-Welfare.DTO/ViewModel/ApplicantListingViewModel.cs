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
    public class ApplicantListingViewModel
    {
        /// <summary>
        /// Gets or sets the applicant id
        /// </summary>
        public string ApplicantID { get; set; }

        /// <summary>
        /// Gets or sets the user id
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the applicant name
        /// </summary>
        public string ApplicantName { get; set; }

        /// <summary>
        /// Gets or sets the Requsted Date
        /// </summary>
        public string RequstedDate { get; set; }

        /// <summary>
        /// Gets or sets the Section Name
        /// </summary>
        public string SectionName { get; set; }

        /// <summary>
        /// Gets or sets the Attachment
        /// </summary>
        public string AttachmentPath { get; set; }

        /// <summary>
        /// Gets or sets the Approval Status
        /// </summary>
        public bool ApprovalStatus { get; set; }

        /// <summary>
        /// Gets or sets the Medical
        /// </summary>
        public bool MedicalSection { get; set; }

        /// <summary>
        /// Gets or sets the Education
        /// </summary>
        public bool EducationSection { get; set; }

        /// <summary>
        /// Gets or sets the Food
        /// </summary>
        public bool FoodSection { get; set; }

        /// <summary>
        /// Gets or sets the UserStatusCode
        /// </summary>
        public string UserStatusCode { get; set; }
        
    }
}
