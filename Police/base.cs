using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

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
                sw.Write(i.Key + ":");
                foreach(Crime j in i.Value) 
                {
                    sw.Write(j + ",");
                }
                sw.WriteLine();
            }
            sw.Close();
            System.Diagnostics.Process.Start("notepad",filename);
        }
    }
}
