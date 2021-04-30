using Core.Entities.Concrete;
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
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfulLogin = "Giriş yapıldı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string PaymentError = "Ödeme başarılı";
        public static string PaymentSuccess = "Ödeme başarısız";

        public static string AddUserMessage = "Üye başarıyla eklendi.";

        public static string DeleteUserMessage = "Üye başarıyla silindi.";
        public static string EditUserMessage = "Üye başarıyla güncellendi.";
        public static string GetSuccessUserMessage = "Üye bilgisi / bilgileri getirildi.";
        public static string GetErrorUserMessage = "Üye bilgisi / bilgileri getirilemedi.";

        public static string UserAdded = "Kullanıcı ekleme işlemi başarıyla gerçekleşti.";
        public static string UserDeleted = "Kullanıcı silme işlemi başarıyla gerçekleşti.";
        public static string UserUpdated = "Kullanıcı güncelleme işlemi başarıyla gerçekleşti.";
    }
}
