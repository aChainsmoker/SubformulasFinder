namespace SubformulasFinder;

public static class IOSystem
{
    public static void ShowAmountOfSubformulas(List<string> subformulas)
    {
        for(int i = 0; i < subformulas.Count; i++)
        {
            Console.WriteLine(i + ": " + subformulas[i]);
        }
        Console.WriteLine(subformulas.Count + " is the final amount.");
    }
}