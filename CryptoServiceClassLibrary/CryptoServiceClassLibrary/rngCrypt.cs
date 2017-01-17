using System;
using System.Security.Cryptography;
using System.Text;

namespace CryptoServiceClassLibrary
{
    public class Password
    {
        private string getPassword;

        private string lower = "abcdefghijklmnopqrstuvwxyz";
        private string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string symbols = " !#$%&'()*+,-./:;<=>?@[\"]^_`\\{|}~";
        private string numbers = "0123456789";

        public Password NewPassword(optionPass option = optionPass.pasDigitUpperSmall, int length = 32)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var data = new byte[4];
                rng.GetBytes(data);
                var seed = BitConverter.ToInt32(data, 0);
                var rnd = new Random(seed);

                var passChars = new char[length];

                var sb = new StringBuilder();
                for (var i = 0; i < passChars.Length; i++)
                {

                    if (option == optionPass.pasSize)
                        sb.Append(lower[rnd.Next(0, 62)]);
                    if (option == optionPass.pasUpperOnly)
                        sb.Append(upper[rnd.Next(0, 36)]);
                    if (option == optionPass.pasSmallOnly)
                        sb.Append(symbols[rnd.Next(0, 36)]);
                    if (option == optionPass.pasDigitOnly)
                        sb.Append(numbers[rnd.Next(0, 52)]);
                    if (option == optionPass.pasDigitUpperSmall)
                    {
                        if (sb.Length == rnd.Next(sb.Length, length + 1)) sb.Append(symbols[rnd.Next(0, 33)]);
                        
                        else sb.Append(lower[rnd.Next(0, 52)]);
                    }
                }

                var pass = new Password(sb.ToString());

                return pass;
            }
        }

        public Password()
        {
            getPassword = NewPassword().ToString();
        }
        public Password(int length)
        {
            getPassword = NewPassword(optionPass.pasUpperOnly, length).ToString();
        }
        public Password(string str)
        {
            getPassword = str;
        }
        public Password(optionPass passOpt)
        {
            getPassword = NewPassword(passOpt).ToString();
        }
        public Password(optionPass passOpt, int length)
        {
            getPassword = NewPassword(passOpt, length).ToString();
        }
        public new string ToString()
        {
            return getPassword;
        }
    }
}
public enum optionPass
{
    pasSize,
    pasUpperOnly,
    pasSmallOnly,
    pasDigitOnly,
    pasDigitUpperSmall

}
