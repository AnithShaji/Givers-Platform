using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel.Auth
{
    /// <summary>
    /// User type class
    /// </summary>
    public class UserTypeViewModel
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int UserTypeID { get; set; }

        /// <summary>
        /// Gets or sets the user type name
        /// </summary>
        public string UserTypeName { get; set; }

        /// <summary>
        /// Gets or sets the user type Code
        /// </summary>
        public string UserTypeCode { get; set; }
    }
}
