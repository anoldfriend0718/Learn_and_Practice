var cars=["BMW","Volvo"]
var cars2=new Array("BMW","Volvo")
console.log(cars==cars2)

cars[0]="Saab"
console.log(cars);
console.log(typeof cars)

//Array Elements Can Be Objects
//JavaScript variables can be objects. Arrays are special kinds of objects.

//Because of this, you can have variables of different types in the same Array.

//You can have objects in an Array. You can have functions in an Array. You can have arrays in an Array:

cars.forEach(car=>console.log(car))

var fruits = ["Banana", "Orange", "Apple", "Mango"];
fruits.push("Lemon");    // adds a new element (Lemon) to fruits
console.log(fruits.length)
fruits.forEach(x=>console.log(x.length))

//The Difference Between Arrays and Objects
//In JavaScript, arrays use numbered indexes.  
//In JavaScript, objects use named indexes.
console.log(typeof fruits)
console.log(Array.isArray(fruits))

console.log(fruits.join(","))

fruits.pop()
console.log(fruits.length)

var x =fruits.shift()
console.log(fruits.length)
console.log(x)

fruits.unshift("Lemon")
fruits.forEach(x=>console.log(x))

//merge
var myGirls = ["Cecilie", "Lone"];
var myBoys = ["Emil", "Tobias", "Linus"];
var myChildren = myGirls.concat(myBoys);   // Concatenates (joins) myGirls and myBoys

var arr1 = ["Cecilie", "Lone"];
var arr2 = ["Emil", "Tobias", "Linus"];
var arr3 = ["Robin", "Morgan"];
var myChildren = arr1.concat(arr2, arr3);   // Concatenates arr1 with arr2 and arr3
