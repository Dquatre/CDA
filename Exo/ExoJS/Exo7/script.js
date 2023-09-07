nom = document.querySelectorAll(".nom");
tel = document.querySelectorAll(".tel");
num = document.querySelectorAll(".cp");
email = document.querySelectorAll(".email");
mdp = document.querySelectorAll(".mdp");
nom.forEach(element =>{
    element.addEventListener('change', function () {   
        if (element.value.match(element.pattern)) {
            element.className = "";
        }else{
            element.className = "rouge";
        }
    });
});
tel.forEach(element =>{
    element.addEventListener('change', function () {   
        if (element.value.match(element.pattern)) {
            element.className = "";
        }else{
            element.className = "rouge";
        }
    });
});
num.forEach(element =>{
    element.addEventListener('change', function () {   
        if (element.value.match(element.pattern)) {
            element.className = "";
        }else{
            element.className = "rouge";
        }
    });
});
email.forEach(element =>{
    element.addEventListener('change', function () {   
        if (element.value.match(element.pattern)) {
            element.className = "";
        }else{
            element.className = "rouge";
        }
    });
});
mdp.forEach(element =>{
    element.addEventListener('change', function () {   
        if (element.value.match(element.pattern)) {
            element.className = "";
        }else{
            element.className = "rouge";
        }
    });
});