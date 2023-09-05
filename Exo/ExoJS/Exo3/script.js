
paragraph = document.querySelectorAll(".para");
paragraph.forEach(element =>{
    element.addEventListener('click', changeColor);
});

function changeColor(event) { 
    textClique = event.target;
     if (textClique.style.color == "") {
        textClique.style.color = "#00FF00";
    }else{
        textClique.style.color = "";
    }
};

//titre


titreh1 = document.querySelectorAll("h1");
titreh1.forEach(element =>{
    element.addEventListener('click', changeColorTitreH1);
});

titreh2 = document.querySelectorAll("h2");
titreh2.forEach(element =>{
    element.addEventListener('click', changeColorTitreH2);
});

titreh3 = document.querySelectorAll("h3");
titreh3.forEach(element =>{
    element.addEventListener('click', changeColorTitreH3);
});

// function changeColorTitre(event) { 
//     textClique = event.target;
//      if (textClique.style.color == "") {
//         textClique.style.color = "#00FF00";
//     }else if (textClique.style.color == "rgb(0, 255, 0)") {
//         textClique.style.color = "#FF8C00";
//     }else{
//         textClique.style.color = "";
//     }
// };

function changeColorTitreH1(event) { 
    textClique = event.target;
     if (textClique.style.color == "") {
        titreh1.forEach(element =>{
            element.style.color = "#00FF00";
        });
    }else if (textClique.style.color == "rgb(0, 255, 0)") {
        titreh1.forEach(element =>{
            element.style.color = "#FF8C00";
        });
    }else{
        titreh1.forEach(element =>{
            element.style.color = "";
        });
    }
};

function changeColorTitreH2(event) { 
    textClique = event.target;
     if (textClique.style.color == "") {
        titreh2.forEach(element =>{
            element.style.color = "#00FF00";
        });
    }else if (textClique.style.color == "rgb(0, 255, 0)") {
        titreh2.forEach(element =>{
            element.style.color = "#FF8C00";
        });
    }else{
        titreh2.forEach(element =>{
            element.style.color = "";
        });
    }
};

function changeColorTitreH3(event) { 
    textClique = event.target;
     if (textClique.style.color == "") {
        titreh3.forEach(element =>{
            element.style.color = "#00FF00";
        });
    }else if (textClique.style.color == "rgb(0, 255, 0)") {
        titreh3.forEach(element =>{
            element.style.color = "#FF8C00";
        });
    }else{
        titreh3.forEach(element =>{
            element.style.color = "";
        });
    }
};