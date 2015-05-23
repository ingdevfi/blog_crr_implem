using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRR_CSharp
{
	class Program
	{
		static void Main(string[] args) {

			const int years = 1;
			const int steps = 26;
			const double deltaT = (double)years/(double)steps;
			const double volatility = 1.0/100.0;
			double u = Math.Exp(volatility*Math.Sqrt(deltaT));

			const double s0 = 100;
			const double strike = 90.0;
			const double sureTx = 5.0/100.0;

			double d = 1/u;
			double p = (Math.Exp(sureTx*deltaT) - d)/(u - d);

			var node = new BinomialTreeNode(s0, u, d, p, 0, steps);

			var result = node.Evaluate((s) => Math.Max(s - strike, 0));

			System.Console.Write(result);
			//Console.ReadLine();
		}
	}
}
