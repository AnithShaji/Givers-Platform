using System;
using e_Welfare.BLL;
using e_Welfare.DAL;
using e_Welfare.DTO;
using e_Welfare.BLL.Interfaces;

namespace e_Welfare.BLL.Persistence
{
    /// <summary>
    /// Represents a unit of work
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// the data context
        /// </summary>
        private E_WelfareContext context = new E_WelfareContext();

        #region declarations

        /// <summary>
        /// the Users repository
        /// </summary>
        private IRepository<Users> userRepository;

        /// <summary>
        /// the Permission repository
        /// </summary>
        private IRepository<Permissions> permissionRepository;

        /// <summary>
        /// the User Type repository
        /// </summary>
        private IRepository<UserType> userTypeRepository;

        /// <summary>
        /// the Medicine repository
        /// </summary>
        private IRepository<Medicine> medicineRepository;

        /// <summary>
        /// the Food repository
        /// </summary>
        private IRepository<Food> foodRepository;

        /// <summary>
        /// the Training repository
        /// </summary>
        private IRepository<Training> trainingRepository;

        /// <summary>
        /// the user Status Master repository
        /// </summary>
        private IRepository<UserStatus_Master> userStatus_MasterRepository;

        /// <summary>
        /// the user Medicine Relation repository
        /// </summary>
        private IRepository<User_MedicineRelation> user_MedicineRelationRepository;

        /// <summary>
        /// the user Food Relation repository
        /// </summary>
        private IRepository<User_FoodRelation> user_FoodRelationRepository;

        #endregion

        /// <summary>
        /// true if object is disposed
        /// </summary>
        private bool disposed = false;

        #region definitions

        /// <summary>
        /// Gets user details repository
        /// </summary>
        public IRepository<Users> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new Repository<Users>(this.context);
                }

                return this.userRepository;
            }
        }

        /// <summary>
        /// Gets permission details repository
        /// </summary>
        public IRepository<Permissions> PermissionRepository
        {
            get
            {
                if (this.permissionRepository == null)
                {
                    this.permissionRepository = new Repository<Permissions>(this.context);
                }

                return this.permissionRepository;
            }
        }

        /// <summary>
        /// Gets the User Type Repository
        /// </summary>
        public IRepository<UserType> UserTypeRepository
        {
            get
            {
                if (this.userTypeRepository == null)
                {
                    this.userTypeRepository = new Repository<UserType>(this.context);
                }

                return this.userTypeRepository;
            }
        }

        /// <summary>
        /// Gets the Medicine Repository
        /// </summary>
        public IRepository<Medicine> MedicineRepository
        {
            get
            {
                if (this.medicineRepository == null)
                {
                    this.medicineRepository = new Repository<Medicine>(this.context);
                }

                return this.medicineRepository;
            }
        }

        /// <summary>
        /// Gets the Food Repository
        /// </summary>
        public IRepository<Food> FoodRepository
        {
            get
            {
                if (this.foodRepository == null)
                {
                    this.foodRepository = new Repository<Food>(this.context);
                }

                return this.foodRepository;
            }
        }

        /// <summary>
        /// Gets the Training Repository
        /// </summary>
        public IRepository<Training> TrainingRepository
        {
            get
            {
                if (this.trainingRepository == null)
                {
                    this.trainingRepository = new Repository<Training>(this.context);
                }

                return this.trainingRepository;
            }
        }


        /// <summary>
        /// Gets the User Status Master  Repository
        /// </summary>
        public IRepository<UserStatus_Master> UserStatus_MasterRepository
        {
            get
            {
                if (this.userStatus_MasterRepository == null)
                {
                    this.userStatus_MasterRepository = new Repository<UserStatus_Master>(this.context);
                }

                return this.userStatus_MasterRepository;
            }
        }

        /// <summary>
        /// Gets the user Medicine Relation Repository
        /// </summary>
        public IRepository<User_MedicineRelation> User_MedicineRelationRepository
        {
            get
            {
                if (this.user_MedicineRelationRepository == null)
                {
                    this.user_MedicineRelationRepository = new Repository<User_MedicineRelation>(this.context);
                }

                return this.user_MedicineRelationRepository;
            }
        }

        /// <summary>
        /// Gets the user Food Relation Repository
        /// </summary>
        public IRepository<User_FoodRelation> User_FoodRelationRepository
        {
            get
            {
                if (this.user_FoodRelationRepository == null)
                {
                    this.user_FoodRelationRepository = new Repository<User_FoodRelation>(this.context);
                }

                return this.user_FoodRelationRepository;
            }
        }

        #endregion

        /// <summary>
        /// Saves changes
        /// </summary>
        public void Save()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Disposes the unit of work
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the unit of work
        /// </summary>
        /// <param name="disposing">true if disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
