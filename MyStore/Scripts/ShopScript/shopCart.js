$(document).ready(function () {
    let listCardJson = localStorage.getItem("listProductCard");
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

    let listCardOBJ = JSON.parse(localStorage.getItem("listProductCard"));
    
    let ListDetail = [];

    for (const item of listCardOBJ) {
        let Detail ={

            ProductID: item.ID,
            Quantity: parseInt(item.quantity),
        }
        ListDetail.push(Detail);
    }


    dataOrder = {
        CustomerName: $("#or-CustomerName").val(),
        CustomerAddress: $("#or-CustomerAddress").val(),
        CustomerPhone: $("#or-CustomerPhone").val(),
        CustomerMail: $("#or-CustomerMail").val(),
        OrderDetailModels: ListDetail
    };
    $.ajax({
        type: "POST",
        url: "../Order/Create",
        data: dataOrder,
        dataType: "json",
        success: function () {
            localStorage.removeItem("listProductCard")
            $(".container-content").html(`
                <p>
                    Đặt hàng thành công. 
                    Đơn hàng của bạn sẽ được giao đến bạn trong 1 tuần. Vui lòng đợi... <br>
                    Cảm ơn bạn đã mua hàng tại MyShop.
                </p>
            `);
        }
    });
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

$(document).ready(function() {

    //Khi bàn phím được nhấn và thả ra thì sẽ chạy phương thức này
    $("#senddata").validate({
        rules: {
            CustomerName: {
                required: true,
                minlength: 10  
            },
            CustomerAddress: {
                required: true,
                minlength: 10
            }
        },
        messages: {
            CustomerName: {                
                required: "Vui lòng nhập họ tên",
                minlength: "Họ tên phải nhiều hơn 10 kí tự"
            },
            CustomerAddress: {
                required: "Vui lòng nhập địa chỉ",
                minlength: "Địa chỉ phải nhiều hơn 10 kí tự"
            }
        }
    });
});