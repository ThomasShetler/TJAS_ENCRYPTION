using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TJAS_ENCRYPTION.Models;

namespace TJAS_ENCRYPTION
{
    class Encrypter
    {
        public static string[,,] Encrypt(string password, UserModel user)
        {

            int EncyptSize = 50; 

            string[,,] array3D = new string[EncyptSize, EncyptSize, EncyptSize];

            string[] placeholders = new string[150];

            Random rnd = new Random();

            int indexer = 0;
            int num = rnd.Next(EncyptSize);
            int num2 = rnd.Next(EncyptSize);
            int num3 = rnd.Next(EncyptSize);

            List<int> added1 = new List<int>();
            List<int> added2 = new List<int>();
            List<int> added3 = new List<int>();
            foreach (char c in password)
            {
                num = rnd.Next(EncyptSize);
                num2 = rnd.Next(EncyptSize);
                num3 = rnd.Next(EncyptSize);
                if (added1.Contains(num)) {
                    while (added1.Contains(num))
                    {
                        num = rnd.Next(EncyptSize);

                    }
                    added1.Add(num);
                }
                else
                {
                    added1.Add(num);
                }
                if (added2.Contains(num2))
                {
                    while (added2.Contains(num2))
                    {
                        num2 = rnd.Next(EncyptSize);
                    }
                    added2.Add(num2);
                }
                else
                {
                    added2.Add(num2);
                }
                if (added3.Contains(num3))
                {
                    while (added3.Contains(num))
                    {
                        num3 = rnd.Next(EncyptSize);
                    }
                    added3.Add(num3);
                }
                else
                {
                    added3.Add(num3);
                }

                array3D[num, num2, num3] = c.ToString();

                string result = $"{num} {num2} {num3}-";

                placeholders[indexer] = result;
                indexer++;
            }
            string pass = "";
            foreach (var item in placeholders)
            {
                pass = pass + item;
            }

            for (int i = 0; i <= EncyptSize - 1; i++)
            {
                for (int j = 0; j <= EncyptSize - 1; j++)
                {
                    for (int k = 0; k <= EncyptSize - 1; k++)
                    {
                        if (array3D[i, j, k] == null)
                        {
                            array3D[i, j, k] = GetLetter().ToString();
                        }
                    }
                }
            }


            Console.WriteLine(pass);


            user.password = pass;
            return array3D;

        }
        public static char GetLetter()
        {
            string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length);
            return chars[num];
        }

        public static bool ValidatePass(UserModel user, string passEntry){
           string pass = user.password;
            string[] passwordfull = pass.Split('-');
            List<int[]> ListOfListInts = new List<int[]>();

            int ind = 0;
            foreach (var item in passwordfull)
            {
               
                string[] indexes = item.Split(' ');
                int[] hashers = new int[3];

                int i = 0;
                foreach (string item2 in indexes)
                {
                    if (item2 != "")
                    {
                        int passer = Int16.Parse(item2);

                        hashers[i] = passer;
                    }

                    i++;
                }
                ListOfListInts.Add(hashers);

            }
            string passwordDecypted = "";
             int countoflist = ListOfListInts.Count();
            int indj = 0;
            foreach (var item in ListOfListInts)
            {
                if (indj < countoflist - 1)
                {
                    passwordDecypted = passwordDecypted + user.array3D[item[0], item[1], item[2]];
                }
                indj++;
            }
            if(passwordDecypted == passEntry)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
