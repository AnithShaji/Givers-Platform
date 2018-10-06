using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO
{
  public  class User_TrainingRelation
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
        /// Gets or sets the Training ID
        /// </summary>
        [ForeignKey("Training")]
        public int TrainingID { get; set; }

        /// <summary>
        /// Gets or sets the Training 
        /// </summary>
        public virtual Training Training { get; set; }
    }
}
