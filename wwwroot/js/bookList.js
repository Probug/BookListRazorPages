var dataTable;

$(document).ready(function () {
loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Book",
            "type": "GET",
            "datatype" : "json"
        },
        "columns": [
            {"data":"name","width":"25%"},
            {"data":"author","width":"25%"},
            {"data":"isbn","width":"25%"},
            {
                "data" : "id",
                "render" : function (data) {
                    return `<div class="text-centre">
                    <a href ="/BookList/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                    Edit
                    </a>
                    &nbsp
                    <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'>
                    Delete
                    </a>
                    </div>`;
                }
            }
        ],
        "language": {
            "emptyTable" : "no data found"
        },
        "width":"40%"
    });
}