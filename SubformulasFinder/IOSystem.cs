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
                        subformulas[i].Insert(++j, "\\");
                        break;
                    case '\\':
                        subformulas[i].Insert(++j, "/");
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
    
    
    
}