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
        public override string ToString()
        {
            return $"{DateTime.ToString()}: {Violations.list[ID].PadRight(30)}{Place}";
        }
    }
}
