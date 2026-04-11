import { add, multiply } from './math.js';
import greet from './greet.js';

// Arrow function
const showResult = () => {
    console.log("Add:", add(2, 3));
    console.log("Multiply:", multiply(2, 3));
    console.log(greet("Kishan"));
};

// Rest + Spread
const testRestSpread = (...nums) => {
    console.log("Rest:", nums);

    const newArr = [...nums, 100];
    console.log("Spread:", newArr);
};

showResult();
testRestSpread(1, 2, 3, 4);