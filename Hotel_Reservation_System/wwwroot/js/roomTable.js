$(document).ready(function () {
    $('#roomTable').DataTable({
        "ajax":{
            "url": "/Rooms/GetAll"
        },
        "columns":[
            { "data": "roomName", "width": "15%" },
            { "data": "roomDescription", "width": "15%" },
            { "data": "roomCategoryId", "width": "15%" },
            { "data": "cost", "width": "15%" },
            { "data": "status", "width": "15%" }
        ]
    });
});