public class FileHandler
{
    private string _filename;
    public FileHandler(string filename)
    {
        _filename = filename;
    }
    public void WriteInFile(List<Video> listOfVideos)
    {
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            Console.WriteLine($"\nSaving videos in the file.....\n");
            foreach (Video video in listOfVideos)
            {
                outputFile.WriteLine($"Title: {video.GetTitle()}");
                outputFile.WriteLine($"Author: {video.GetAuthor()}");
                outputFile.WriteLine($"Duration: {video.GetCountOfComments()}");
                outputFile.WriteLine("---- Box Comments ----");
                foreach(Comment comment in video.GetListOfComments())
                {
                    outputFile.WriteLine($"\n    - {comment.GetPersonName()}");
                    outputFile.WriteLine($"      {comment.GetTextComment()}\n");
                }
                outputFile.WriteLine("----------------------");
            }
        }
    }


}