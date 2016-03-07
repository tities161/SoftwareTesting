using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Testing
{
    public class Controller:Expenditure 
    {
        public List<Expenditure> Exps = new List<Expenditure>();
        public string s = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + @"\Database\";
        public void LoadList()
        {
            string path = DateTime.Now.ToString("MM-yyyy");
            string content = "";
            if (File.Exists(s + path))
            {
                content = File.ReadAllText(s + path);
            }
            string[] lines = content.Split('\u000A');
            foreach (string line in lines)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    string[] words = line.Split('*');
                    add(words[0],words[1],float.Parse(words[2]));
                }
            }
        }

        public void WriteTotal(string a)
        {
                string path = s + "total" + DateTime.Now.ToString("MM-yyyy");
                File.WriteAllText(path,a);
        }

        public void WriteList()
        {
            string path = DateTime.Now.ToString("MM-yyyy");
            File.WriteAllText(s + path, "");
            File.WriteAllText(s + path, DisplayList());
        }

        public string DisplayList()
        {
            string a = "";
            foreach(Expenditure e in Exps)
            {
                a += e.Date + "*" + e.Title + "*" + e.Cost + "\u000D\u000A";
            }
            return a;
        }

        public void add(string d, string t, float c)
        {
            Expenditure e = new Expenditure(d, t, c);
            Exps.Add(e);
        }

        public float CalTotal()
        {
            float total = 0;
            foreach (Expenditure e in Exps)
            {
                total += e.Cost;
            }
            return total;
        }

        public string LoadMax()
        {
            string path = DateTime.Now.ToString("MM-yyyy");
            string max = "";
            if (File.Exists(s + "total" + path))
            {
                max=File.ReadAllText(s + "total" + path);
            }
            return max;
        }


        public float CalAva()
        {
            return (float.Parse(LoadMax()) - CalTotal());
        }

    }
}
