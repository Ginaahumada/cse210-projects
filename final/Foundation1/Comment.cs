public class Comment
{
    private string _personName;
    private string _textComment;

    public Comment(string name, string text)
    {
        _personName = name;
        _textComment = text;
    }
    public string GetPersonName()
    {
        return _personName;
    }
    public string GetTextComment()
    {
        return _textComment;
    }

}