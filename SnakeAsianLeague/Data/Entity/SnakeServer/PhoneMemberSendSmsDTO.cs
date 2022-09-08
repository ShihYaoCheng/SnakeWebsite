using System.ComponentModel.DataAnnotations;

namespace SnakeAsianLeague.Data.Entity.SnakeServer
{
    public class PhoneMemberSendSmsDTO
    {
        [MaxLength(20)]
        public string PhoneNumber { get; set; }      // 手機號碼

        public SmsType SmsType { get; set; }        // 類型 
    }
}
