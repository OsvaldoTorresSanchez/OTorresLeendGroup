﻿$(document).ready(function () {
    loadData();
});
 
function loadData() {
    $.ajax({
        url: "/Empleado/Get",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.IdEmpleado + '</td>';
                html += '<td>' + item.NumeroNomina + '</td>';
                html += '<td>' + item.Nombre + '</td>';
                html += '<td>' + item.ApellidoPaterno + '</td>';
                html += '<td>' + item.ApellidoMaterno + '</td>';
                html += '<td>' + item.IdEstado + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.EmployeeID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.EmployeeID + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}  