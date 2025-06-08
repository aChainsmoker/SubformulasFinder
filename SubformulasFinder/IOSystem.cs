// Выполнил студент группы 321701 БГУИР:
// - Неборский Иван Александрович
// Вариант 10
//
// Класс ввода\вовода
// 20.04.2025
//
// Источники:
// - Проектирование программного обеспечения интеллектуальных систем (3 семестр)
//


namespace SubformulasFinder;

public static class IOSystem
{
    public static void ShowAmountOfSubformulas(List<string> subformulas)
    {
        if (subformulas.Count == 0)
            throw new ArgumentException("Formula is empty.");
        PrepareFormulas(subformulas);
        for(int i = 0; i < subformulas.Count; i++)
        {
            Console.WriteLine(i + ": " + subformulas[i]);
        }
        Console.WriteLine(subformulas.Count + " is the final amount.");
    }

    private static void PrepareFormulas(List<string> subformulas)
    {
        for (int i = 0; i < subformulas.Count; i++)
        {
            for(int j = 0; j < subformulas[i].Length; j++)
                switch(subformulas[i][j])
                {
                    case '-':
                        subformulas[i]=subformulas[i].Insert(++j, ">");
                        break;
                    case '/':
                        subformulas[i]=subformulas[i].Insert(++j, "\\");
                        break;
                    case '\\':
                        subformulas[i]=subformulas[i].Insert(++j, "/");
                        break;
                    default:
                        break;
                }
        }
    }

    public static string TakeTheFormula()
    {
        Console.WriteLine("Enter logical expression");
        return Console.ReadLine();
    }

    public static int TakeTheModeOption()
    {
        int modeIndex;
        Console.WriteLine("Select mode:\n1.Find subformulas amount.\n2.Knowledge check.");
        while (!int.TryParse(Console.ReadLine(), out modeIndex) || (modeIndex != 1 && modeIndex != 2))
        {
            Console.WriteLine("Please enter a valid option.");
        }
        return modeIndex;
    }

    public static void AskForAnswer(string formula)
    {
        Console.WriteLine($"How many subformulas is in the formula?\n{formula}");
    }

    public static int TakeTheInteger()
    {
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Please enter an integer.");
        }
        return number;
    }

    public static void ShowCorrectness(bool correctness)
    {
        if (correctness)
        {
            Console.WriteLine("Correct answer!");
        }
        else
        {
            Console.WriteLine("Incorrect answer!");
        }
    }

    public static void ShowTestResult(int score, int questionsAmount)
    {
            Console.WriteLine($"Your result is {score}/{questionsAmount}");   
    }
}