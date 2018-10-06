using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO.ViewModel
{
    /// <summary>
    /// User Login View Model Class
    /// </summary>
    public class UserLoginViewModel
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int UserRoleID { get; set; }

        /// <summary>
        /// Gets or sets the Username
        /// </summary>
        [Required(ErrorMessage = "Please enter Username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the First name
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the Last name
        /// </summary>
        public string LastName { get; set; }

        ///// <summary>
        ///// Gets or sets the Client ID
        ///// </summary>
        //public int ClientID { get; set; }

        /// <summary>
        /// Gets or sets the User Type Code
        /// </summary>
        public string UserTypeCode { get; set; }

        ///// <summary>
        ///// Gets or sets the patient ID
        ///// </summary>
        //public int PatientID { get; set; }
    }
}
