using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel
{
   public class ClientDashboardTypeViewModel
    {
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
    }
}
