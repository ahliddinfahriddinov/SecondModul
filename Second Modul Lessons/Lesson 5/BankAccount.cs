namespace Lesson_5;

public class BankAccount
{
    private double _accountNumber;

    public double AccountNumber
    {
        get { return _accountNumber; }
    }

    private double _balance;
    public double Balance
    {
        get { return _balance; }

    }
    public void Deposite(double amount)
    {
        _accountNumber += amount;
    }
}

