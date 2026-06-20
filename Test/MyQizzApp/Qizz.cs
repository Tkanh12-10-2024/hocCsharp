namespace MyQuizzApp;

using System;
using System.Collections.Generic;
using System.Linq;

public class Qizz
{
    private List<IQuestion> questions;
    private List<AnswerRecord> records;

    public Qizz(List<IQuestion> questions)
    {
        this.questions = questions;
        records = new List<AnswerRecord>();
    }

    public void Start()
    {
        int score = 0;

        Console.WriteLine("===== QUIZ APP =====");

        for (int i = 0; i < questions.Count; i++)
        {
            Console.WriteLine();
            Console.WriteLine($"Question {i + 1}");

            questions[i].Display();

            string answer = questions[i].readAnswer();

            bool correct = questions[i].checkAnswer(answer);

            if (correct)
            {
                score++;
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine("Wrong!");
            }

            records.Add(
                new AnswerRecord(
                    i + 1,
                    questions[i].Content,
                    answer,
                    questions[i].correctAnswer(),
                    correct
                )
            );
        }

        showSummary(score);
        showLastWrongAnswer();
        showLongestCorrect();
    }

    private void showSummary(int score)
    {
        int total = questions.Count;

        int wrong = total - score;

        double percent = score * 100.0 / total;

        string rank;

        if (percent >= 80)
        {
            rank = "Excellent";
        }
        else if (percent >= 65)
        {
            rank = "Good";
        }
        else if (percent >= 50)
        {
            rank = "Average";
        }
        else
        {
            rank = "Need Improvement";
        }

        Console.WriteLine();
        Console.WriteLine("===== SUMMARY =====");
        Console.WriteLine($"Total Questions: {total}");
        Console.WriteLine($"Correct Answers: {score}");
        Console.WriteLine($"Wrong Answers: {wrong}");
        Console.WriteLine($"Score: {score}/{total}");
        Console.WriteLine($"Rank: {rank}");
    }

    private void showLastWrongAnswer()
    {
        Console.WriteLine();
        Console.WriteLine("===== LAST 3 WRONG ANSWERS =====");

        var wrongAnswers =
            records.Where(x => !x.IsCorrect)
                   .TakeLast(3);

        foreach (var item in wrongAnswers)
        {
            Console.WriteLine(
                $"Question {item.QuestionNumber}: " +
                $"{item.QuestionContent}"
            );

            Console.WriteLine($"Your Answer: {item.UserAnswer}");
            Console.WriteLine($"Correct Answer: {item.CorrectAnswer}");
            Console.WriteLine();
        }
    }

    private void showLongestCorrect()
    {
        int maxLength = 0;
        int currentLength = 0;

        int start = 0;
        int end = 0;

        int tempStart = 0;

        for (int i = 0; i < records.Count; i++)
        {
            if (records[i].IsCorrect)
            {
                if (currentLength == 0)
                {
                    tempStart = i + 1;
                }

                currentLength++;

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    start = tempStart;
                    end = i + 1;
                }
            }
            else
            {
                currentLength = 0;
            }
        }

        Console.WriteLine();

        if (maxLength == 0)
        {
            Console.WriteLine("No correct answers.");
        }
        else
        {
            Console.WriteLine(
                $"Longest correct streak: " +
                $"Question {start} to Question {end} " +
                $"({maxLength} questions)"
            );
        }
    }
}