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

//Tìm hiểu jq validtion 
// Làm sao để cấu hình validation tự đọng bắt ở client

class Validate {
    ElementInput;
    ElementError;
    TouchedInput = false;
    DirtyInput = false;
    constructor(_selectElementInput, _selectElementError){
        this.ElementInput = $(_selectElementInput);
        this.ElementError = $(_selectElementError);
    };
    touchedInput(){
        this.TouchedInput = true;
    }
    dirtyInput(){
        this.DirtyInput = true;
    };
    checkValidate = false;
    showHideError(){
        if(!this.checkValidate && this.DirtyInput && this.TouchedInput){
            this.ElementError.show().css("color", "red")
        } else {
            this.ElementError.hide();
        }
    }
}

// //////////////////
// var V_ProductName = new Validate("#inputNameProduct",".alert-NameProduct");

// $(document).on("keypress", V_ProductName.ElementInput, V_ProductName.touchedInput() );

// $(document).on( "change keyup" , V_ProductName.ElementInput , function(){
    
//     V_ProductName.dirtyInput();
//     if(V_ProductName.ElementInput.val()){
//         V_ProductName.checkValidate = true;
//     } else {
//         V_ProductName.checkValidate = false;
//     }
//     console.log(V_ProductName.checkValidate)
//     // V_ProductName.showHideError();
//     // $btnCreateProdcut.attr("disabled",! V_ProductName.checkValidate && V_PriceName.checkValidate );
// })
// ///////

// var V_PriceName =  new Validate("#inputPriceProduct", ".alert-PriceProduct")


// $(document).ready(function(){
//     console.log(V_ProductName.ElementInput);
//     console.log(V_ProductName.checkValidate, V_ProductName.TouchedInput)
// })






