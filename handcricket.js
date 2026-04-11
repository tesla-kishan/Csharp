let userScore = 0;
let computerScore = 0;

function playHandCricket(){
    let user = Number(prompt("Enter a number between 1 and 6"));
    let computer = Math.floor(Math.random() * 6) + 1;

    let result = document.getElementById("result");

    if(user < 1 || user > 6){
        alert("Please enter a valid number between 1 and 6");
        return;
    }
    if(user == computer){
        result.innerHTML = "OUT ! Both Choose" + user;

        userScore =0;
        computerScore =0;
    }
    else {
        userScore += user;
        computerScore += computer;
        result.innerHTML = "You chose " + user + " and computer chose " + computer + "<br>" + userScore + " - " + computerScore  ;
    }
}