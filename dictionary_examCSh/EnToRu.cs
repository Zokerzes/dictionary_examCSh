using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dictionary_examCSh
{
    public class EnToRu
    {
        private Dictionary<string, List<string>> slovar;

        public EnToRu()
        {
            slovar = new Dictionary<string, List<string>>();
        }
        public void Add(string str1, string str2)
        {
            if (slovar.ContainsKey(str1)) slovar[str1].Add(str2);
            else slovar.Add(str1, new List<string> { str2 });
        }
        public void Del(string str)
        {
            if (slovar.ContainsKey(str)) slovar.Remove(str);
        }
        public void Del(string str1, string str2)
        {
            if (slovar.ContainsKey(str1) && slovar[str1].Contains(str2)) slovar[str1].Remove(str2);
        }
        public void Print(string str)
        {
            if (slovar.ContainsKey(str))
            {
                Console.Write(str + " = ");
                Console.WriteLine(string.Join(" ", slovar[str]));
            }
            else Console.WriteLine("не знаю такого слова " + str);
        }
        public void writeFile(string patch = "dict.txt")
        {
            using (var writer = new StreamWriter(patch))
            {
                foreach (var item in slovar)
                {
                    
                    foreach (var item2 in item.Value)
                    {
                        Console.WriteLine($"{item.Key}\t{item2}");
                        writer.WriteLine($"{item.Key}\t{item2}");
                    }
                }
            }
        }

        public void readFile(string patch = "dict.txt")
        {
            using (var reader = new StreamReader(patch))
            {
                while (!reader.EndOfStream)
                {
                    string temp = reader.ReadLine();
                    string[] str = temp.Split('\t');
                    Add(str[0], str[1]);
                }
            }
            foreach (var item in slovar)
            {

                foreach (var item2 in item.Value)
                {
                    Console.WriteLine($"{item.Key}\t{item2}");
                }
            }



        }
           
    }

}
