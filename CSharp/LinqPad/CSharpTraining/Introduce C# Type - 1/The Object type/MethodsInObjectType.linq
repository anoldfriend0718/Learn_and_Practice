<Query Kind="Program" />

void Main()
{
	"Methods in object type".H1();

	typeof(object).GetMethods(
		BindingFlags.Public
		| BindingFlags.NonPublic
		| BindingFlags.Static
		| BindingFlags.Instance)
	.Where(x => x.IsFamily || x.IsPublic)
	.Select(CreateSignature).Dump();
}

private string CreateSignature(MethodInfo mi)
{
	var accessModifier = mi.IsFamily ? "protected" : "public";
	var staticModifier = mi.IsStatic ? "static" : string.Empty;
	var virtualModifier = mi.IsVirtual ? "virtual" : string.Empty;
	var retTypeName = mi.ReturnType.Name;
	string argsName = string.Empty;
	if (mi.GetParameters().Length != 0)
	{
		argsName = mi.GetParameters()
		.Select(p => $"{p.ParameterType.Name} {p.Name}")
		.Aggregate((x, y) => $"{x} , {y}");
	}
	return $"{accessModifier} {staticModifier} {virtualModifier} {retTypeName} {mi.Name} ({argsName})";
}