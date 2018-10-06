using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO
{
   public class Medicine
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        [Key]
        public int MedicineID { get; set; }

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
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Issue Date
        /// </summary>
        public DateTime IssueDate { get; set; }

        ///// <summary>
        ///// Gets or sets the created date
        ///// </summary>
        public DateTime? CreatedDate { get; set; }
    }
}
