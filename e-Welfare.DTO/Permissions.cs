using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO
{
    public class Permissions
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        [Key]
        public int PermissionId { get; set; }

        /// <summary>
        /// Gets or sets the Permission Name
        /// </summary>
        public string PermissionName { get; set; }

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
        [ForeignKey("User")]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the user
        /// </summary>
        public virtual Users User { get; set; }
    }
}
