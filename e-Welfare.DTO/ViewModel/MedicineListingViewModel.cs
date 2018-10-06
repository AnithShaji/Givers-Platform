using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel
{
   public class MedicineListingViewModel
    {
        /// <summary>
        /// Gets or sets the sring id key
        /// </summary>
        public string MedicineStringID { get; set; }

        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int? MedicineID { get; set; }

        /// <summary>
        /// Gets or sets the Medicine Name
        /// </summary>
        public string MedicineName { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        public string Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Issue Date
        /// </summary>
        public string IssueDate { get; set; }

        ///// <summary>
        ///// Gets or sets the created date
        ///// </summary>
        public DateTime? CreatedDate { get; set; }
    }
}
