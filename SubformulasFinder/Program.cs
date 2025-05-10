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
// Программа считающая количество подформул в формуле сокращённого языка логики

using SubformulasFinder;

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
        try
        {
            InputParser parser = new InputParser();
            string formula = IOSystem.TakeTheFormula();
            List<string> subformulas = parser.FindSubformulas(formula);
            IOSystem.ShowAmountOfSubformulas(subformulas);
        }
        catch
        {
            Console.WriteLine("Incorrect input, please try again.");
            return;
        }
    }
    
    
    private static void RunTest()
    {
        UserTestingSystem userTestingSystem = new UserTestingSystem();
        userTestingSystem.TestUserKnowledge();
    }
}



//((a->(b->(c->(d->(e->(f->(g->(h->(i->(j->(k->(l->(m->(n->(o->(p->(q->(r->(s->(t->(u->(v->(w->(x->(y->z)))))))))))))))))))))))))->a)
//(!((S->((!R)\/(P/\Q)))~(P/\(!(Q->R)))))