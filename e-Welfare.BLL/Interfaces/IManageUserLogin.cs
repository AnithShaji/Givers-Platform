﻿using e_Welfare.DTO;
using e_Welfare.DTO.ViewModel.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace e_Welfare.BLL.Interfaces
{
    /// <summary>
    /// Interface for User Login
    /// </summary>
    public interface IManageUserLogin
    {
        /// <summary>
        ///  Function to check User Login.
        /// </summary>
        /// <param name="userName">user Name</param>
        /// <param name="password">pass word</param>
        /// <returns>returns integer</returns>
        int Authenticate(string userName, string password);

        /// <summary>
        ///  Function to check User Login temp
        /// </summary>
        /// <param name="userName">user Name</param>
        /// <param name="password">pass word</param>
        /// <returns>returns integer</returns>
        Users AuthenticateTemp(string userName, string password);

        /// <summary>
        /// Gets the user type
        /// </summary>
        /// <returns>user type entity</returns>
        IEnumerable<UserTypeViewModel> GetUserTypes();

        /// <summary>
        /// Gets the user Type details for a user
        /// </summary>
        /// <param name="userTypeID">user Type ID</param>
        /// <returns>role ID</returns>
        UserTypeViewModel GetUserTypeByTypeId(int userTypeID);

        ///// <summary>
        ///// Gets the client ID for a user
        ///// </summary>
        ///// <param name="userID">user ID</param>
        ///// <returns>client ID</returns>
        //int GetClientIDOfUser(int userID);

        ///// <summary>
        ///// Get the Users User Role Relation details
        ///// </summary>
        ///// <param name="userId">user Id</param>
        ///// <returns>returns Users User Role Relation</returns>
        //UsersUserRoleRelation GetUserByUserId(int userId);

        ///// <summary>
        ///// Gets the Role ID for a user
        ///// </summary>
        ///// <param name="userID">user ID</param>
        ///// <returns>role ID</returns>
        //int GetRoleIDOfUser(int userID);

        ///// <summary>
        /////  Function to authenticate temp
        ///// </summary>
        ///// <param name="userName">user Name</param>
        ///// <param name="password">pass word</param>
        ///// <returns>returns Users object</returns>
        //UserLoginViewModel AuthenticateUser(string userName, string password);

    }
}
