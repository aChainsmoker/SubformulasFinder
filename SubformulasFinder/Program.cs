using SKNF_SDNF;

namespace SubformulasFinder;

class Program
{
    static void Main(string[] args)
    {
        InputParser parser = new InputParser();
        string reformedFormula = parser.ReformFormula("((a>(b>(c>(d>(e>(f>(g>(h>(i>(j>(k>(l>(m>(n>(o>(p>(q>(r>(s>(t>(u>(v>(w>(x>(y>z)))))))))))))))))))))))))>a)");
        List<string> subformulas = parser.FindSubformulas(reformedFormula);
        IOSystem.ShowAmountOfSubformulas(subformulas);
    }
}