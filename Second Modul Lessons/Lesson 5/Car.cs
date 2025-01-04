namespace Lesson_5;

public class Car : Vihicle
{
    public void Refuel(double amount)
    {
        Fuel += amount;
    }
    public void Drive(double distance)
    {
       Console.WriteLine(distance / Speed);
    }
}
