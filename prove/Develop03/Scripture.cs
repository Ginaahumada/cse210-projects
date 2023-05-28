public class Scripture
{
    private Reference _reference;
    private List<Word> _contentWordByWord = new List<Word>();
    
    public Scripture()
    {
        Random r = new Random();
        string[] _linesOfScriptures = System.IO.File.ReadAllLines("scriptures.txt");
        int randomNumber = r.Next(0, _linesOfScriptures.Count()-1);
        string line = _linesOfScriptures[randomNumber];
        string[] vector = line.Split('#'); 
        string reference = vector[0].Trim(); 
        string[] verses = vector[1].Trim().Split('$'); 
        LoadBookChapterAndVerse(reference);
        LoadWordsList(verses);
    }
    private void LoadBookChapterAndVerse(string reference)
    {
        string[] line = reference.Split(' '); 
        string book = line[0].Trim(); 
        string[] line2 = line[1].Split(':'); 
        int chapter = int.Parse(line2[0].Trim()); 
        if (line2[1].Contains("-")) 
        {
            line = line2[1].Split('-');
            int start = int.Parse(line[0]);
            int end = int.Parse(line[1]);
            _reference = new Reference(start, end, book, chapter);
        }
        else
        {
            
            int start = int.Parse(line2[1]);
            _reference = new Reference(start, book, chapter);
        }
    }
    private void LoadWordsList(string[] verses)
    {
        foreach(string verse in verses)
        {
            string[] words = verse.Split(' ');
            foreach(string singleWord in words)
            {
                Word word = new Word(singleWord.Trim());
                _contentWordByWord.Add(word);
            }
        }
    }
    public void HideWords()
    {
        Random r = new Random();

        int randomWordIndex = r.Next(_contentWordByWord.Count());
        int times = 1;
        while(times <= 3 & IsCompletelyHidden() == false)
        {
            if (_contentWordByWord[randomWordIndex].IsHidden())
            {
                while(_contentWordByWord[randomWordIndex].IsHidden() == true)
                {
                    randomWordIndex = r.Next(_contentWordByWord.Count());
                }
                _contentWordByWord[randomWordIndex].Hide();
            }
            else
            {
                _contentWordByWord[randomWordIndex].Hide();
            }
            times++;
        }
        
    }
    public string GetScripture()
    {
        Console.Write(_reference.GetReference());
        string renderedText = "";
        foreach (Word word in _contentWordByWord)
        {
            renderedText += word.GetRenderedWord() + " ";
        }
        return renderedText.Trim();

    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _contentWordByWord)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}