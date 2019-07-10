$(".btn-addToCart").click(function(){
    let id = $(this).data("productid");
    // debugger

    $.ajax({
        url : "../Product/SendProductToClient",
        data : { id: id },        
        type: "POST",
        datatype: "json",
        success: function(res){
            console.log(res);
            res = Object.assign(res,{quantity: "1"})
            if(localStorage.getItem("listProductCard")){
                let listProductCard = JSON.parse( localStorage.getItem("listProductCard") ) ;
                console.log(res);

                let indexProduct = listProductCard.findIndex(item=>item.ID == res.ID);
                console.log((indexProduct)); 
                
                if(indexProduct>-1){
                    listProductCard[indexProduct].quantity++;
                } else {
                    listProductCard.push( res );
                }

                localStorage.removeItem("listProductCard");
                localStorage.setItem("listProductCard", JSON.stringify(listProductCard));       
            } else {
                let listProductCard = [];
                console.log(res)
                listProductCard.push( res );
                localStorage.setItem("listProductCard", JSON.stringify(listProductCard) ) 
            }
        }
    });


});