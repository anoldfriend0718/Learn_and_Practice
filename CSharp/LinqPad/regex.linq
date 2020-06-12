<Query Kind="Program" />

void Main()
{ 
Regex reg=new Regex("^-{1,2}[a-zA-z]+$");
var input="--name";
var ret=reg.IsMatch(input);
reg.Match(input).Groups[1].Value.Dump();
ret.Dump();
}