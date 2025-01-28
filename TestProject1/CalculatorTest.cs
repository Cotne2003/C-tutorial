using AppForTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
	public class CalculatorTest
	{
		[Fact]
		public void Percentage_WhenGivenTwoDouble_ReturnsPercentage()
		{
			Calculator calculator = new Calculator();
			double result = calculator.Percentage(150, 10);
			Assert.Equal(15, result);
		}
	}
}
