

    for(var i=1; i<=10 ; i++){
        document.getElementById("counting").innerHTML += i + "<br>";
    }



//     var container = document.getElementById("counting");
// var output = "";
// for(var i=0; i<10 ; i++){
//     output += i + "<br>";
// }
// container.innerHTML = output;


   for(var i=65; i<=90 ; i++){
        document.getElementById("alphabet").innerHTML += String.fromCharCode(i) + "<br>";
    }


    let count =   document.getElementsByTagName("table").length

    document.getElementById("tableCountDisplay").innerHTML = "Total tables: " + count;


const tables = document.querySelectorAll("table");

tables.forEach((table, index) => {
    const totalRows = table.rows.length; 
    console.log(`Table ${index + 1} has ${totalRows} total rows.`);
});


const items = ["mango", "banana", "apple", "grape", "orange"];
const select = document.getElementById("dropdown");

// var el = document.getElementById("date");
// el.innerHTML =  new Date();

// function refreshTime(){
//     setInterval(() => {
//         el.innerHTML =  new Date();
//         // console.log(el.innerHTML);
//     },1000)
// }


var date = document.getElementById("date");
var time = document.getElementById("time");

date.innerHTML =  new Date().toDateString();
time.innerHTML =  new Date().toLocaleTimeString();