using ItStepHomeWork.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItStepHomeWork.Classes
{
	class Triangle : IShape
	{
		public double GetCircleArea(double radius)
		{
			throw new NotImplementedException();
		}

		public double GetSquareArea(double side)
		{
			throw new NotImplementedException();
		}

		public double GetTriangleArea(double side, double heigth)
		{
			return (side * heigth) / 2;
		}
	}
}
