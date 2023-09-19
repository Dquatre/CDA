let nom = document.querySelectorAll(".nom");
let tel = document.querySelectorAll("input[type='tel']");
let num = document.querySelectorAll(".cp");
let email = document.querySelectorAll("input[type='email']");
let mdp = document.querySelectorAll("input[type='password']");
let sub = document.querySelector("input[type='submit']");

let listInputs = document.querySelectorAll("input:not([type='submit'])");

sub.disabled = true;

nom.forEach(element =>{
    element.addEventListener('input', function () {   
        verification(element,listInputs) ;
    });
});
tel.forEach(element =>{
    element.addEventListener('input', function () {   
        verification(element,listInputs) ;
    });
});
num.forEach(element =>{
    element.addEventListener('input', function () {   
        verification(element,listInputs) ;
    });
});
email.forEach(element =>{
    element.addEventListener('input', function () {   
        verification(element,listInputs) ;
    });
});

mdp.forEach(element =>{
    element.addEventListener('input',  function () {
        verification(element,listInputs) ;
    });
});

function verification(element,listInputs) {
    changeCouleur (element) ;
    activerSubmit(listInputs);
}

function activerSubmit(listInputs) {
    let flag = true;
    listInputs.forEach(input =>{
        if (!input.value.match(input.pattern) && flag) {
            flag = false;
        }
    });
    if (flag) {
        sub.disabled = false;
    }else{
        sub.disabled = true;
    }
}

function changeCouleur(element) {
    if (element.value.match(element.pattern)) {
            element.className = "";
    }else{
            element.className = "rouge";
    }
}