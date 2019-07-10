$(document).ready(function () {
    let listCardJson = localStorage.getItem("listProductCard");
    console.log(listCardJson);
    if (listCardJson) {
        let tbBody = CreateTable(JSON.parse(listCardJson));
        $(".content-order-cart").html(tbBody);
    }

});

$("body").delegate(".btn-deleteProduct", "click", function () {
    let id = $(this).data("productid");
    deleteProduct(id);
})

$("body").delegate(".quantity-product", "change", function () {
    let listCardOBJ = JSON.parse(localStorage.getItem("listProductCard"));
    let id = $(this).data("productid");
    let indexOfProduct = listCardOBJ.findIndex(item => {
        return item.ID == id;
    });
    console.log(indexOfProduct)
    listCardOBJ[indexOfProduct].quantity = $(this).val();
    $(".content-order-cart").html(``).html(CreateTable(listCardOBJ));
    localStorage.removeItem("listProductCard");
    localStorage.setItem("listProductCard", JSON.stringify(listCardOBJ));
});

$("body").delegate(".btn-buy", "click", function (event) {
    event.preventDefault();
    dataOrder = {
        CustomerName: $("#or-CustomerName").val(),
        CustomerAddress: $("#or-CustomerAddress").val(),
        CustomerPhone: $("#or-CustomerPhone").val(),
        CustomerMail: $("#or-CustomerMail").val()
    };
    console.log(dataOrder);
    $.ajax({
        url: "../Order/Create",
        type: "POST",
        async: false,
        data: dataOrder,
        datatype: "json",
        success: function (data) {    
            $(".body-content").css("position", "relative").html(
                `
                    <div 
                        class="w-100 h-100 position-absolute 
                        style="z-index:100;text-align:center; top: 0; right:0"
                    ">
                        <img class="w-100 h-100" src="https://i.redd.it/y1wufcwxgc4z.gif" />
                    </div>
                `
            )        
            let listCardOBJ = JSON.parse(localStorage.getItem("listProductCard"));
            for (const item of listCardOBJ) {
                let orderDetailData = {
                    OrderID: data.ID,
                    ProductID: item.ID,
                    Quantity: item.quantity
                }
                $.ajax({
                    url: "../OrderDetail/Create",
                    data: orderDetailData,
                    async: false,
                    type: "POST",
                    datatype: "JSON",
                    success: function(res){

                    }
                })
            }
            localStorage.removeItem("listProductCard")
            $(".body-content").html(`<h3 class="container">Cảm ơn bạn đã mua hàng tại MyShop. Bạn sẽ sớm nhận được hàng sau 2 ngày.</h3>`)
        }
    })

    // $.ajax({
    //     url : "../Product/SendProductToClient",
    //     data : { id: 1 },        
    //     type: "POST",
    //     datatype: "json",
    //     success: function(res){
    //         console.log(res);}
    // });
})



var CreateTable = (listProductCard) => {
    let content = ``;
    for (const item of listProductCard) {
        content += `
                    <tr>
                        <td> ${item.ProductName} </td>
                        <td> ${item.Price} </td>
                        <td> <input type="number" value = "${item.quantity}" class="quantity-product" data-productid="${item.ID}"/> </td>
                        <td> ${item.Price * item.quantity} </td>
                        <td> 
                            <button type="button" class="btn btn-outline-danger border rounded btn-deleteProduct" data-productid="${item.ID}">Hủy</button>
                        </td>
                    </tr>
                    `
    }
    console.log(listProductCard)
    let toltal = listProductCard.reduce((s, item) => { return s + item.Price * item.quantity }, 0);
    $(".sum-price-order").html(toltal);
    return content;
}

var deleteProduct = (id) => {
    let listCardOBJ = JSON.parse(localStorage.getItem("listProductCard"));
    let indexOfProduct = listCardOBJ.findIndex(item => {
        return item.ID == id;
    });

    listCardOBJ.splice(indexOfProduct, 1);
    $(".content-order-cart").html(``).html(CreateTable(listCardOBJ));
    localStorage.removeItem("listProductCard");
    localStorage.setItem("listProductCard", JSON.stringify(listCardOBJ));
}