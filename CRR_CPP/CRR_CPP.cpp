// CRR_CPP.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "BinomialTreeNode.h"
#include <iostream>
#include <algorithm>
#include <math.h>  

int _tmain(int argc, _TCHAR* argv[])
{
	const int years = 1;
	const int steps = 26;
	const double deltaT = (double)years / (double)steps;
	const double volatility = 1.0 / 100.0;
	double u = exp(volatility*sqrt(deltaT));

	const double s0 = 100;
	const double strike = 90.0;
	const double sureTx = 5.0 / 100.0;
	double d = 1 / u;
	double p = (exp(sureTx*deltaT) - d) / (u - d);

	BinomialTreeNode<26> node;

	auto result = node.Evaluate(s0, u, d, p, [strike](double s) { return std::max(s - strike, 0.0);});

	std::cout << result;

	//_sleep(10000);
	
	return 0;
}

