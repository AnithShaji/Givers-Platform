using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel
{
    /// <summary>
    /// Patient details view model
    /// </summary>
    public class PatientListingViewModel
    {
        /// <summary>
        /// Gets or sets the Patient string id
        /// </summary>
        public string PatientStringID { get; set; }

        /// <summary>
        /// Gets or sets the Patient id
        /// </summary>
        public int PatientID { get; set; }

        /// <summary>
        /// Gets or sets the Patient name
        /// </summary>
        public string PatientName { get; set; }

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
        /// Gets or sets the Delivery Checked
        /// </summary>
        public string MedicineString { get; set; }
    }
}
