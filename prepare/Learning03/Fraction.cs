using System.Diagnostics;

public class Fraction
{
    private int _numberator;
    private int _denominator;

    public Fraction()
    {
        _numberator = 1;
        _denominator = 1;
    }

    public Fraction(int wholeNumber)
    {
        _numberator = wholeNumber;
        _denominator = 1;
    }

    public Fraction(int top, int bottom)
    {
        _numberator = top;
        _denominator = bottom;
    }

    public string GetFractionString()
    {
        string text = $"{_numberator}/{_denominator}";
        return text;
    }

    public double GetDecimalValue()
    {
        return (double)_numberator / _denominator;
    }
}