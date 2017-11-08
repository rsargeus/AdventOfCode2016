using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day4
{

    internal class Pair  
    {  
        internal string character;  
        internal int value;          

        public override string ToString()
        {
            return character + " " + value;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Pair> pairs = new List<Pair>();
            
            string s = "aaaaa-bbb-z-y-x-123[abxyz]";
            
            int sectorId = int.Parse(Regex.Match(s, @"\d+").Value);
            string passcode = Regex.Match(s, @"(?<=\[).+?(?=\])").Value;

            Console.WriteLine(passcode);

            Regex rgx = new Regex(@"\[.*?\]|[\d-]");
            s = rgx.Replace(s, "");
            

            Console.WriteLine(s);
            
            while(s != string.Empty)
            {
                
                string c = s.Substring(0,1);                
                
                int before = s.Length;

                s =  s.Replace(c.ToString(), string.Empty);

                int after = s.Length;

                int occurences = before - after;
                
                pairs.Add(new Pair(){ character = c, value  = occurences });
                Console.WriteLine(c  + occurences);       


            }         

            pairs = pairs.OrderBy(v => v.character).ToList();
            pairs = pairs.OrderByDescending(v => v.value).ToList();


            foreach(Pair p in pairs)
            {
                Console.WriteLine(p);

            }
        }
    }
}
