namespace MyQuizzApp;
using System;
using System.Collections.Generic;

public class MultipleChoiceQuestion : IQuestion
{
    public string Content {get; set;}
    private List<string> _options;
    private int correct;  

    public MultipleChoiceQuestion(string content,List<string> Option,int Correct)
    {
        Content = content;
        _options = Option;
        correct = Correct;
    }

    public string readAnswer()
    {
        while(true)
        {
            Console.WriteLine("Enter Answer: ");
            string input = Console.ReadLine() ?? "";
            if(!int.TryParse(input,out int value))
            {
                Console.WriteLine("Enter Interger !");
                continue;
            }
            if(value < 1 || value > _options.Count)
            {
                Console.WriteLine("wrong choice out of choice");
                continue;
            }
            return input;
        }
    }

    public void Display()
    {
    Console.WriteLine(Content);

    for(int i = 0; i < _options.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {_options[i]}");
    }
    }

    public bool checkAnswer(string answer)
    {
        return int.Parse(answer) == correct;
    }

    public string correctAnswer()
    {
        return _options[correct -1];
    }


}
