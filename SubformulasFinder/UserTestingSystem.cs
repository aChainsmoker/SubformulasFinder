// Выполнил студент группы 321701 БГУИР:
// - Неборский Иван Александрович
// Вариант 10
//
// Класс теста пользователя
// 20.04.2025
//
// Источники:
// - Проектирование программного обеспечения интеллектуальных систем (3 семестр)
//

namespace SubformulasFinder;

public class UserTestingSystem
{
    private List<string> formulasForTest = new List<string>() {"(((A->B)/\\(B->A))~(C->C))", "(((A~B)~C)~(D/\\E))", "((((P/\\(!Q))->R)~P)\\/(P/\\Q))", "(!(!(A\\/B))~C)", "((A\\/B)/\\(!C))", "(!((S->((!R)\\/(P/\\Q)))~(P/\\(!(Q->R)))))", "((((!P)\\/Q)~R)\\/((S->P)/\\Q))", "(R~(((!P)\\/(Q/\\R))~(S->(S->P))))", "((((P/\\(!Q))->R)~P)\\/(P/\\Q))", "(((P~Q)~((((P/\\R)/\\P)\\/(!P))->Q))\\/Q)"};
    
    public void TestUserKnowledge()
    {
        InputParser parser = new InputParser();
        int score = 0;
        foreach (string formula in formulasForTest)
        {
            IOSystem.AskForAnswer(formula);
            int answer = IOSystem.TakeTheInteger();
            bool correctness = answer == parser.FindSubformulas(formula).Count;
            IOSystem.ShowCorrectness(correctness);
            if(correctness) score++;
        }
        IOSystem.ShowTestResult(score, formulasForTest.Count);
    }
}