﻿using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages  // bunu surekli newlemiyeyim cunku basit bir mesaj 
    {
        public static string ProductAdded = " Poduct added ";
        public static string ProductNameInValid = "Product name is invalid";
        public static string MaintenanceTime = "sistem bakımda ";
        public static string ProductsListed = "ürünler listelendi";
        public static string ProductUpdated = "product updated";
        public static string ProductDeleted = "product deleted";
        public static string UnitPriceInvalid = "Unit price is invalid";
        public static string ProductCountOfCategoryError = "Product Count Of Category Error";
        public static string ProductNameAlreadyExists = "Product name is already exists";
        public static string CategoryLimitExceded = "Category Limit Exceded";
        public static string AuthorizationDenied = "you are not authorize";
        public static string UserRegistered = "UserRegistered";
        public static string UserNotFound = "UserNotFound";
        public static string PasswordError = "PasswordError";
        public static string SuccessfulLogin = "SuccessfulLogin";
        public static string UserAlreadyExists = "UserAlreadyExists";
        public static string AccessTokenCreated = "AccessTokenCreated";
        public static string systemOkey = "System okey";
    }
}
