function validarGuardar() {
    var documento = document.getElementById('txtDoc').value;
    var nombre = document.getElementById('txtName').value;
    var apellidos = document.getElementById('txtLastname').value;
    var correo = document.getElementById('txtEmail').value;
    var celular = document.getElementById('txtCellphone').value;

    if (documento.length > 0 || nombre.length === 0 || apellidos.length === 0 || correo.length === 0 || celular.length === 0) {
        alert('Rellene los campos obligatorios');
        return false;
    }
    else {
        alert('Usuario guardado correctamente');
        return true;
    }
}

function validarBuscar() {
    var documento = document.getElementById('txtDoc').value;

    if (documento.length !== 10 && documento.length !== 8) {
        alert('Debe ingresar una cédula válida');
        return false;
    }
    else {
        alert('Usuario encontrado');
        return true;
    }
}

function validarModificar() {
    var documento = document.getElementById('txtDoc').value;
    var nombre = document.getElementById('txtName').value;
    var apellidos = document.getElementById('txtLastname').value;
    var correo = document.getElementById('txtEmail').value;
    var celular = document.getElementById('txtCellphone').value;
    var profesion = document.getElementById('ddlProfession').value;
    var rol = document.getElementById('ddlRole').value;


    if (documento.length === 0 || nombre.length === 0 || apellidos.length === 0 || correo.length === 0 || celular.length === 0) {
        alert('Rellene los campos obligatorios');
        return false;
    }
    else {
        alert('Usuario modificado correctamente');
        return true;
    }
}

function validarEliminar() {
    var documento = document.getElementById('txtDoc').value;

    if (documento.length !== 10 && documento.length !== 10) {
        alert('Debe ingresar una cédula válida');
        return false;
    }
    else {
        alert('Usuario eliminado correctamente');
        return true;
    }
}

function validarIngreso() {
    var usuario = document.getElementById('txtUser').value;
    var contrasena = document.getElementById('txtPassword').value; 

    if (usuario === 'alejandro' && contrasena === 'Alejo@98') {
        alert('Bienvenido');
        return true;
    }
    else {
        alert('Usuario y/o contraseña inválidos');
        return false;
    }
}