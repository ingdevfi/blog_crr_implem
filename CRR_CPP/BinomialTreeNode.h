#pragma once
#include <functional>

template <int leftRank>
struct BinomialTreeNode {
	
	BinomialTreeNode<leftRank - 1> UpNode;
	BinomialTreeNode<leftRank - 1> DownNode;
	
	inline double Evaluate(const double& spot, const double& upFactor, const double& downFactor, const double & upProba, std::function<const double (const double &)> evaluateFunct) {
		return upProba*UpNode.Evaluate(spot*upFactor, upFactor, downFactor, upProba, evaluateFunct)
				+ (1 - upProba)*DownNode.Evaluate(spot*downFactor, upFactor, downFactor, upProba, evaluateFunct);
	}
};

template <>
struct BinomialTreeNode<0> {
	
	inline double Evaluate(const double& spot, const double& upFactor, const double& downFactor, const double& upProba, std::function<const double (const double &)> evaluateFunct) {
		return evaluateFunct(spot);
	}
};