using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel
{
   public class MedicineMasterViewModel
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int? MedicineID { get; set; }

        /// <summary>
        /// Gets or sets the Medicine Name
        /// </summary>
        public string MedicineName { get; set; }
    }
}
