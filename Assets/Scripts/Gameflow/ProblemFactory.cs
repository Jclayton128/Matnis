using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemFactory : MonoBehaviour
{
    GameController gc;
    GameModeHolder gmh;
    QuestionPanel_UI qpd;
    AnswerFactory af;

    //state
    Problem currentProblem;

    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        gmh = gc.GetComponent<GameModeHolder>();
        qpd = FindObjectOfType<QuestionPanel_UI>();
        af = FindObjectOfType<AnswerFactory>();
    }

    public void CreateNewProblem()
    {
        currentProblem = CreateProblemInternally();
        qpd.UpdateProblem(currentProblem);
        af.UpdateAnswerSelection(currentProblem);

    }


    private Problem CreateProblemInternally()
    {
        Problem problem = new Problem();
        switch (gmh.GetCurrentGameMode().SelectedMode)
        {            
            case GameMode.Mode.ZeroPlusSmallMix:
                problem.TopNumber = 0;
                problem.BottomNumber = UnityEngine.Random.Range(0, 10);
                problem.OpChar = '+';
                problem.Answer = problem.TopNumber + problem.BottomNumber;
                //Debug.Log($"new problem: {problem.TopNumber} + {problem.BottomNumber} = {problem.Answer}");
                problem = ScrambleProblem(problem);
                //Debug.Log($"post-scrambled problem: {problem.TopNumber} + {problem.BottomNumber} = {problem.Answer}");
                return problem;

            case GameMode.Mode.SmallDoubles:
                int number = UnityEngine.Random.Range(0, 10);
                problem.TopNumber = number;
                problem.BottomNumber = number;
                problem.OpChar = '+';
                problem.Answer = problem.TopNumber + problem.BottomNumber;
                problem = ScrambleProblem(problem);
                return problem;

            case GameMode.Mode.SmallDoublesPlusOne:
                number = UnityEngine.Random.Range(0, 10);
                problem.TopNumber = number;
                problem.BottomNumber = number + 1;
                problem.OpChar = '+';
                problem.Answer = problem.TopNumber + problem.BottomNumber;
                problem = ScrambleProblem(problem);
                return problem;



            default:
                problem.TopNumber = 0;
                problem.BottomNumber = 0;
                problem.Answer = 0;
                problem.OpChar = '+';
                return problem;
        }
        
    }

    private Problem ScrambleProblem(Problem problem)
    {
        if (Random.Range(0,2) == 0)
        {
            Problem scrambledProblem = new Problem();
            scrambledProblem.BottomNumber = problem.TopNumber;
            scrambledProblem.TopNumber = problem.BottomNumber;
            scrambledProblem.OpChar = problem.OpChar;
            scrambledProblem.Answer = problem.Answer;
            return scrambledProblem;
        }
        else
        {
            return problem;
        }
    }
}
