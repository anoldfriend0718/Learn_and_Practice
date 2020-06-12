<Query Kind="Program" />

void Main()
{
	"Operator and implicit/explicit type conversion".H1();
	Rational x = 1;
	Rational y = 1.1d;	
	
	Rational z = x + y;		
	z.Dump();
	
	int a = (int)z;
	a.Dump("int value");
}

// Define other methods and classes here
public sealed class Rational
{
	private double _value;
	
	// constructors
	public Rational(int value)
	{
		_value = value;
	}
	
	public Rational(float value)
	{
		_value = value;
	}
	
	public Rational(double value)
	{
		_value = value;
	}
	
	// conversions
	public int ToInt()
	{
		return (int)_value;
	}
	
	public float ToSingle()
	{
		return (float)_value;
	}
	
	public double ToDouble()
	{
		return _value;
	}
	
	// conversion operator
	public static implicit operator Rational(int value)
	{
		return new Rational(value);
	}
	
	public static implicit operator Rational(float value)
	{
		return new Rational(value);
	}
	
	public static implicit operator Rational(double value)
	{
		return new Rational(value);
	}
	
	public static explicit operator Int32(Rational value)
	{
		return value.ToInt();
	}
	
	public static explicit operator Single(Rational value)
	{
		return value.ToSingle();
	}
	
	public static explicit operator Double(Rational value)
	{
		return value.ToDouble();
	}
	
	public static Rational operator +(Rational x, Rational y)
	{
		return x._value + y._value;
	}
	
	public override string ToString()
	{
		return _value.ToString();
	}
}