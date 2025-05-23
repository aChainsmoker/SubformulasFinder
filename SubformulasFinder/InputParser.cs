// Выполнил студент группы 321701 БГУИР:
// - Неборский Иван Александрович
// Вариант 10
//
// Класс парсинга строки и разбиения её на подформулы
// 20.04.2025
//
// Источники:
// - Проектирование программного обеспечения интеллектуальных систем (3 семестр)
//

using System.Runtime.InteropServices.JavaScript;

namespace SubformulasFinder;

public class InputParser
{
     private readonly char[] _operations = new char[] { '!', '~', '/', '\\', '-' };
     private List<char> _letters = new List<char>();
     
     public List<char> Letters {get => _letters;}

     public string ReformFormula(string formula)
     {
          Stack<char> formulaStack = new Stack<char>();
          string reformedFormula = String.Empty;
          formula = formula.Trim();
          
          if(!CheckIfFormulaHasRightAmountOfBracets(formula))
               throw new ArgumentException("Brackets are placed incorrectly");
          
          for (int k = 0; k < formula.Length; k++)
          {
               if(CheckIfSymbolIsValid(formula[k]) == false)
                    throw new ArgumentException("Invalid formula");
               
               if (formula[k] == '(')
                    formulaStack.Push(formula[k]);
               if (formula[k] == ')')
               {
                    if(formulaStack.Peek() == '(' && formula.Length > 3)
                         throw new ArgumentException("Brackets are placed incorrectly");
                    while (formulaStack.Peek() != '(')
                    {
                         reformedFormula += formulaStack.Pop();
                    }
                    
                    formulaStack.Pop();
               }


               if ((formula[k] >= 'A' && formula[k] <= 'Z') || (formula[k] == '1' || formula[k] == '0'))
               {
                    if (k != 0 && ((formula[k - 1] >= 'A' && formula[k - 1] <= 'Z') ||
                                   (formula[k - 1] == '1' || formula[k - 1] == '0')))
                         throw new ArgumentException("Incorrect formula");
                    
                    reformedFormula += formula[k];
                    if(!_letters.Contains(formula[k]))
                        _letters.Add(formula[k]);
               }


               if (_operations.Contains(formula[k]))
               {
                    while (formulaStack.Count != 0 && PrioSet(formulaStack.Peek()) >= PrioSet(formula[k]))
                    {
                         reformedFormula += formulaStack.Pop();
                    }

                    formulaStack.Push(formula[k]);

                    if (formula[k] == '/' || formula[k] == '\\' || formula[k] == '-')
                         ++k;
               }    
          }
          
          while (formulaStack.Count != 0)
          {
               reformedFormula += formulaStack.Pop();
          }

          _letters.Sort();
          return reformedFormula;
     }

     private bool CheckIfSymbolIsValid(char symbol)
     {
          if ((symbol >= 'A' && symbol <= 'Z') || (symbol == '1' || symbol == '0') || _operations.Contains(symbol) || symbol == '(' || symbol == ')' || symbol == '>' )
               return true;
          return false;
     }

     private bool CheckIfFormulaHasRightAmountOfBracets(string formula)
     {
          int amountOfBracets = 0;
          foreach (var symbol in formula)
          {
               if (symbol == '(')
                    amountOfBracets++;
               else if (symbol == ')')
                    amountOfBracets--;
          }
          return amountOfBracets == 0;
     }
     
     public List<string> FindSubformulas(string formula)
     {
          _letters.Clear();
          string reformedFormula = ReformFormula(formula);
          List<string> subformulas = new List<string>(_letters.Select(l => l.ToString()));
          Stack<string> formulaStack = new Stack<string>();

          for (int i = 0; i < reformedFormula.Length; i++)
          {
               if (_operations.Contains(reformedFormula[i]))
               {
                    string rez, var1, var2;
                    if (reformedFormula[i] == '!')
                    {
                         var1 = formulaStack.Pop();
                         rez = reformedFormula[i] + WrapInBracketsIfNeeded(var1);
                         subformulas.Add(rez);
                         formulaStack.Push(rez);
                         continue;
                    }
                    var1 = formulaStack.Pop();
                    var2 = formulaStack.Pop();
                    rez = WrapInBracketsIfNeeded(var2) + reformedFormula[i] + WrapInBracketsIfNeeded(var1);
                    subformulas.Add(rez);
                    formulaStack.Push(rez);
               }
               else
               {
                    formulaStack.Push(reformedFormula[i].ToString());
               }
          }
          return subformulas.Distinct().ToList();
     }

     private string WrapInBracketsIfNeeded(string formula)
     {
          if(formula.Length >= 3 || (formula.Length >= 2 && formula.Contains('!')))
               return new String("(" + formula + ")");
          return formula;
     }

     private int PrioSet(char operation)
     {
          switch (operation)
          {
               case '!': return 3;
               case '~':  case '-': case '/': case '\\': return 2;
               case '(': return 1;
          }
          return 0;
     }
}