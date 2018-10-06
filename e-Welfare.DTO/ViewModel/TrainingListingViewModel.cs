using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel
{
  public class TrainingListingViewModel
    {
        /// <summary>
        /// Gets or sets the sring id key
        /// </summary>
        public string TrainingStringID { get; set; }

        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int TrainingID { get; set; }

        /// <summary>
        /// Gets or sets the Training Name
        /// </summary>
        public string TrainingName { get; set; }

        /// <summary>
        /// Gets or sets the Issue Date
        /// </summary>
        public string StartDate { get; set; }

        ///// <summary>
        ///// Gets or sets the created date
        ///// </summary>
        public string EndDate { get; set; }
    }
}
