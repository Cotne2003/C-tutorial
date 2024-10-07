using ItStepHomeWork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItStepHomeWork.Classes
{
	class Circle : IShape
	{
        public int Radius { get; set; }
        public double GetArea()
		{
			return Radius * Radius;
		}
	}
}
