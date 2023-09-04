
const paragraph = document.querySelectorAll(".para");

paragraph.forEach(function (para) {
    para.addEventListener('click', changeColor(para));
});

function changeColor(para) { 
     if (para.style.color == "") {
        para.style.color = "#00FF00";
    }else{
        para.style.color = "";
    }
};

