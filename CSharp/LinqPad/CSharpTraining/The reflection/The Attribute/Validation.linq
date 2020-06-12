<Query Kind="Program" />

void Main()
{
	"Use reflection to perform validation".H1();
	var validator = new ValidationManager();
	var control = new MyController();
	validator.Validate(control).Dump("Validate Name and Age not set");
	
	control.Name = "name";
	validator.Validate(control).Dump("Validate Age not set");
	
	control.Age = 9;
	validator.Validate(control).Dump("Validate Age not in range");
	
	control.Age = 50;
	validator.Validate(control).Dump("Validate all good");	
}

public class MyController
{
	[NotNull]
	public string Name{get;set;}	
	
	[Range(Min = 10, Max = 100)]
	public int Age {get;set;}
}

public interface IValidatable
{
	bool Validate(object value);
	
	string GetMessage(string propName, object value);
}

[AttributeUsage(AttributeTargets.Property,Inherited=false)]
public class NotNullAttribute : Attribute, IValidatable
{	
	public bool Validate(object value)
	{
		return value != null;
	}
	
	public string GetMessage(string propName, object value)
	{
		return $"{propName} should not be null. Current value : {value ?? "null"}";
	}
}

[AttributeUsage(AttributeTargets.Property,Inherited=false)]
public class RangeAttribute : Attribute, IValidatable
{	
	public int Min {get;set;}
	public int Max {get;set;}
	
	public bool Validate(object value)
	{
		var target = Convert.ToInt32(value);
		return Min <= target && target < Max;
	}
	
	public string GetMessage(string propName, object value)
	{
		return $"{propName} should between {Min} and {Max}. Current value : {value}";
	}	
}

public class ValidationManager
{
	public ValidationResult Validate<T>(T target) where T:class
	{	
		var ret = new ValidationResult();

		
		var messages = typeof(T).GetProperties()
			.SelectMany( p => 
							p.GetCustomAttributes(typeof(IValidatable), true),
			            	(p, att) => new {Prop = p, Validator = (IValidatable)att}
						)
			.Select( info => 
				{
					var singleValidateRet = info.Validator.Validate(info.Prop.GetValue(target));
					return singleValidateRet ? null
											 : info.Validator.GetMessage(info.Prop.Name, info.Prop.GetValue(target));
				})
			.Where ( msg => msg != null);
		
		ret.AddAll(messages);
		return ret;
	}
}

public class ValidationResult
{
	private List<string> _messages = new List<string>();

	public bool HasError 
	{
		get
		{
			return _messages.Count > 0;
		}
	}
	
	public IEnumerable<string> Errors
	{
		get
		{
			return _messages;
		}
	}
	
	public void AddAll(IEnumerable<string> messages)
	{
		_messages.AddRange(messages);
	}
}