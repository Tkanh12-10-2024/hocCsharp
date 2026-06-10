
namespace caculattor;
using System;
using System.Reflection.Metadata.Ecma335;

public class Cacul
{
    

    static bool equalsCaseIgnore(String left,String right) => left.ToUpper() == right.ToUpper();

    static void printFinalEquation(int num1,int num2,double result,string @Operator)
    {
        if(Operator == "+") 
        {
            result = num1 + num2;
            Console.WriteLine($"{num1} + {num2} = {result}");
        }
        if(Operator == "-")
        {
            result = num1 - num2;
            Console.WriteLine($"{num1} - {num2} = {result}");
        }
        if(Operator == "*")
        {
            result = num1*num2;
            Console.WriteLine($"{num1} * {num2} = {result}");
        }
        if(Operator == "/" ) {
            result = (double)num1/num2;
            Console.WriteLine($"{num1} / {num2} = {result}");
            
        }
    }

    static bool TryReadInt(string message, out int result)
{
    Console.Write(message + ": ");

    string input = Console.ReadLine() ?? "0";

    return int.TryParse(input, out result);
}
    static void Main()
    {
        Console.WriteLine("Hello !");
        if(!TryReadInt("Enter number 1",out int num1)) {
            Console.WriteLine("Please enter Integer!");
            return;
            }
        if(!TryReadInt("Enter number 2",out int num2)) {
            Console.WriteLine("Please enter integer!");
            return;
        }
        Console.WriteLine("What do you want to do ?\n [A]ddd\n [S]ubtraction\n [M]ultiplication\n [D]ivision\n [E]xit");
        string choice;
        string Operator;
    do {
        choice = Console.ReadLine() ?? "0";
        if(equalsCaseIgnore(choice,"A")) choice = "A";
        if(equalsCaseIgnore(choice,"S")) choice = "S";
        if(equalsCaseIgnore(choice,"M")) choice = "M";
        if(equalsCaseIgnore(choice,"D")) choice = "D";
        if(equalsCaseIgnore(choice,"E")) choice = "E";
        Operator = choice switch
        {
            "A" => "+",
            "S" => "-",
            "M" => "*",
            "D" => "/",
            "E" => "0",
            _ => "0",
        };
        if(Operator == "/")
        {
            if(num2 == 0) {
            Console.WriteLine($"number 2 need different zero !");
            return;
            }
        
        }
        double result = 0;
        if(Operator != "E" && Operator != "False") printFinalEquation(num1,num2,result,Operator);
    }
    while(Operator != "0");
        
    }
}