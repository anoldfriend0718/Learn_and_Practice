//string length
var text="ABCD"
var sln=text.length
console.log(sln)

//string can be object 
var x="hello world"
console.log(typeof x)
var y=new String("hello world")
console.log(typeof y)
//
//Don't create strings as objects. It slows down execution speed.
//The new keyword complicates the code. This can produce some unexpected results:
// typeof x will return string
// typeof y will return object
// if they are equal 
console.log(x==y) //true
console.log(x===y) //false: because x and y have different types(string and object)

var x=new String("Xu")
var y=new String("Xu")
console.log(x==y) //false, they are different objects 
console.log(x===y)//false, they are different objects
//Note the difference between (x==y) and (x===y).
//Comparing two JavaScript objects will always return false.


//find a string in a string 
var str="Please locate where 'locate' occurs"
var pos=str.indexOf("locate")
var end=str.lastIndexOf("locate")
var posfromstart=str.indexOf("locate",15)
console.log(pos)
console.log(end)
console.log(posfromstart)

var pos=str.indexOf("unknown")
console.log(pos)
var spos=str.search("unknown")
console.log(spos)


//slice
//This example slices out a portion of a string from position 7 to position 12 (13-1):
var str="Apple, Banana, Kiwi"
var res=str.slice(7,13)
console.log(res)

var res=str.slice(-4,-1)
console.log(res)

var res=str.slice(-4)
console.log(res)

//substring
//substring() is similar to slice().
//The difference is that substring() cannot accept negative indexes.
var res=str.substring(7,13)
console.log(res)

//replace
//The difference is that substring() cannot accept negative indexes.
//By default, the replace() method replaces only the first match:
str = "Please visit Microsoft!";
var n = str.replace("Microsoft", "W3Schools");
console.log(n)
str = "Please visit Microsoft and Microsoft!";
var n = str.replace("Microsoft", "W3Schools");
console.log(n)
//By default, the replace() method is case sensitive. Writing MICROSOFT (with upper-case) will not work:
//To replace case insensitive, use a regular expression with an /i flag (insensitive):
str = "Please visit Microsoft!";
var n = str.replace(/MICROSOFT/i, "W3Schools");
console.log(n)
//To replace all matches, use a regular expression with a /g flag (global match):
str = "Please visit Microsoft and Microsoft!";
var n = str.replace(/Microsoft/g, "W3Schools")
console.log(n)

//concat 
var text = "Hello" + " " + "World!";
var text = "Hello".concat(" ", "World!");

//split
var txt = "a,b,c,d,e";   // String
a=txt.split(",");          // Split on commas
console.log(a)