$(document).ready(function () {
    loadEmployees();

    $('#employeeForm').on('submit', function (e) {
        e.preventDefault();
        saveEmployee();
    });

    $(document).on('click', '.edit-employee', function () {
        const id = $(this).data('id');
        loadEmployee(id);
    });

    $(document).on('click', '.delete-employee', function () {
        const id = $(this).data('id');
        deleteEmployee(id);
    });
});

// Load all employees
function loadEmployees() {
    $.getJSON('/api/employees', function (employees) {
        const employeeList = $('#employeeList');
        employeeList.empty();
        $.each(employees, function (index, employee) {
            const item = $(`
                <li>
                    ${employee.firstName} ${employee.lastName} - ${employee.position} 
                    (<a href="mailto:${employee.email}">${employee.email}</a>)
                    <button class="edit-employee" data-id="${employee.id}">Uredi</button>
                    <button class="delete-employee" data-id="${employee.id}">Obriši</button>
                </li>
            `);
            employeeList.append(item);
        });
    }).fail(function () {
        alert('Greška prilikom učitavanja zaposlenika.');
    });
}

// Load a specific employee for editing
function loadEmployee(id) {
    $.getJSON(`/api/employees/${id}`, function (employee) {
        $('#employeeForm')[0].reset();
        $('#employeeId').val(employee.id); // Hidden field to store ID if editing
        $('#firstName').val(employee.firstName);
        $('#lastName').val(employee.lastName);
        $('#email').val(employee.email);
        $('#position').val(employee.position);
        $('#salary').val(employee.salary);
        $('#dateOfBirth').val(new Date(employee.dateOfBirth).toISOString().split('T')[0]);
        $('#hireDate').val(new Date(employee.hireDate).toISOString().split('T')[0]);
    }).fail(function () {
        alert('Greška prilikom učitavanja zaposlenika.');
    });
}

// Save (create or update) an employee
function saveEmployee() {
    const employeeId = $('#employeeId').val();
    const employee = {
        firstName: $('#firstName').val(),
        lastName: $('#lastName').val(),
        email: $('#email').val(),
        position: $('#position').val(),
        dateOfBirth: $('#dateOfBirth').val(),
        hireDate: $('#hireDate').val(),
        salary: $('#salary').val()
    };

    const requestType = employeeId ? 'PUT' : 'POST';
    const requestUrl = employeeId ? `/api/employees/${employeeId}` : '/api/employees';

    $.ajax({
        url: requestUrl,
        type: requestType,
        contentType: 'application/json',
        data: JSON.stringify(employee),
        success: function () {
            alert('Zaposlenik je uspješno spremljen.');
            $('#employeeForm')[0].reset();
            loadEmployees();
        },
        error: function () {
            alert('Greška prilikom spremanja zaposlenika.');
        }
    });
}

// Delete an employee
function deleteEmployee(id) {
    $.ajax({
        url: `/api/employees/${id}`,
        type: 'DELETE',
        success: function () {
            alert('Zaposlenik je uspješno obrisan.');
            loadEmployees();
        },
        error: function () {
            alert('Greška prilikom brisanja zaposlenika.');
        }
    });
}
