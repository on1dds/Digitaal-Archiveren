using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace MaakMappen
{
    class Program
    {
        static string startpad = @"E:\B";
        static SelectieLijst selectielijst = new SelectieLijst();


        static void Main(string[] args)
        {
            bool exists = System.IO.Directory.Exists(startpad);
            if (!exists) CreateFolder(startpad);

            selectielijst = Tools.ReadXML(@"E:\A\test.xml");

            MaakMappen(selectielijst.Selectiepunten,0);
        }


        static private void MaakMappen(List<SelectiePunt> lijst,int p)
        {
            foreach (SelectiePunt punt in lijst)
            {
                string s = "";
                switch (p)
                {
                    case 0:
                        s = punt.Basisindeling;
                        break;
                    case 1:
                        s = punt.Domein;
                        break;
                    case 2:
                        s = punt.Taak;
                        break;
                    case 3:
                        s = punt.Handeling;
                        break;
                    case 4:
                        s = punt.Document;
                        break;
                    default:
                        s = punt.Basisindeling;
                        break;
                }
                CreateFolder(getPath(punt));
                if (punt.Selectiepunten.Count > 0)
                    MaakMappen(punt.Selectiepunten, p + 1);
            }
        }

        static string getPath(SelectiePunt p)
        {
            return startpad + @"\" + p.Basisindeling + @"\" + p.Domein + @"\" + p.Taak + @"\" + p.Handeling + @"\" + p.Document;
        }


        static void CreateFolder(string pad)
        {
            bool exists = System.IO.Directory.Exists(pad);
            if (!exists) System.IO.Directory.CreateDirectory(pad);
        }
    }
}
