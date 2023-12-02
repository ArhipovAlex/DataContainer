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
        public Base() 
        {
            this.police_base = new Dictionary<LicencePlate, List<Crime>>();
        }
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
                    Console.WriteLine(j.ToScreen());
                }
                Console.WriteLine(delimiter);
            }
        }
        public void Save(string filename)
        {
            StreamWriter sw = new StreamWriter(filename);
            foreach (KeyValuePair<LicencePlate, List<Crime>> i in police_base)
            {
                sw.Write(i.Key + ":");
                foreach (Crime j in i.Value)
                {
                    sw.Write(j + ";");
                }
                sw.WriteLine();
            }
            sw.Close();
            System.Diagnostics.Process.Start("notepad", filename);
        }

        public void Load(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            while(!sr.EndOfStream) 
            {
                string buffer = sr.ReadLine();
                LicencePlate plate = new LicencePlate(buffer.Split(':')[0]);
                buffer = buffer.Replace(plate + ":", "");
                string[] crimes = buffer.Split(';');
                crimes = crimes.Where(val=>val!="").ToArray();
                List<Crime> list_of_crimes =new List<Crime>();
                foreach(string crime in crimes)
                {
                    list_of_crimes.Add(new Crime(crime));
                }
                police_base.Add(plate, list_of_crimes);
            }
            sr.Close();
        }
    }
}
