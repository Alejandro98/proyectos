function validar() {
    var cedula, nombre, apellidos, correo, celular, profesion, rol, expresion;
    cedula = document.getElementById("txtDoc").value;
    nombre = document.getElementById("txtName").value;
    apellidos = document.getElementById("txtLastname").value;
    correo = document.getElementById("txtEmail").value;
    celular = document.getElementById("txtCellphone").value;
    profesion = document.getElementById("ddlProfession").selectedIndex;
    rol = document.getElementById("ddlRole").selectedIndex;

    if (cedula === "" || nombre === "" || apellidos === "" || correo === "" ||
        celular === "" || profesion === 0 || rol === 0) {
        alertify.alert("Formulario incompleto", "Debe rellenar todos los campos");
        return false;
    }
    else if (cedula.length < 8 || cedula.length > 10 || cedula.length === 9) {
        alertify.alert("Cédula inválida", "Una cédula debe contener 8 o 10 digitos");
        return false;
    }
    else if (/^\d*$/.test(cedula) === false) {
        alertify.alert("La cédula no es numérica", "Una cédula no debe contener letras o caracteres especiales");
        return false;
    }
    else if (nombre.length > 40) {
        alertify.alert("Nombre inválido", "El nombre debe tener como máximo 40 caracteres");
        return false;
    }
    else if (/^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$/.test(nombre) === false) {
        alertify.alert("Nombre inválido", "Un nombre no debe contener números o caracteres especiales");
        return false;
    }
    else if (apellidos.length > 40) {
        alertify.alert("Apellido inválido", "Los apellidos no deben exceder los 40 caracteres");
        return false;
    }
    else if (/^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$/.test(apellidos) === false) {
        alertify.alert("Apellido inválido", "Un apellido no debe contener números o caracteres especiales");
        return false;
    }
    else if (/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.([a-zA-Z]{2,4})+$/.test(correo) === false) {
        alertify.alert("Correo inválido", "Un correo debe ser de la siguiente forma: ejemplo@empresa.dominio");
        return false;
    }
    else if (correo.length > 60) {
        alertify.alert("El correo excede el límite de caracteres", "El correo no debe exceder los 60 caracteres");
        return false;
    }
    else if (celular.length > 10) {
        alertify.alert("El celular excede el límite de caracteres", "Un celular no debe exceder los 10 caracteres");
        return false;
    }
    else if (celular.length < 10) {
        alertify.alert("El celular no cumple el mínimo de caracteres", "Un celular no debe tener menos de 10 caracteres");
        return false;
    }
    else if (/^\d*$/.test(celular) === false) {
        alertify.alert("El celular no es numérico", "Un celular no debe contener letras o caracteres especiales");
        return false;
    }
    else {
        alertify.alert("Correcto");
        return true;
    }
}

function mensajeConfirmacion() {
    alertify.confirm('Confirm Message', function () { alertify.success('Ok') }, function () { alertify.error('Cancel') });
    return false;
}


function sesion() {
    var usuario = document.getElementById("txtUser").value;
    var clave = document.getElementById("txtPassword").value;

    if (usuario === "") {
        alertify.alert("Debe llenar el campo usuario");
        return false;
    }
    else if (clave === "") {
        alertify.alert("Debe llenar el campo contraseña");
        return false;
    }
    else if (usuario.length < 8 || usuario.length > 10 || usuario.length === 9) {
        alertify.alert("Cédula inválida", "Una cédula debe contener 8 o 10 digitos");
        return false;
    }
    else if (/^\d*$/.test(usuario) === false) {
        alertify.alert("La cédula no es numérica", "Una cédula no debe contener letras o caracteres especiales");
        return false;
    }
    else {
        return true;
    }
}

function validarTarea() {
    var codigo, descripcion, duracion, fecha;
    codigo = document.getElementById("txtCode").value;
    descripcion = document.getElementById("txtDescription").value;
    duracion = document.getElementById("txtDuration").value;
    fecha = document.getElementById("txtDate").value;
    if (codigo === "" || descripcion === "" || duracion === "" || fecha === "") {
        alertify.alert("Formulario incompleto", "Debe rellenar todos los campos");
        return false;
    }
    else if (codigo.length > 3) {
        alertify.alert("Código inválido", "El código excede el máximo de registros permitidos");
        return false;
    }
    else if (/^\d*$/.test(codigo) === false) {
        alertify.alert("El código no es numérica", "Un código no debe contener letras o caracteres especiales");
        return false;
    }
    else if (codigo < 0) {
        alertify.alert("Número entero negativo", "Un código no debe ser un número entero negativo");
        return false;
    }
    else if (descripcion.length > 100) {
        alertify.alert("La descripción excede el máximo de caracteres permitidos", "La descripción no debe exceder los 100 caracteres");
        return false;
    }
    else if (/^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$/.test(descripcion) === false) {
        alertify.alert("Descripción inválida", "Una descripción no debe contener números o caracteres especiales");
        return false;
    }
    else if (/^\d*$/.test(duracion) === false) {
        alertify.alert("El código no es numérica", "Un código no debe contener letras o caracteres especiales");
        return false;
    }
    else if (duracion < 0) {
        alertify.alert("Número entero negativo", "La duración debe ser un número entero negativo");
        return false;
    }
    else if (duracion > 31) {
        alertify.alert("La tarea no debe durar tanto tiempo", "Una tarea debería entregarse máximo con un mes de plazo");
        return false;
    }
    else {
        return true;
    }
}