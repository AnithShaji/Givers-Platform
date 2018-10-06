using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel
{
   public class TrainingViewModel
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int TrainingID { get; set; }

        /// <summary>
        /// Gets or sets the Training Name
        /// </summary>
        [Required(ErrorMessage = "Please Enter Training Name")]
        [StringLength(25, ErrorMessage = "Training Name cannot be longer than 25 characters.")]
        public string TrainingName { get; set; }

        /// <summary>
        /// Gets or sets the start Date
        /// </summary>
        [Required(ErrorMessage = "Please Enter Start Date")]
        public string StartDate { get; set; }

        ///// <summary>
        ///// Gets or sets the end date
        ///// </summary>
        [Required(ErrorMessage = "Please Enter End Date")]
        public string EndDate { get; set; }
    }
}
