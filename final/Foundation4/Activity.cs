public class Activity
{
    //setting as DateTime so format can be manipulated
    private DateTime _date;
    private double _activityLength;  //in minutes

    public Activity(string date, double activityLength){
        //capture input as string and parse to DateTime
        _date = DateTime.Parse(date);
        _activityLength = activityLength;
    }

    //Setup default formulas as virtuals
    public virtual double GetDistance(){
        return (GetSpeed() * GetActivityLength())/60;
    }
    public virtual double GetSpeed(){
        return (GetDistance() / GetActivityLength())*60;
    }
    public virtual double GetPace(){
        return 60/GetSpeed();
    }
    public double GetActivityLength(){
        return _activityLength;
    }
    
    public string GetSummary(){
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({GetActivityLength()} min) - Distance {GetDistance().ToString("0.00")} miles, Speed {GetSpeed().ToString("0.00")} mph, Pace: {GetPace().ToString("0.00")} min per mile";
    }
}