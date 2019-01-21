using System;
using System.Security.Cryptography;
using System.Configuration;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using SummitShopApp.BL;

namespace SummitShopApp.Utility
{
    public class Security
    {
        private Security()
        {
        }

        private const string KEY = "Summit";

        /// <summary>
        /// encode password
        /// </summary>
        /// <param name="strPassword">String</param>
        /// <returns>String</returns>
        public static String encode(String strPassword)
        {
            if (String.IsNullOrEmpty(strPassword))
                return String.Empty;

            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(strPassword);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(KEY));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// decode password
        /// </summary>
        /// <param name="strPassword">String</param>
        /// <returns>String</returns>
        public static String decode(String strPassword)
        {
            if (String.IsNullOrEmpty(strPassword))
                return String.Empty;

            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(strPassword);

            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(KEY));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        /// <summary>
        /// This function is use to encode the number
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static String EncodeNumbers(String strNumber)
        {
            String strEncodedNumber = String.Empty;
            StringBuilder sb = new StringBuilder();
            Char temp;
            foreach (Char _char in strNumber)
            {
                switch (_char)
                {
                    case '0':
                        sb.Append('p');
                        break;
                    case '1':
                        sb.Append('z');
                        break;
                    case '2':
                        sb.Append('c');
                        break;
                    case '3':
                        sb.Append('u');
                        break;
                    case '4':
                        sb.Append('i');
                        break;
                    case '5':
                        sb.Append('m');
                        break;
                    case '6':
                        sb.Append('s');
                        break;
                    case '7':
                        sb.Append('a');
                        break;
                    case '8':
                        sb.Append('w');
                        break;
                    case '9':
                        sb.Append('d');
                        break;
                }
            }
            strEncodedNumber = sb.ToString();
            return strEncodedNumber;
        }

        /// <summary>
        /// This function is use to decode the number
        /// </summary>
        /// <param name="strNumber"></param>
        /// <returns></returns>
        public static String DecodeNumbers(String strNumber)
        {
            String strDecodedNumber = String.Empty;
            StringBuilder sb = new StringBuilder();
            Char temp;
            foreach (Char _char in strNumber)
            {
                switch (_char)
                {
                    case 'p':
                        sb.Append('0');
                        break;
                    case 'z':
                        sb.Append('1');
                        break;
                    case 'c':
                        sb.Append('2');
                        break;
                    case 'u':
                        sb.Append('3');
                        break;
                    case 'i':
                        sb.Append('4');
                        break;
                    case 'm':
                        sb.Append('5');
                        break;
                    case 's':
                        sb.Append('6');
                        break;
                    case 'a':
                        sb.Append('7');
                        break;
                    case 'w':
                        sb.Append('8');
                        break;
                    case 'd':
                        sb.Append('9');
                        break;
                }
            }
            strDecodedNumber = sb.ToString();
            return strDecodedNumber;
        }
    }
}
