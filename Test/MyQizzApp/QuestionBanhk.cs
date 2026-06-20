namespace MyQuizzApp;

using System.Collections.Generic;

public class QuestionBank<T> where T : IQuestion
{
    private List<T> _question = new List<T>();

    public void Add(T question)
    {
        _question.Add(question);
    }

    public List<T> GetAll()
    {
        return _question;
    }
}