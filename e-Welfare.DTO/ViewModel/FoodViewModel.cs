using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel
{
    public class FoodViewModel
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int FoodID { get; set; }

        /// <summary>
        /// Gets or sets the Medicine Name
        /// </summary>
        [Required(ErrorMessage = "Please Enter Food Item Name")]
        [StringLength(25, ErrorMessage = "Food Item Name cannot be longer than 25 characters.")]
        public string FoodName { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        [Required(ErrorMessage = "Please Enter Price")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        [Required(ErrorMessage = "Please Enter Quantity")]
        public int? Quantity { get; set; }

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
