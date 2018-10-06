using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO
{
   public class Training
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        [Key]
        public int TrainingID { get; set; }

        /// <summary>
        /// Gets or sets the Training Name
        /// </summary>
        public string TrainingName { get; set; }

        /// <summary>
        /// Gets or sets the Issue Date
        /// </summary>
        public DateTime? StartDate { get; set; }

        ///// <summary>
        ///// Gets or sets the created date
        ///// </summary>
        public DateTime? EndDate { get; set; }
    }
}
