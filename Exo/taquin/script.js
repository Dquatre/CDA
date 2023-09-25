nbCoup = 0
casePlein = document.querySelectorAll(".plein")
tab = [1,2,3,4,5,6,7,8]
tab = tab.sort(() => Math.random() - 0.5)
let i = 0
casePlein.forEach(element => {
    element.innerHTML = '<img src="img/'+tab[i]+'.png" value="'+(i+1)+'">'
    // element.innerHTML = tab[i]
    element.addEventListener("click",moveCase)
    i++
});


function moveCase(e){
    caseCliquee = e.target.parentNode
    caseVide = document.querySelector(".vide") 
    if (caseCliquee.id == caseVide.id-1 && caseVide.id!=4 &&caseVide.id!=7||caseCliquee.id-1 == caseVide.id && caseVide.id!=3 &&caseVide.id!=6||caseCliquee.id == caseVide.id-3||caseCliquee.id-3 == caseVide.id) {
        nbCoup++
        document.querySelector("#nbCoup").innerHTML = "NOMBRE DE COUPS : "+nbCoup
        caseVide.setAttribute('class', 'case plein')
        caseCliquee.setAttribute('class', 'case vide')
        caseVide.innerHTML = caseCliquee.innerHTML
        caseCliquee.innerHTML = ""
        caseVide.addEventListener("click",moveCase)
        caseCliquee.removeEventListener("click",moveCase)
        if (checkWin()) {
            caseVide.innerHTML = '<img src="img/9.png" >'
        }
    }
    
}

function checkWin() {
    casePlein.forEach(element => {
        if (element.getAttribut("") != element.id) {
            return false
        }
    });   
    return true
}