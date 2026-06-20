namespace MyQuizzApp;
public interface IQuestion
{
    string Content { get; set; }
    void Display();
    string readAnswer();
    bool checkAnswer(string answer);
    string correctAnswer();
    

}