using System;

namespace GestaoJogos.Domain.ValuesObjects
{
    public class UserRequestToken
    {
        public string User { get; set; }
        public string Password { get; set; }
        public DateTime DateAndHourValid { get; set; }
        public string PrivateKey { get; set; }
    }
}
