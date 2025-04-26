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

namespace SKNF_SDNF;

public class InputParser
{
     private readonly char[] _operations = new char[] { '!', '~', '/', '\\', '-' };
     private List<char> _letters = new List<char>();
     
     public List<char> Letters {get => _letters;}

     public string ReformFormula(string formula)
     {
          Stack<char> formulaStack = new Stack<char>();
          string reformedFormula = String.Empty;
               
          for (int k = 0; k < formula.Length; k++)
          {

               if (formula[k] == '(')
                    formulaStack.Push(formula[k]);
               if (formula[k] == ')')
               {

                    while (formulaStack.Peek() != '(')
                    {
                         reformedFormula += formulaStack.Pop();
                    }

                    formulaStack.Pop();
               }


               if ((formula[k] >= 'a' && formula[k] <= 'z') || (formula[k] >= 'A' && formula[k] <= 'Z'))
               {
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
     
     public List<string> FindSubformulas(string reformedFormula)
     {
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
          if(formula.Length >= 3)
               return new String("(" + formula + ")");
          return formula;
     }

     private int PrioSet(char operation)
     {
          switch (operation)
          {
               case '!': return 3;
               case '&': case '|': case '~': case '>': case '-': case '/': case '\\': return 2;
               case '(': return 1;
          }
          return 0;
     }
}