<Query Kind="Program" />

void Main()
{
	"Reflection".H1();
	// Get Assembly
	Assembly asm = this.GetType().Assembly;
	
	// Get Type via Assembly
	Type type = asm.GetType("UserQuery+MyClass");
	
	// Create instance via Type
	object instance = Activator.CreateInstance(type);
	instance.Dump("instance");
	
	// Get Property via Type
	PropertyInfo[] properties = type.GetProperties();
	PropertyInfo prop = properties.Where(x => x.Name == "Prop").FirstOrDefault();
	// Set Property value
	prop.SetValue(instance, "A");
	instance.Dump("instance");
	
	// Get Method via Type
	MethodInfo[] methods = type.GetMethods();
	MethodInfo method = methods.Where(x => x.Name == "Run").FirstOrDefault();
	// Invoke method
	method.Invoke(instance, new object[]{"B"});	
}


public class MyClass
{
	public string Prop {get;set;}
	
	public void Run(string arg)
	{
		arg?.Dump("arg");
	}
}