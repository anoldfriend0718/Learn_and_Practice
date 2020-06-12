<Query Kind="Program" />

void Main()
{
string a="111";
a.GetType().Dump("string");
var ret=Convert.ChangeType(a,typeof(int));
ret.Dump();
ret.GetType().Dump("ret");
}