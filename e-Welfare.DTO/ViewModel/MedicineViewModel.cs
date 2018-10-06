using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel
{
   public class MedicineViewModel
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int MedicineID { get; set; }

        /// <summary>
        /// Gets or sets the Medicine Name
        /// </summary>
        [Required(ErrorMessage = "Please Enter Medicine Name")]
        [StringLength(25, ErrorMessage = "Medicine Name cannot be longer than 25 characters.")]
        public string MedicineName { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        [Required(ErrorMessage = "Please Enter Price")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string Price { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        [Required(ErrorMessage = "Please Enter Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Issue Date
        /// </summary>
        [Required(ErrorMessage = "Please Enter Issue Date")]
        public string IssueDate { get; set; }

        ///// <summary>
        ///// Gets or sets the created date
        ///// </summary>
        public DateTime? CreatedDate { get; set; }
        
    }
}
