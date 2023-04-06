using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Практическая_8
{
    class CargoShip : IShip, ICargoTransport, ICloneable, IComparable
    {
        private double _fullWeight;
        private double _unladenWeight;
        private string _shipName;


        public string ShipName { get { return _shipName; } set { _shipName = value; } }
        public double FullWeight { get { return _fullWeight; } set { _fullWeight = value; } }
        public double UnladenWeight { get { return _unladenWeight; } set { _unladenWeight = value; } }


        public CargoShip(string name, double fullWeight, double unladenWeight)
        {
            if (fullWeight > unladenWeight)
            {
                _shipName = name;
                _fullWeight = fullWeight;
                _unladenWeight = unladenWeight;
            }
            else throw new ArgumentException("");
        }

        public double LoadCapacity()
        {
            return FullWeight - UnladenWeight;
        }

        public object Clone()
        {
            CargoShip shipClone = new(_shipName, _fullWeight, _unladenWeight);
            shipClone.FullWeight = this.FullWeight;
            shipClone.UnladenWeight = this.UnladenWeight;
            return shipClone;
        }

        public int CompareTo(object obj)
        {
            CargoShip temp = (CargoShip)obj;

            if (this.LoadCapacity() > temp.LoadCapacity()) return 1;
            if (this.LoadCapacity() < temp.LoadCapacity()) return -1;
            return 0;
        }
        public override string ToString()
        {
            return $"{ShipName}";
        }
    }

}
