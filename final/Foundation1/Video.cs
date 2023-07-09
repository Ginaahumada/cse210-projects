public class Video
{
    private string _title;
    private string _author;
    private int _durationInSeconds;
    private List<Comment>_comments;

    public Video(string title, string author, int durationInSeconds)
    {
        _title = title;
        _author = author;
        _durationInSeconds = durationInSeconds;
        _comments = new List<Comment>();
    }
    public int GetCountOfComments()
    {
        return _comments.Count();
    }
    public void AddComment(string name, string text)
    {
        Comment comment = new Comment(name, text);
        _comments.Add(comment);
    }
    public string GetTitle()
    {
        return _title;
    }
    public string GetAuthor()
    {
        return _author;
    }
    public int GetDuration()
    {
        return _durationInSeconds;
    }
    public List<Comment> GetListOfComments()
    {
        return _comments;
    }
    public void DisplayInformation()
    {
        Console.WriteLine($"\nTitle: {_title}.");
        Console.WriteLine($"Author: {_author}.");
        Console.WriteLine($"Duration: {_durationInSeconds} seconds.");
        Console.WriteLine($"Number of comments: {GetCountOfComments()}.\n");
        Console.WriteLine("---- Box Comments ----");
        foreach(Comment comment in _comments)
        {
            Console.WriteLine($"\n    - {comment.GetPersonName()}");
            Console.WriteLine($"      {comment.GetTextComment()}\n");
        }
        Console.WriteLine("----------------------");
    }
}