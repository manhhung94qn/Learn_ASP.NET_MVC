var inputNameProduct = $("#inputNameProduct");
var inputPriceProduct = $("#inputPriceProduct");
var $alertNameProduct = $(".alert-NameProduct");



var touchNameProdcut = false;
var regexNumber = new RegExp("[0-9]");

var statusSubmitCreatProduct = false;

function checkValidInputNameProdcut(){
    touchNameProdcut = true;
    if(inputNameProduct.val()){
        return true;
    }
    return false;
}

function checkValidInputPriceProdcut(){
    if( !isNaN(inputPriceProduct.val()) && inputPriceProduct.val().length >0 ){
        return true;
    }
    return false;
}

$(document).on("click change keyup","#inputNameProduct" ,
    function (){
        checkValidInputNameProdcut();
        console.log(touchNameProdcut)
    }
)