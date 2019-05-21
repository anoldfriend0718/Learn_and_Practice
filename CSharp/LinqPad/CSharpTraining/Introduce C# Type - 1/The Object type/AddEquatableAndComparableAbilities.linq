<Query Kind="Program" />

void Main()
{
	"Add Equatable and Comparable ablilities".H1();

	var data = new Dictionary<MyData, double>(new MyEqualityComparer())
	{
		{new MyData(1,55), 1},
		{new MyData(2,44), 2},
		{new MyData(3,33), 4},
		{new MyData(4,22), 5},
		{new MyData(5,11), 8},
	};

	data.Dump("Initial value");
	data[new MyData(0, 11)].Dump("Take by another value property");

	var keys = data.Keys.ToList();
	keys.Sort(new MyComparer());
	keys.Dump("Custom Comparer:");
}

public class MyData
{
	public double Value { get; set; }

	public double AnotherValue { get; set; }

	public MyData(double value, double anotherValue)
	{
		Value = value;
		AnotherValue = anotherValue;
	}
}

public class MyComparer : IComparer<MyData>
{
	public int Compare(MyData v1, MyData v2)
	{
		return v1.AnotherValue.CompareTo(v2.AnotherValue);
	}
}

public class MyEqualityComparer : IEqualityComparer<MyData>
{
	public bool Equals(MyData v1, MyData v2)
	{
		return v1.AnotherValue == v2.AnotherValue;
	}

	public int GetHashCode(MyData v)
	{
		return v.AnotherValue.GetHashCode();
	}
}