using System.ComponentModel.DataAnnotations;

namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    public class PhoneMemberRegisterDTO
    {
        [MaxLength(20)]
        public string PhoneNumber { get; set; }      // 手機號碼
        [MaxLength(8)]
        public string VerifyCode { get; set; }       // 驗證碼
        [MaxLength(20)]
        public string Password { get; set; }         // 密碼
        [MaxLength(45)]
        public string DeviceID { get; set; }        // 設備機碼

        public SmsType SmsType { get; set; }        // 類型 

    }
}
