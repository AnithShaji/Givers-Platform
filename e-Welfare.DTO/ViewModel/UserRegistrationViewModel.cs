using e_Welfare.DTO.ViewModel.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace e_Welfare.DTO.ViewModel
{
    /// <summary>
    /// User details view model
    /// </summary>
    public class UserRegistrationViewModel
    {

        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        //[Required(ErrorMessage = "Please Select User Status")]
        public int UserStatusID { get; set; }

        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        //[Required(ErrorMessage = "Please Select Role")]
        public int UserRoleID { get; set; }

        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        //[Required(ErrorMessage = "Please Select Role")]
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the Mobile
        /// </summary>
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the FlatHouseNameNumber
        /// </summary>
        public string FlatHouseNameNumber { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        [Required(ErrorMessage = "Please Enter City")]
        [StringLength(10, ErrorMessage = "City cannot be longer than 10 characters.")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the PostCode
        /// </summary>
        [Required(ErrorMessage = "Please Post Code")]
        [StringLength(10, ErrorMessage = "Post Code cannot be longer than 10 characters.")]
        public string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        [Required(ErrorMessage = "Please Enter Country")]
        [StringLength(10, ErrorMessage = "Country cannot be longer than 10 characters.")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the address line 1
        /// </summary>
        /// [Required(ErrorMessage = "Please Enter Mobile No")]
        [Required(ErrorMessage = "Please Enter Address 1")]
        [StringLength(200, ErrorMessage = "Address 1 cannot be longer than 200 characters.")]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the address line 2
        /// </summary>
        [Required(ErrorMessage = "Please Enter Address 2")]
        [StringLength(200, ErrorMessage = "Address 2 cannot be longer than 200 characters.")]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        [Required(ErrorMessage = "Please Enter First Name")]
        [StringLength(25, ErrorMessage = "First Name cannot be longer than 25 characters.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name 
        /// </summary>
        [Required(ErrorMessage = "Please Enter Middle Name")]
        [StringLength(25, ErrorMessage = "Middle Name cannot be longer than 25 characters.")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        [Required(ErrorMessage = "Please Enter Last Name")]
        [StringLength(25, ErrorMessage = "Last Name cannot be longer than 25 characters.")]
        public string LastName { get; set; }

        ///// <summary>
        ///// Gets or sets the user name
        ///// </summary>
        //[Required(ErrorMessage = "Please Enter Username")]
        //public string Username { get; set; }

        /// <summary>
        /// Gets or sets user status
        /// </summary>
        public string UserStatus { get; set; }

        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        ///// <summary>
        ///// Gets or sets the password
        ///// </summary>
        //[Required(ErrorMessage = "Please Enter Password ")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        ///// <summary>
        ///// Gets or sets the password
        ///// </summary>
        //[Required(ErrorMessage = "Please Confirm Password ")]
        //[Compare("Password")]
        //public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        //[Required(ErrorMessage = "Please Select User Type")]
        public int UserTypeID { get; set; }

        ///// <summary>
        ///// Gets or sets the user type name
        ///// </summary>
        //public string UserTypeName { get; set; }

        /// <summary>
        /// Gets or sets the modified by user ID
        /// </summary>
        public int? ModifiedByID { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedDate
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the created by user ID
        /// </summary>
        public int CreatedByID { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDate
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the DOB
        /// </summary>
        public DateTime? DOB { get; set; }

        /// <summary>
        /// Gets or sets the Document path
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the User Exist Status
        /// </summary>
        public int UserExistStatus { get; set; }

        [Required(ErrorMessage = "Please Upload File")]
        [Display(Name = "Upload File")]
        [ValidateFile]
        public HttpPostedFileBase FileUpload { get; set; }
    }
}
