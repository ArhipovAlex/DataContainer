using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Police
{
    internal class Crime
    {
        int id;
        //DateTime dateTime;
        //string place;
        public int ID
        {
            get => id;
            private set=>id = value<Violations.list.Count?value:0;
        }
        public DateTime DateTime { get; private set; }
        public string Place { get; private set; }
        public Crime(int id, DateTime dateTime, string place)
        {
            ID = id;
            DateTime = dateTime;
            Place = place;
        }
        public Crime(string description)
        {
            string[] elements=description.Split(' ');
            description=description.Replace(elements[0]+" ", "");
            description=description.Replace(elements[1]+" ", "");
            long timestamp = Convert.ToInt64(elements[0]);
            DateTime=DateTime.FromBinary(timestamp);
            ID = Convert.ToInt32(elements[1]);
            Place = description;
        }
        public override string ToString()
        {
            var viol = Violations.list;
            return $"{DateTime.ToBinary()} {ID} {Place}";
        }
        public string ToScreen()
        {
            return $"{DateTime.ToString()}: {Violations.list[ID]},{Place}";
        }

    }
}
