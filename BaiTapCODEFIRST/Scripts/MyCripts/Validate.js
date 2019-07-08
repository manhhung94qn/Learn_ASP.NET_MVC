//Js for input product name
var $inputNameProduct = $("#inputNameProduct");
var $alertNameProduct = $(".alert-NameProduct");
var $btnCreateProdcut = $(".btn-createProduct")
$(document).ready(function(){
    $alertNameProduct.hide();
    $alertPriceProduct.hide();
    $btnCreateProdcut.attr("disabled", "true")
})

var touchNameProdcut = false;
var dirtyNameProduct = false;

var statusSubmitCreatProduct = false;

function checkValidInputNameProdcut(){
    touchNameProdcut = true;
    if($inputNameProduct.val()){
        return true;
    }
    return false;
}

$(document).on("keypress", "#inputNameProduct", function(){
    dirtyNameProduct = true;
})

$(document).on("change keyup","#inputNameProduct" ,
    function (){
        if( !checkValidInputNameProdcut() && touchNameProdcut && dirtyNameProduct){
            $alertNameProduct.show().css("color","red");
        } else {
            $alertNameProduct.hide();
        }
        $btnCreateProdcut.attr("disabled",! (checkValidInputPriceProcduct() && checkValidInputNameProdcut()))
    }
)
////////

//Js for input product price

var $inputPriceProduct = $("#inputPriceProduct");
var $alertPriceProduct = $(".alert-PriceProduct");
var touchPriceProdcut = false;
var dirtyPriceProduct = false;
function checkValidInputPriceProcduct(){
    touchPriceProdcut = true;
    if( !isNaN($inputPriceProduct.val()) && $inputPriceProduct.val().length >0 ){
        console.log( !isNaN($inputPriceProduct.val()) );
        return true;        
    }
    return false;
    
}
$(document).on("keypress", "#inputPriceProduct", function(){
    dirtyPriceProduct = true;
})

$(document).on("change keyup","#inputPriceProduct" ,
    function (){
        
        if( !checkValidInputPriceProcduct() && touchPriceProdcut && dirtyPriceProduct){
            $alertPriceProduct.show().css("color","red");
            
        } else {
            $alertPriceProduct.hide();
        }
        
        $btnCreateProdcut.attr("disabled",! (checkValidInputPriceProcduct() && checkValidInputNameProdcut()))
    }
)

///////






