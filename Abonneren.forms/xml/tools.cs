using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Abonneren
{
    public static class Tools
    {
        static public void ToonFout(string fout)
        {
            MessageBox.Show(fout);
        }

        static public SelectieLijst ReadSelectielijst(string fn)
        {
            TextReader xmlReader;
            XmlSerializer xmlSerial;

            try
            {
                xmlReader = new StreamReader(fn);
                xmlSerial = new XmlSerializer(typeof(SelectieLijst));

                SelectieLijst lijst = new SelectieLijst();
                lijst = (SelectieLijst)xmlSerial.Deserialize(xmlReader);
                xmlReader.Close();
                return lijst;
            }
            catch
            {
                return null;
            }
        }

        static public AboLijst ImportAbo(string fn)
        {

            AboLijst lijst = new AboLijst();
            if (File.Exists(fn))
            {
                TextReader xmlReader;
                XmlSerializer xmlSerial;

                xmlReader = new StreamReader(fn);
                xmlSerial = new XmlSerializer(typeof(AboLijst));
                lijst = (AboLijst)xmlSerial.Deserialize(xmlReader);
                xmlReader.Close();
            }
            return lijst;
        }

        static public void ExportAbo(string fn,AboLijst abonnementenlijst)
        {
            TextWriter xmlWriter;
            XmlSerializer xmlSerial;

            xmlWriter = new StreamWriter(fn);
            xmlSerial = new XmlSerializer(typeof(AboLijst));
            xmlSerial.Serialize(xmlWriter, abonnementenlijst);
            xmlWriter.Close();
        }

    }
}
