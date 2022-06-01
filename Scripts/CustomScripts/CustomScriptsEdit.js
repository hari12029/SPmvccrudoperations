    $(document).ready(function () {
        $('#form-employee').on('submit', function (e) {
            e.preventDefault();


            if (!$('#txt-employee-name').val()) {
                alert('Employee name is not defined!')
            }
            else if (!$('#txt-employee-salary').val()) {
                alert('Employee salary is not defined!')
            }
            else if (!$('#txt-employee-city').val()) {
                alert('Employee city is not defined!')
            }
            else {
                $.ajax({
                    url: "/Employee/Edit",
                    method: "POST",
                    data: { Employeeid: $('#Employeeid').val(), EmployeeName: $('#txt-employee-name').val(), EmployeeSalary: $('#txt-employee-salary').val(), EmployeeCity: $('#txt-employee-city').val() },
                    success: function (result) {
                        alert("Employee Updated successfully!");
                        location.href="/Employee/Index"
                    }
                });
            }

        })
    })
