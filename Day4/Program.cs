using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day4
{
    internal class Pair  
    {  
        internal char Character {get; set; }  
        internal int Value {get; set;}   
    }

    class Program
    {
        static void Main(string[] args)
        {
            
            //string s = "aaaaa-bbb-z-y-x-123[abxyz]";
            
            int sum = 0;
            foreach (string line in File.ReadLines(@"input.txt"))
            {   
                int sectorId;
                if(IsRealRoom(line, out sectorId))
                {
                    sum += sectorId;
                }  
            }
            
            Console.WriteLine(sum);
        }

        static bool IsRealRoom(string encryptedName, out int sectorId)
        {
            List<Pair> pairs = new List<Pair>();

            sectorId = int.Parse(Regex.Match(encryptedName, @"\d+").Value);
            string checksum = Regex.Match(encryptedName, @"(?<=\[).+?(?=\])").Value;

            Regex rgx = new Regex(@"\[.*?\]|[\d-]");
            encryptedName = rgx.Replace(encryptedName, "");
            
            while(encryptedName != string.Empty)
            {    
                string characterString = encryptedName.Substring(0,1);                
                
                int before = encryptedName.Length;

                encryptedName =  encryptedName.Replace(characterString.ToString(), string.Empty);

                int after = encryptedName.Length;

                int occurences = before - after;
                
                pairs.Add(new Pair(){ Character = characterString[0], Value  = occurences });       
            }         

            pairs = pairs.OrderBy(v => v.Character).ToList();
            pairs = pairs.OrderByDescending(v => v.Value).ToList();
            char[] charArray = pairs.Select(q => q.Character).Take(5).ToArray();

            return new string(charArray) == checksum;

        }
    }
}
