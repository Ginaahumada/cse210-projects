public class ExcerciseActivity : Activity
{
    private List<string> _listExcercise = new List<string>();
    private List<string> _Listdescription = new List<string>();
    private int _randomPos;

    public ExcerciseActivity(string name, string description) : base(name, description)
    {
        _listExcercise = new List<string>
        {
            "Neck stretches",
            "Back Stretches",
            "Shoulder rotation",
            "Abdominal contraction exercise",
            "Gluteal contraction exercise"
        };
        _Listdescription = new List<string>
        {
            "Slowly turn your head to one side, hold the position for a few seconds and then turn it to the other side. Repeat the movement several times to relieve tension in the neck and shoulders.",
            "Sit on the edge of your chair and slowly rotate your torso to one side, holding the back of the chair for stability. Hold the position for a few seconds and then repeat on the other side. This helps relieve stiffness and tension in the back.",
            "Sit upright in your chair and place your hands on your shoulders. Make forward circular motions with your shoulders, then switch and make backward circular motions. This helps release tension in the shoulders and neck.",
            "Sit in your chair with your back straight. Then, contract your abdominal muscles and hold the contraction for 10 seconds. Relax and repeat several times. This exercise helps strengthen your abdominal muscles.",
            "Sit in your chair and squeeze your gluteal muscles. Hold the contraction for 10 seconds and then relax. Repeat several times to strengthen your gluteal muscles."
        };
        

    }
    public void ObtainPrompt()
    {
        Random rand = new Random();
        _randomPos = rand.Next(_listExcercise.Count());
    }
    public void RunActivity()
    {
        base.DisplayingStartingMessage();
        base.SetDuration();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        base.ShowSpinner();
        ObtainPrompt();
        DisplayExercise();
        Console.ReadKey();
        base.SetStartActivity();
        while (base.VerifyTime(base.GetStartActivity())) // loop until the time set by user has elapsed
        {
            base.CountDown(base.GetDuration());
        }
        base.DisplayEndingMessage();
    }
    protected void DisplayExercise()
    {
        Console.WriteLine("Prepare for the following exercise:\n");
        Console.WriteLine($"--- {_listExcercise[_randomPos]} ---\n");
        Console.WriteLine(_Listdescription[_randomPos] + "\n");
        Console.Write("When you be prepared, press ENTER to Continue. \n");
    }
}