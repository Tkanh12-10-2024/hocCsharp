using MyQuizzApp;
using System.Collections.Generic;
Console.WriteLine("Hello, World!");
QuestionBank<IQuestion> bank = new QuestionBank<IQuestion>();

bank.Add(
    new MultipleChoiceQuestion(
        "Which keyword is used to create a class in C#?",
        new List<string>
        {
            "struct",
            "class",
            "using",
            "namespace"
        },
        2
    )
);

bank.Add(
    new TrueFalseQuestion(
        "C# is an object-oriented programming language.",
        true
    )
);

bank.Add(
    new MultipleChoiceQuestion(
        "Which data type is used to store whole numbers?",
        new List<string>
        {
            "string",
            "int",
            "bool",
            "char"
        },
        2
    )
);

bank.Add(
    new TrueFalseQuestion(
        "An interface can be instantiated directly.",
        false
    )
);

bank.Add(
    new MultipleChoiceQuestion(
        "Which symbol is used for inheritance in C#?",
        new List<string>
        {
            "extends",
            "base",
            ":",
            "inherit"
        },
        3
    )
);

bank.Add(
    new TrueFalseQuestion(
        "List<T> is a collection class in C#.",
        true
    )
);

bank.Add(
    new MultipleChoiceQuestion(
        "Which method is commonly used to print text to the console?",
        new List<string>
        {
            "Console.ReadLine()",
            "Console.WriteLine()",
            "Print()",
            "Write()"
        },
        2
    )
);

bank.Add(
    new TrueFalseQuestion(
        "An abstract class can be instantiated directly.",
        false
    )
);

bank.Add(
    new MultipleChoiceQuestion(
        "Which keyword is used to declare an interface?",
        new List<string>
        {
            "interface",
            "class",
            "struct",
            "enum"
        },
        1
    )
);

bank.Add(
    new TrueFalseQuestion(
        "The bool type can only have two values: true and false.",
        true
    )
);
Qizz qizz = new Qizz(bank.GetAll());
qizz.Start();