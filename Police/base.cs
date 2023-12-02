using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime;

namespace Police
{
    internal class Base
    {
        private Dictionary<LicencePlate, List<Crime>> police_base;
        const string delimiter = "\n-------------------------------\n";

        public Base(Dictionary<LicencePlate, List<Crime>> police_base)
        {
            this.police_base = new Dictionary<LicencePlate, List<Crime>>(police_base);
        }
        public void Print()
        {
            foreach (KeyValuePair<LicencePlate, List<Crime>> i in police_base)
            {
                Console.WriteLine($"{i.Key}:\n");
                foreach (Crime j in i.Value)
                {
                    Console.WriteLine(j.ToString());
                }
                Console.WriteLine(delimiter);
            }
        }
        public void Save(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            foreach(KeyValuePair<LicencePlate,List<Crime>> i in police_base)
            {
                sw.Write(i.Key + "@");
                foreach(Crime j in i.Value) 
                {
                    sw.Write(j+";");
                }
                sw.WriteLine();
            }
            sw.Close();
            System.Diagnostics.Process.Start("notepad",filename);
        }
        
        public Dictionary<LicencePlate, List<Crime>> Load(string filename)
        {
            string line;
            string[] crimes;
            string[] crime;
            string[] detail;
            try
            {
                StreamReader sr=new StreamReader(filename);
                line = sr.ReadLine();
                Dictionary<LicencePlate, List <Crime>> police = new Dictionary<LicencePlate, List<Crime>>();
                while (line != null) 
                {
                    //police.Add(new LicencePlate(line.Substring(0,line.IndexOf("@"))),???);
                    crimes = line.Split('@');
                    //crimes[0] - LicencePlate
                    crime = crimes[1].Split(';');
                    foreach(string details in crime) 
                    {
                        detail = details.Split(',');
                        //detail[0] - DateTime
                        //detail[1] - Violation
                        //detail[2] - Plase
                        police.Add(crimes[0],new Crime(Int32.Parse(detail[1]), DateTime.Parse(detail[0]), detail[2]));
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                return police;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not Found!!!");
            }
        }
    }
}
