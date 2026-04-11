// function add(a,b){
//     return a+b;
// }

// const add = (a,b) => a+b;


// function sum(...numbers){
//     return  numbers;
// }

// console.log(sum(1,2,3,4,5));



// const arr =[1,2,3,4,5];

// console.log(...arr);



// 🔹 Arrow Function
const multiply = (a, b) => a * b;
console.log("Arrow Function:", multiply(3, 4));


// 🔹 Rest Operator
const sumAll = (...numbers) => {
    let total = 0;
    for (let num of numbers) {
        total += num;
    }
    return total;
};

console.log("Rest Operator:", sumAll(1, 2, 3, 4, 5));


// 🔹 Spread Operator (Array)
const arr1 = [1, 2, 3];
const arr2 = [...arr1, 4, 5];

console.log("Spread Array:", arr2);


// 🔹 Spread Operator (Object)
const obj1 = { name: "Kishan", age: 21 };
const obj2 = { ...obj1, city: "Delhi" };

console.log("Spread Object:", obj2);


// 🔹 Combining Everything
const calculate = (a, b, ...extra) => {
    console.log("a:", a, "b:", b);
    console.log("extra (rest):", extra);

    const allValues = [a, b, ...extra]; // spread
    return allValues.reduce((sum, val) => sum + val, 0); // arrow
};

console.log("Combined:", calculate(1, 2, 3, 4, 5));