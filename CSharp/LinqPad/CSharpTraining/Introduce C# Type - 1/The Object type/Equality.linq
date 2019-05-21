<Query Kind="Program" />

void Main()
{
	"Equality".H1();

	"===== default equals =====".H2();
	TestDefaultEquals();

	"===== custom equals =====".H2();
	TestCustomEquals();

	"===== default hash =====".H2();
	TestDefaultHash();

	"===== custom hash =====".H2();
	TestCustomHash();
}

public void TestDefaultHash()
{
	var container = new HashSet<MyClass1>();
	container.Add(new MyClass1() { Id = 10 });
	container.Contains(new MyClass1() { Id = 10 }).Dump("default hashset contain");
}

public void TestCustomHash()
{
	var container = new HashSet<MyClass>();
	container.Add(new MyClass() { Id = 10 });
	container.Contains(new MyClass() { Id = 10 }).Dump("custom hashset contain");
}

public void TestDefaultEquals()
{
	var instance1 = new MyClass1() { Id = 10 };
	var instance2 = new MyClass1() { Id = 10 };

	instance1.GetHashCode().Dump("HashCode1:");
	instance2.GetHashCode().Dump("HashCode2:");
	(instance1 == instance2).Dump("default equals:");

	object.Equals(instance1, instance2).Dump("Object equals:");
}

public void TestCustomEquals()
{
	var instance1 = new MyClass() { Id = 10 };
	var instance2 = new MyClass() { Id = 10 };

	instance1.GetHashCode().Dump("HashCode1:");
	instance2.GetHashCode().Dump("HashCode2:");
	(instance1 == instance2).Dump("custom equals:");

	object.Equals(instance1, instance2).Dump("Object equals:");
}

// classes
class MyClass1
{
	public long Id { get; set; }

	public int Age { get; set; }

	public string Name { get; set; }
}


class MyClass : IEquatable<MyClass>
{
	public long Id { get; set; }

	public int Age { get; set; }

	public string Name { get; set; }

	public bool Equals(MyClass other)
	{
		if (ReferenceEquals(null, other)) return false;
		if (ReferenceEquals(this, other)) return true;
		if (other.GetType() != this.GetType()) return false;
		return Id == other.Id && Age == other.Age && string.Equals(Name, other.Name);
	}

	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != this.GetType()) return false;
		return Equals((MyClass)obj);
	}

	public override int GetHashCode()
	{
		unchecked
		{
			var hashCode = Id.GetHashCode();
			hashCode = (hashCode * 397) ^ Age;
			hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
			return hashCode;
		}
	}

	public static bool operator ==(MyClass left, MyClass right)
	{
		return Equals(left, right);
	}

	public static bool operator !=(MyClass left, MyClass right)
	{
		return !Equals(left, right);
	}
}