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
    /// User status master class
    /// </summary>
    public class UserStatus_Master
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        [Key]
        public int UserStatusID { get; set; }

        /// <summary>
        /// Gets or sets user status
        /// </summary>
        public string UserStatus { get; set; }

        /// <summary>
        /// Gets or sets user status code
        /// </summary>
        public string UserStatusCode { get; set; }
    }
}
