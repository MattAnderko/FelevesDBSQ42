using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelevesDBSQ42
{
    internal class Classroom
    {

        private int FloorNumber { get; }
        private int DoorNumber { get; }
        public bool HasComputers { get; }
        public bool HasProjector { get; }
        public Classroom(char type, int FloorNumber, int DoorNumber)
        {
            switch (type)
            {
                case 'c':
                    HasComputers = true;
                    break;
                case 'p':
                    HasProjector = true;
                    break;
                default:
                    break;
            }
            this.FloorNumber = FloorNumber;
            this.DoorNumber = DoorNumber;
        }

        public override string ToString()
        {
            return $"{FloorNumber}.{DoorNumber}";
        }

    }
}
