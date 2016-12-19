using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Xml;

namespace WindowsFormsApplication1
{
    class FastInputManager
    {
        Dictionary<string, string> dict;

        public FastInputManager()
        {
            dict = new Dictionary<string, string>();
        }

        public void Initialize(string filename)
        {
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader
                (
                    new FileStream(
                        filename,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.Read)
                );
                XmlDocument doc = new XmlDocument();
                string xmlIn = reader.ReadToEnd();
                reader.Close();
                doc.LoadXml(xmlIn);
                foreach (XmlNode child in doc.ChildNodes)
                    if (child.Name.Equals("appSettings"))
                        foreach (XmlNode node in child.ChildNodes)
                            if (node.Name.Equals("add"))
                                dict.Add
                                (
                                    node.Attributes["key"].Value,
                                    node.Attributes["value"].Value
                                );
            }
        }

        public void Initialize()
        {
            dict["1"] = "infinera1";
            dict["2"] = "infinera2";
            dict["3"] = "infinera3";
            dict["4"] = "infinera4";
            dict["5"] = "infinera5";
            dict["6"] = "infinera6";
            dict["7"] = "infinera7";
            dict["8"] = "infinera8";
            dict["9"] = "infinera9";
        }

        public string GetString(int index)
        {
            string key = index.ToString();
            if (dict.Keys.Contains<string>(key))
                return dict[key];
            else
                return "";
        }
    }
}
