// Выполнил студент группы 321701 БГУИР:
// - Неборский Иван Александрович
// Вариант 10
//
// Класс входа в программу
// 20.04.2025
//
// Источники:
// - Проектирование программного обеспечения интеллектуальных систем (3 семестр)
//

using SKNF_SDNF;

namespace SubformulasFinder;

class Program
{
    private static void Main(string[] args)
    {
        while(true)
            Run();
    }

    private static void Run()
    {
        InputParser parser = new InputParser();
        string reformedFormula = parser.ReformFormula(IOSystem.TakeTheFormula());
        List<string> subformulas = parser.FindSubformulas(reformedFormula);
        IOSystem.ShowAmountOfSubformulas(subformulas);
    }
}



//((a->(b->(c->(d->(e->(f->(g->(h->(i->(j->(k->(l->(m->(n->(o->(p->(q->(r->(s->(t->(u->(v->(w->(x->(y->z)))))))))))))))))))))))))->a)
//(!((S->((!R)\/(P/\Q)))~(P/\(!(Q->R)))))