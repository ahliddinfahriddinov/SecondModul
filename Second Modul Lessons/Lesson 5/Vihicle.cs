namespace Lesson_5;

public class Vihicle
{
    protected double Speed { get; set; }

    protected double _fuel;

    public double Fuel
    {
        get { return _fuel; }
        set
        {
            if (50 >= value + _fuel)
            {
                _fuel = value;
            }
        }

    }

}
