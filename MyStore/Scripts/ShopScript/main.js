$(document).ready(function(){

    function addProductToLCST(tele){
        var listCart = JSON.parse(localStorage.getItem("listCart"));
        if(listCart){
            alert("hihi")
        } else {
            alert("hoho")
        }


    }

    $(".btn-buynow").click( function($event){
        console.log($(this));
        let nodeParent  = $(this).parentsUntil($('.parent-node-item').parent()) ;
        console.log(nodeParent)
    })

})




