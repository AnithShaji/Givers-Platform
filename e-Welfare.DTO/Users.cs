using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Welfare.DTO
{
    public class Users
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        [Key]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name 
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the telephone
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the PostCode
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the WelfareSection
        /// </summary>
        public string WelfareSection { get; set; }

        /// <summary>
        /// Gets or sets the mobile
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// Gets or sets the date of birth
        /// </summary>
        public DateTime? DOB { get; set; }

        /// <summary>
        /// Gets or sets the registration document path
        /// </summary>
        public string RegDocumentPath { get; set; }


        /// <summary>
        /// Gets or sets the medicine
        /// </summary>
        public string MedicineReceipt { get; set; }
        

        /// <summary>
        /// Gets or sets the flat house number
        /// </summary>
        public string FlatHouseNameNumber { get; set; }

        /// <summary>
        /// Gets or sets the address line 1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the address line 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the user type ID
        /// </summary>
        [ForeignKey("UserType")]
        public int UserTypeID { get; set; }

        /// <summary>
        /// Gets or sets the user type
        /// </summary>
        public virtual UserType UserType { get; set; }

        /// <summary>
        /// Gets or sets the user status ID
        /// </summary>
        [ForeignKey("UserStatus")]
        public int UserStatusID { get; set; }

        /// <summary>
        /// Gets or sets the user status
        /// </summary>
        public virtual UserStatus_Master UserStatus { get; set; }

        ///// <summary>
        ///// Gets or sets the created date
        ///// </summary>
        public DateTime CreatedDate { get; set; }

        ///// <summary>
        ///// Gets or sets the modified date
        ///// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the created by user ID
        /// </summary>
        public int? CreatedByID { get; set; }

        /// <summary>
        /// Gets or sets the modified by user
        /// </summary>
        public int? ModifiedByID { get; set; }

        /// <summary>
        /// Gets or sets the Delivered Support to user
        /// </summary>
        public string DeliveredSupport { get; set; }
    }
}
