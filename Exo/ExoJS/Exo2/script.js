


document.querySelector("l1").addEventListener('change', function() {
    var quatite = document.querySelector("q1").value ;
    var prixUnit = document.querySelector("pu1").value;
    var total = quatite*prixUnit;
    document.querySelector("p1").value = total;
});