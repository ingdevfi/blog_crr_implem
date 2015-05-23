using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRR_CSharp {
	internal class BinomialTreeNode {
		private BinomialTreeNode _downNode;
		private readonly double _spot;
		private BinomialTreeNode _upNode;
		private readonly double _upProba;

		public BinomialTreeNode(double spot, double upFactor, double downFactor, double upProba, int currentRank,int targetRank) {

			_spot = spot;
			_upProba = upProba;

			if (targetRank - currentRank != 0) {
				var nodeTasks = new List<Task>(2) {
					Task.Run(
						() => _upNode = new BinomialTreeNode(spot*upFactor, upFactor, downFactor, upProba, currentRank + 1, targetRank)),
					Task.Run(
						() =>
							_downNode = new BinomialTreeNode(spot*downFactor, upFactor, downFactor, upProba, currentRank + 1, targetRank))
				};

				Parallel.ForEach(nodeTasks, t => t.Wait());
			}

			//Console.WriteLine(string.Format("Node rank:{0} spot:{1} created", currentRank, _spot));
		}

		public double Evaluate(Func<double, double> evaluateFunc) {
			double optionPrice;
			if (_upNode != null && _downNode != null) 
				optionPrice = _upProba*_upNode.Evaluate(evaluateFunc) + (1 - _upProba)*_downNode.Evaluate(evaluateFunc);
			else 
				optionPrice = evaluateFunc(_spot);
			
			//Console.WriteLine(String.Format("Spot {0} => Option price: {1}", _spot, optionPrice));
			return optionPrice;
		}
	}
}