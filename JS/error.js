//JavaScript will actually create an Error object with two properties: name and message.
try
{
    throw "too big"
}
catch(err)
{
    console.log(err)
}

//The throw statement allows you to create a custom error.

//Technically you can throw an exception (throw an error).

//The exception can be a JavaScript String, a Number, a Boolean or an Object:

var x;
try {
  x = y + 1;   // y cannot be referenced (used)
}
catch(err) {
  console.log(err.name);
  console.log(err.message) ;
}