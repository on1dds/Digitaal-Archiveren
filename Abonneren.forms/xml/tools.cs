using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

namespace Concorderen
{
    public static class Tools
    {

        #region Diensten
        //static public List<String> getADDiensten()
        //{
        //    List<String> lijst = new List<String>();
        //    // create your domain context
        //    PrincipalContext ctx = GetDomain();
        //    if (ctx != null)
        //    {
        //        GroupPrincipal qbeGroup = new GroupPrincipal(ctx);
        //        PrincipalSearcher srch = new PrincipalSearcher(qbeGroup);

        //        foreach (var found in srch.FindAll())
        //        {
        //            Principal p = (Principal)found;
        //            string naam = p.Name;
        //            if (naam.Length > 7 && naam.Substring(0, 7) == "dienst_")
        //                lijst.Add(naam.Substring(7));
        //        }
        //    }
        //    else
        //    {
        //        string[] d = { "aaa", "bbb", "ccc" };
        //        foreach (string dienst in d)
        //        {
        //            lijst.Add(dienst);
        //        }
        //    }
        //    return lijst;
        // }
        #endregion

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

    }
}
