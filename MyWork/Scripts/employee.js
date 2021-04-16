$(document).ready(function () {
    EmployeeList();
});


function Insertemployee() {
    var employeeobj = {
        Name: $("#Name").val(),
        Age: $("#Age").val(),
        Contact_no: $("#Contact_no").val(),
        Address: $("#Address").val(),
        Salary: $("#Salary").val(),
        Email_id: $("#Email_id").val()

    }
    $.ajax({

        url: "/Home/InsertEmployee",
        type: "POST",
        data: employeeobj,
        success: function (result) {
            alert(result);
            alert("data is successfully pass");
        },
        error: function (result) {
            alert("Error in inserting data");
        }
    });
}
//data inheriate and update from table for customers
function EmployeeList() {   
    $.ajax({
        url: "/Home/GetEmployee",
        type: "GET",
        dataType: "Json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Age + '</td>';
                html += '<td>' + item.Contact_no + '</td>';
                html += '<td>' + item.Address + '</td>';
                html += '<td>' + item.Salary + '</td>';
                html += '<td>' + item.Email_id + '</td>';
                html += '<td><button type="button"  class="btn btn-primary" onclick="DeleteEmployee(' + item.Id + ')">Delete</button</td>';
                html += '<td><button type="button" class="btn btn-info"  onclick="Edit(' + item.Id + ');">Edit</button></td>';
                html += '</tr>';
            });
            $(".employee").html(html);
        }
    })
}
function DeleteEmployee(Id) {
    $.ajax({
        url: "/Home/DeleteEmployee?Id=" + Id,
        type: "POST",
        success: function (result) {
            alert(result);
            alert("data is successfully deleted");
        },
        error: function (result) {
            alert("Error Occur in deleting data");
        }
    });
}
function Edit(Id) { 
    $.ajax({
        url: "/Home/SelectEmployee?Id=" + Id,
        type: "GET",
        dataType: "Json",
        success: function (result) {
            $("#Id").val(result.Id),
            $("#Name").val(result.Name),
                $("#Age").val(result.Age),
                $("#Contact_no").val(result.Contact_no),
                $("#Address").val(result.Address),
                $("#Salary").val(result.Salary),
                $("#Email_id").val(result.Email_id)
        }
    });
}
function Update() {
    var employeeobj = {
        Id: $("#Id").val(),
        Name: $("#Name").val(),
        Age: $("#Age").val(),
        Contact_no: $("#Contact_no").val(),
        Address: $("#Address").val(),
        Salary: $("#Salary").val(),
        Email_id: $("#Email_id").val()
    }
    $.ajax({
        url: "/Home/Update",
       
        type: "POST",
        data: employeeobj,
        success: function (result) {
            alert("The data is upadted successfully");
        },
        error: function (result) {
            alert("The error is occuring on updating time");
        }
    });
}
