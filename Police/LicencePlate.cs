using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Police
{
    internal class LicencePlate:IComparer<LicencePlate>
    {
        private string plate;
        private void SetPlate(string plate)=>this.plate = plate.Length<10?plate:"Wrong format";
        public string Plate
        {
            get => plate;
            set=>SetPlate(value);
        }
        public LicencePlate(string plate)=>SetPlate(plate);
        public override string ToString()=>plate;

        public void Print()
        {
            Console.WriteLine(plate);
        }


        ///////////////////////////////////////////////////////////////

        public static bool operator ==(LicencePlate left, LicencePlate right)
        {
            return left.Plate == right.Plate;
        }
        public static bool operator !=(LicencePlate left, LicencePlate right)
        {
            return left.Plate != right.Plate;
        }

        public int Compare(LicencePlate left, LicencePlate right)
        {
            return left.Plate.CompareTo(right.Plate);
        }
        public override int GetHashCode()
        {
            return Plate.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            var k = obj as LicencePlate;
            //if (k != null)
            {
                return this.Plate == k.Plate;
            }
            return base.Equals(obj);
        }
    }
}
