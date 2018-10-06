using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel
{
   public class PermissionsViewModel
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int PermissionId { get; set; }

        /// <summary>
        /// Gets or sets the Applicant String ID
        /// </summary>
        public string ApplicantStringID { get; set; }

        /// <summary>
        /// Gets or sets the Applicant Name
        /// </summary>
        public string ApplicantName { get; set; }

        /// <summary>
        /// Gets or sets add permission
        /// </summary>
        public bool Add { get; set; }

        /// <summary>
        /// Gets or sets Edit permission
        /// </summary>
        public bool Edit { get; set; }

        /// <summary>
        /// Gets or sets the User ID
        /// </summary>
        public int UserID { get; set; }
    }
}
