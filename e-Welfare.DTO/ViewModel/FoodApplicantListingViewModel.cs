using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel
{
   public class FoodApplicantListingViewModel
    {
        /// <summary>
        /// Gets or sets the Applicant string id
        /// </summary>
        public string ApplicantStringID { get; set; }

        /// <summary>
        /// Gets or sets the Applicant id
        /// </summary>
        public int ApplicantID { get; set; }

        /// <summary>
        /// Gets or sets the Applicant name
        /// </summary>
        public string ApplicantName { get; set; }

        /// <summary>
        /// Gets or sets the DOB
        /// </summary>
        public string DOB { get; set; }

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
        public string Attachment { get; set; }

        /// <summary>
        /// Gets or sets the Checked
        /// </summary>
        public bool Checked { get; set; }

        /// <summary>
        /// Gets or sets the Delivery Checked
        /// </summary>
        public bool DeliveryChecked { get; set; }

        /// <summary>
        /// Gets or sets the FoodItemString 
        /// </summary>
        public string FoodItemString { get; set; }
    }
}
