using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO
{
    /// <summary>
    /// User type class
    /// </summary>
    public class UserType
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        [Key]
        public int UserTypeID { get; set; }

        /// <summary>
        /// Gets or sets the user type name
        /// </summary>
        public string UserTypeName { get; set; }

        ///// <summary>
        ///// Gets or sets the user type parent ID
        ///// </summary>
        //[ForeignKey("UserTypeParent")]
        //public int? UserTypeParentID { get; set; }

        /// <summary>
        /// Gets or sets the user type description
        /// </summary>
        public string UserTypeDesc { get; set; }

        /// <summary>
        /// Gets or sets the user type Code
        /// </summary>
        public string UserTypeCode { get; set; }

        ///// <summary>
        ///// Gets or sets the user category ID
        ///// </summary>
        //[ForeignKey("UserCategory")]
        //public int? UserCategoryID { get; set; }

        /// <summary>
        /// Gets or sets the created date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the modified date
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
