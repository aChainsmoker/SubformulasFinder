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
        try
        {   
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



//((A->(B->(C->(D->(E->(F->(G->(H->(I->(J->(K->(L->(M->(N->(O->(P->(Q->(R->(S->(T->(U->(V->(W->(X->(Y->Z)))))))))))))))))))))))))->A)
//(!((S->((!R)\/(P/\Q)))~(P/\(!(Q->R)))))
//(A~(B/\C))
//(A~((B/\C)))
//((A))
//((!A))
//(A)
// ((A)
// (1/\0)