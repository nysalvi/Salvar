using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace Salvar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            string filepath = System.IO.Path.GetDirectoryName("\\save.xml");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<int>));

            
            Random random = new Random();

            TextWriter textWriter = new StreamWriter(filepath);
            TextReader textReader = new StreamReader(filepath);
            
            if (File.Exists(filepath)) File.Delete(filepath);
            if (true)
            {                
                for (int i = 0; i < 16; i += random.Next(5) + 1)
                {
                    Console.WriteLine(i);
                    list.Add(i);
                }
                xmlSerializer.Serialize(textWriter, list);
                textWriter.Close();
            }
            else
            {
                if (File.Exists(filepath))
                {
                    List<int> listaNova = (List<int>)xmlSerializer.Deserialize(textReader);
                    textReader.Close();
                }                
            }


        }
    }
}
