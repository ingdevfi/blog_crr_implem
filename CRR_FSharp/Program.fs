// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
type EvalFunc = double -> double

let rec BinomTreeEval (leftRank:double, spot:double, upFactor:double, downFactor:double, upProba:double, evalfunc:EvalFunc):double =
    if(leftRank >0.0) then
        upProba*BinomTreeEval(leftRank-1.0, upFactor*spot, upFactor, downFactor, upProba, evalfunc) 
        + (1.0-upProba)*BinomTreeEval(leftRank-1.0, downFactor*spot, upFactor, downFactor, upProba, evalfunc)
    else
        evalfunc(spot)


[<EntryPoint>]
let main argv =
    let years = 1.0
    let steps = 26.0
    let deltaT = years/steps
    let volatility = 1.0/100.0
    let u = exp(volatility*sqrt(deltaT))

    let s0 = 100.0
    let strike = 90.0
    let sureTx = 5.0/100.0

    let d = 1.0/u
    let p = (exp(sureTx*deltaT) - d)/(u - d)
    let r = BinomTreeEval(steps, s0, u, d, p, fun s -> max (s - strike)  0.0)
    printfn "%f" r // return an integer exit code
    0
