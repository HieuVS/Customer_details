$(document).ready(function () {

    dialog = $(".dialog-detail1").dialog({
        autoOpen: false,
        width: 600,
        modal: true,
    });

    loadData();

    initEvens();

})
$(document).ready(function () {
    $("#myInput").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#tbListData tbody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

/**
 * Thực hiện load dữ liệu
 * Author: NVMANH (07/12/2020)
 * */
function loadData() {
    // load dữ liệu:
    // 1. Bước 1: gọi service lấy dữ liệu:
   // debugger;
    $.ajax({
        url: '/api/v1/Employees',
        method: 'GET',
    }).done(function (response) {
        // Gán dữ liệu trả về
        var data = response;
        // Lấy tất cả các cột của bảng
        var columns = $("#tbListData thead th");
        // Với từng đối tượng của data
        $.each(data, function (index, obj) {
            // Tạo ra 1 hàng
            var tr = $("<tr></tr>");
            $.each(columns, function (index, col) {
                // Tạo ra 1 ô
                var td = $("<td></td>");
                // Lấy attribute fieldName của từng cột
                var property = $(this).attr("fieldName");
                // Lấy giá trị tương ứng với thuộc tính
                var value = obj[property];
                // Thêm giá trị vào ô
                td.append(value);
                // Thêm giá trị vào hàng
                tr.append(td);
            })
            // Thêm hàng vào bảng
            $("#tbListData tbody").append(tr);
        })
    }).fail(function (response) {

    })

}

/**
 * Thực hiện gán các sự kiện
 * Author: NVMANH (07/12/2020)
 * */
function initEvens() {
    // Gán các sự kiện:
    $('#btnAdd').click(function () {
        dialog.dialog('open');
        $('#btnSave').show();
        $.ajax({
            url: '/api/v1/Employees',
            method: 'GET'
        })/*.done(res => {
            $("#iEmployeeCode").val(res.data.toString());
        })*/
    })

    $('#btnCancel').click(function () {
        dialog.dialog('close');
    })


    $('#tbListData').on('dblclick', 'tr', function () {
        // load dữ liệu chi tiết:

        // Hiển thị dialog thông tin chi tiết:
        dialog.dialog('open');
    })
    /*//double click table to delete
    $('#tbListData tbody').mousedown(function (event) {
        if (event.which == 3) {
            console.log(this);
            var conf = confirm("Xóa nhân viên " + listId[this.rowIndex - 1]);
        }
    })*/
}

function addEmployee() {
    $("#btnSave").click(function () {
        var employeeCode = $("#iEmployeeCode").val();
        var employeeName = $("#iEmployeeName").val();
        var dob = $("#iDateBirth").val() == '' ? null : $("#iDateBirth").val().toString();
        var gender = parseInt($("#iGender").children("option").filter(":selected").val());
        var identityNumber = $("#iIdentityNumber").val();
        var identityDate = $("#iIdentityDate").val() == '' ? null : $("#iIdentityDate").val().toString();
        var identityPlace = $("#iIdentityPlace").val();
        var email = $("#iEmail").val();
        var phoneNumber = $("#iPhoneNumber").val();
        var jobId = $("#iJob").children("option").filter(":selected").val();
        var departmentId = $("#iDepartment").children("option").filter(":selected").val();
        var personalTaxCode = $("#iPersonalTaxCode").val();
        var salaryTmp = $("#iSalary").val();
        var salary = salaryTmp == "" ? 0 : parseInt(salaryTmp);
        var startedWorkDate = $("#iStartedWorkDate").val() == '' ? null : $("#iStartedWorkDate").val().toString();
        var jobStatus = $("#iJobStatus").val();

        var employee = {
            "employeeCode": employeeCode,
            "employeeName": employeeName,
            "identityNumber": identityNumber,
            "identityDate": identityDate,
            "identityPlace": identityPlace,
            "dateBirth": dob,
            "gender": gender,
            "email": email,
            "phoneNumber": phoneNumber,
            "jobId": jobId,
            "personalTaxCode": personalTaxCode,
            "salary": salary,
            "departmentId": departmentId,
            "jobStatus": jobStatus,
            "startedWorkDate": startedWorkDate,
        }

        $.ajax({
            url: '/api/v1/Employees',
            method: 'POST',
            data: JSON.stringify(employee),
            contentType: 'application/json'
        }).done(function (res) {
            alert(res.messenger);
            $(".m-dialog").hide();
            dialog.dialog('close');

        }).fail(function (res) {
            alert(res.responseJSON.messenger.join('\n'));
        })

    })

}
/**
 * Hàm thực hiện định dạng ngày tháng (ngày/tháng/năm)
 * @param {Number} date ngày truyền vào
 * Author: NVMANH (07/12/2020)
 */
function formatDate(date) {
    var date = new Date(date);
    // lấy ngày:
    var day = date.getDate();

    // lấy tháng:
    var month = date.getMonth() + 1;

    // lấy năm:
    var year = date.getFullYear();
    return day + '/' + month + '/' + year;
}
function formatGender(gender) {
    if (gender == 1) {
        return "Nam";
    }
    else if (gender == 2) {
        return "Nữ";
    }
    return "Khác";
}