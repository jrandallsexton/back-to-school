console.log("hello from console");

document.getElementById("myHeading").textContent = "dynamically set h2 content";

var para = document.getElementById("myP");

para.textContent = "dynamically set paragraph";

let x = 123 + "X";

para.textContent = `dynamically set paragraph to: ${x.toLowerCase()}`;
para.textContent += " (" + typeof(x) + ")";

let online = true;
console.log(`Bro is online ${online}`);

let foo = 1;
console.log(foo);

foo++;
console.log(foo);

foo += 1;
console.log(foo);

// input
let userInput;
document.getElementById("mySubmit").onclick = function() {
    userInput = document.getElementById("myInput").value;
    console.log(userInput+=1, typeof userInput);

    // type conversions
    let age = Number(userInput);
    console.log(age+=1, typeof age);
};

let someBool = Boolean("0");
console.log(`someBool: ${someBool} => makes zero sense`);

// string ops
let username = "jrandallsexton";
console.log(`charAt[0]: ${username.charAt(0)}`);
console.log(`Length: ${username.length}`);
