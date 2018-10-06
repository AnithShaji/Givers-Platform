using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Welfare.DTO
{
   public class User_FoodRelation
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        [Key]
        public int UserFoodRelationID { get; set; }

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
        /// Gets or sets the Food ID
        /// </summary>
        [ForeignKey("Food")]
        public int FoodID { get; set; }

        /// <summary>
        /// Gets or sets the Food 
        /// </summary>
        public virtual Food Food { get; set; }
    }
}
