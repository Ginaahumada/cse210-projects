public class Word
{
    private string _word;
    private bool _isHidden;
    public Word(string word)
    {
        _word = word;
        Show();
    }
    public void Hide()
    {
        _isHidden = true;
    }
    private void Show()
    {
        _isHidden = false;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetRenderedWord()
    {
        if(_isHidden)
        {
            string _undercores = "";
            foreach(char word in _word)
            {
                _undercores += '_';
            }
            return _undercores;
        }
        else
        {
            return _word;
        }
    }
}