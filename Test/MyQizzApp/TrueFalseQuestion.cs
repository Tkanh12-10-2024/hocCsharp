namespace MyQuizzApp;

public class TrueFalseQuestion : IQuestion
{
    public string Content { get; set; }

    private bool correct;

    public TrueFalseQuestion(string content, bool CorrectAnswer)
    {
        Content = content;
        correct = CorrectAnswer;
    }

    public void Display()
    {
        Console.WriteLine(Content + " (Y/N)");
    }

    public string readAnswer()
    {
        while (true)
        {
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine()!.ToUpper();

            if (input == "Y" || input == "N")
            {
                return input;
            }

            Console.WriteLine("Just enter Y or N.");
        }
    }

    public bool checkAnswer(string answer)
    {
        bool value = answer.ToUpper() == "Y";

        return value == correct;
    }

    public string correctAnswer()
    {
        return correct ? "Y" : "N";
    }
}