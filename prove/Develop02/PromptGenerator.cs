public class PromptGenerator
{
    public string _filename = "myFile.txt";
    public string[] _lines;
    public Random _rand;
    public string _randomPrompt;

    public void LoadingPrompts()
    {
        _lines = System.IO.File.ReadAllLines(_filename);
    }
    public void ChossingRandomPrompts()
    {
        _rand = new Random();
        int randPosition = _rand.Next(0, _lines.Count());

        _randomPrompt = _lines[randPosition];
        List<string> prompts_used = new List<string>(_lines);
        prompts_used.RemoveAt(randPosition);
        _lines = prompts_used.ToArray();
        Console.WriteLine(_randomPrompt);
        
        
        //
        
    }

}