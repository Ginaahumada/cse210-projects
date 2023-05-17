public class Generator
{
    public string _filename = "file.txt";
    public string[] _lines;
    public int _randPosition;
    public string _randomPrompt;

    public void LoadingPrompts()
    {
        _lines = System.IO.File.ReadAllLines(_filename);
    }
    public void ChoosingRandomPrompts()
    {
        if (_lines.Count() > 0)
        {
            Random rand = new Random();
            _randPosition = rand.Next(0, _lines.Count());

            _randomPrompt = _lines[_randPosition];
            Console.WriteLine(_randomPrompt);
        }
        else
        {
            Console.Write("All the prompts were displayed");
        }
    }
    public void EliminateDuplicatedPrompts()
    {
        string last_prompt = _lines[_lines.Count() - 1];
        _lines[_randPosition] = last_prompt;
        Array.Resize(ref _lines, _lines.Count() - 1);
    }
}