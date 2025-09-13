using System;

public class Complex
{
    public double Real;
    public double Imaginary;

    public Complex(double real, double imaginary)
    {
        this.Real = real;
        this.Imaginary = imaginary;
    }

    public override string ToString()
    {
        return $"{this.Real} + {this.Imaginary}i";
    }

    public static Complex operator +(Complex c1, Complex c2)
    {
        return new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }

    public double this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return this.Real;
                case 1: return this.Imaginary;
                default: throw new IndexOutOfRangeException("Index must be 0 or 1.");
            }
        }
        set
        {
            switch (index)
            {
                case 0: this.Real = value; break;
                case 1: this.Imaginary = value; break;
                default: throw new IndexOutOfRangeException("Index must be 0 or 1.");
            }
        }
    }

    public double this[bool isRealPart]
    {
        get
        {
            return isRealPart ? this.Real : this.Imaginary;
        }
        set
        {
            if (isRealPart)
                this.Real = value;
            else
                this.Imaginary = value;
        }
    }

    public static implicit operator double(Complex c)
    {
        return Math.Sqrt(c.Real * c.Real + c.Imaginary * c.Imaginary);
    }

    public static implicit operator Complex(double d)
    {
        return new Complex(d, 0);
    }
}