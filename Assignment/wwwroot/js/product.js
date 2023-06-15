
$(document).ready(function () {
    loadTable();
})

function loadTable() {
    dataTable = $('#myTable').DataTable({
        'ajax': {url: '/Admin/Product/GetAll'},
    "columns":[
        { data: 'productName', "width": "20%" },
        { data: 'modelYear', "width": "10%" },
        { data: 'listPrice', "width": "10%" },
        { data: 'imageUrl', "width": "20%" },
        { data: 'brand.brandName', "width": "10%" },
        { data: 'category.categoryName', "width": "12%" },
        {
            data: 'productId',
            "render": function (data) {
                return 
                `<div class="w-75 btn-group">
                    <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-primary mx-2" ><i class="fa-solid fa-pen-to-square"></i> </a>
                    <a class="btn btn-danger mx-2" > <i class="fa-solid fa-trash"></i> </a>
                </div>`
            },
            "width": "18%"
        }
    ]
    });
}


