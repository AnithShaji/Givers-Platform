using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO
{
    public class User_MedicineRelation
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        [Key]
        public int UserMedicineRelationID { get; set; }

        /// <summary>
        /// Gets or sets the User ID
        /// </summary>
        [ForeignKey("User")]
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the user
        /// </summary>
        public virtual Users User { get; set; }

        /// <summary>
        /// Gets or sets the Medicine ID
        /// </summary>
        [ForeignKey("Medicine")]
        public int MedicineID { get; set; }

        /// <summary>
        /// Gets or sets the Medicine 
        /// </summary>
        public virtual Medicine Medicine { get; set; }
    }
}
