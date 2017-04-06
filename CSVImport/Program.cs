using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace CSVImport
{
    class Program
    {
        static string TempFile = @"E:\A\test.xml";
        static SelectieLijst selectielijst = new SelectieLijst();

        static TextWriter xmlWriter;
        static XmlSerializer xmlSerial;

        static void Main(string[] args)
        {
            selectielijst.Gemeente = "Sint-Truiden";
            selectielijst = ImportCSV(@"E:\A\lijst.csv");
            WriteXLS(selectielijst);

            Console.WriteLine("test");
            Console.ReadKey();
        }

        static private void WriteXLS(SelectieLijst lijst)
        {
            xmlWriter = new StreamWriter(TempFile);
            xmlSerial = new XmlSerializer(typeof(SelectieLijst));
            xmlSerial.Serialize(xmlWriter, lijst);
            xmlWriter.Close();
        }

        static private SelectieLijst ImportCSV(string s)
        {
            SelectieLijst lijst = new SelectieLijst();
             
            using (var fs = File.OpenRead(s))
            using (var reader = new StreamReader(fs, Encoding.Default, true))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var rij = line.Split(';');
                    SelectiePunt punt = new SelectiePunt();
                    if (punt.CSVImport(rij) == true)
                        lijst.Add(punt);
                    else
                        return null;
                }
            }
            return lijst;
        }

    }
}
