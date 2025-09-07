namespace S28Con;

public abstract class CashDispenser
{
    protected CashDispenser _nextDispenser;

    public abstract int BankNoteUnit { get; }

    public void SetNext(CashDispenser cd)
    {
        _nextDispenser = cd;
    }

    public void Dispense(int amount)
    {
        int Amount2Dispense = amount / BankNoteUnit;
        if (Amount2Dispense > 0)
        {
            System.Console.WriteLine($"{BankNoteUnit} Dispenser: {Amount2Dispense}");
        }
        Amount2Dispense = amount % BankNoteUnit;
        if (_nextDispenser != null)
        {
            if (Amount2Dispense > 0)
                _nextDispenser.Dispense(Amount2Dispense % BankNoteUnit);
        }
        else if (Amount2Dispense > 0)
        {
            System.Console.WriteLine("ERROR : Cannot dispense");
        }
    }
}

public class CashDispenser100 : CashDispenser
{
    public override int BankNoteUnit => 100;
}
public class CashDispenser50 : CashDispenser
{
    public override int BankNoteUnit => 50;
}
public class CashDispenser20 : CashDispenser
{
    public override int BankNoteUnit => 20;
}
public class CashDispenser10 : CashDispenser
{
    public override int BankNoteUnit => 10;
}
public class CashDispenser5 : CashDispenser
{
    public override int BankNoteUnit => 5;
}




class Program
{
    static void Main(string[] args)
    {
        var cd100 = new CashDispenser100();
        var cd50 = new CashDispenser50();
        var cd20 = new CashDispenser20();
        var cd10 = new CashDispenser10();
        var cd5 = new CashDispenser5();


        cd100.SetNext(cd50);
        cd50.SetNext(cd20);
        cd20.SetNext(cd10);
        cd10.SetNext(cd5);


        cd100.Dispense(5235);
    }
}
