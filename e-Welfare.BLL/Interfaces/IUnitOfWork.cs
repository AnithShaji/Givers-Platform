using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using e_Welfare.BLL;
using e_Welfare.DAL;
using e_Welfare.DTO;

namespace e_Welfare.BLL.Interfaces
{
    /// <summary>
    /// Represents the interface to a unit of work
    /// </summary>
    public interface IUnitOfWork
    {

        /// <summary>
        /// Gets the Users repository
        /// </summary>
        IRepository<Users> UserRepository { get; }

        /// <summary>
        /// Gets permission details repository
        /// </summary>
        IRepository<Permissions> PermissionRepository { get; }

        /// <summary>
        /// Gets the User Type Repository
        /// </summary>
        IRepository<UserType> UserTypeRepository { get; }

        /// <summary>
        /// Gets the Medicine Repository
        /// </summary>
        IRepository<Medicine> MedicineRepository { get; }

        /// <summary>
        /// Gets the Food Repository
        /// </summary>
        IRepository<Food> FoodRepository { get; }

        /// <summary>
        /// Gets the User Status Master  Repository
        /// </summary>
        IRepository<UserStatus_Master> UserStatus_MasterRepository { get; }

        /// <summary>
        /// Gets the user Medicine Relation Repository
        /// </summary>
        IRepository<User_MedicineRelation> User_MedicineRelationRepository { get; }

        /// <summary>
        /// Gets the user Food Relation Repository
        /// </summary>
        IRepository<User_FoodRelation> User_FoodRelationRepository { get; }

        /// <summary>
        /// Gets the Training Repository
        /// </summary>
        IRepository<Training> TrainingRepository { get; }

        /// <summary>
        /// Saves changes in the unit of work
        /// </summary>
        void Save();
    }
}
