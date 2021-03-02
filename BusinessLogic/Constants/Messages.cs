﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessLogic.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarNameInvalid = "Herhangi bir sorun oluştu.";
        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError="Hatalı şifre";
        public static string SuccessfulLogin = "Giriş yapıldı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
