using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class AutokeyVigenere : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        {
            throw new NotImplementedException();
        }

        public string Decrypt(string cipherText, string key)
        {
            //throw new NotImplementedException();
            char[] keyStream = new char[cipherText.Length];
            char[] decrypted = new char[cipherText.Length];
            bool iscompleted = false;
            int index = 0;
            int keyIndex, cipherIndex;

            for (int i = 0; i < cipherText.Length; i++)
            {
                if (i == key.Length)
                {
                    index = 0;
                    iscompleted = true;
                }
                if (!iscompleted)
                {
                    keyStream[i] = key[i];
                }
                else
                {
                    keyStream[i] = decrypted[index];
                }
                index++;
                index %= decrypted.Length;
                cipherIndex = cipherText[i] - 'A';
                Console.WriteLine("Cipher Index: " + cipherIndex);
                keyIndex = keyStream[i] - 'a';
                Console.WriteLine("Key Index: " + keyIndex);
                decrypted[i] = (char)((((cipherIndex - keyIndex) + 26) % 26) + 'a');
            }
            string result = new string(decrypted);
            Console.WriteLine("The Key Stream: " + new string(keyStream));
            Console.WriteLine("The result: " + result);
            return result;
        }

        public string Encrypt(string plainText, string key)
        {
            //throw new NotImplementedException();
            char[] keyStream = new char[plainText.Length];
            char[] encrypted = new char[plainText.Length];
            bool iscompleted = false;
            int index = 0;
            int keyIndex, plainIndex;

            for (int i = 0; i < plainText.Length; i++)
            {
                if (i == key.Length)
                {
                    index = 0;
                    iscompleted = true;
                }
                if (!iscompleted)
                {
                    keyStream[i] = key[i];
                }
                else
                {
                    keyStream[i] = plainText[index];
                }
                index++;
                index %= plainText.Length;
                plainIndex = plainText[i] - 'a';
                keyIndex = keyStream[i] - 'a';
                encrypted[i] = (char)(((plainIndex + keyIndex) % 26) + 'A');
            }
            string result = new string(encrypted);
            return result;
        }
    }
}
