

var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                        <a href="/BooksList/Edit?id=${data}" class="btn btn-success btn-sm text-white" style="cursor:pointer;width:70px;" onclick="Delete('/api/Book?id='+${data}">Edit</a>

                        &nbsp;
                        <a class='btn btn-danger text-white btn-sm' style='cursor:pointer; width:70px;'
                            onclick=Delete('/api/book?id='+${data})>
                            Delete
                        </a>
                        </div>`;
                }, "width": "40%",
                
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%",
        "responsive": "true",
        "lengthMenu": "1235",
        "bInfo": false,
        "pageLength": 5,
    });
}

function Delete(url) {
    swal({
        title: `Are you sure? `,
        text: `Once deleted, you will not be able to recover `,
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}