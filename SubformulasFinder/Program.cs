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
        int modeOption = IOSystem.TakeTheModeOption();
        switch (modeOption)
        {
            case 1:
                RunSubformulasFinder();
                break;
            case 2:
                RunTest();
                break;
            default:
                break;
        }
    }

    private static void RunSubformulasFinder()
    {
        InputParser parser = new InputParser();
        string formula = IOSystem.TakeTheFormula();
        List<string> subformulas = parser.FindSubformulas(formula);
        IOSystem.ShowAmountOfSubformulas(subformulas);
    }
    
    
    private static void RunTest()
    {
        UserTestingSystem userTestingSystem = new UserTestingSystem();
        userTestingSystem.TestUserKnowledge();
    }
}



//((a->(b->(c->(d->(e->(f->(g->(h->(i->(j->(k->(l->(m->(n->(o->(p->(q->(r->(s->(t->(u->(v->(w->(x->(y->z)))))))))))))))))))))))))->a)
//(!((S->((!R)\/(P/\Q)))~(P/\(!(Q->R)))))