let urlCentral = "https://localhost:44306/api/Estado";
let row;
//Función obtener respuesta del api
var Obtener = () => {
    fetch(urlCentral)
        .then(response => response.json())
        .then(function (data) {
            document.getElementById("tblEstado").innerHTML = "";
            data.map(function (item) {
                var tabla = document.getElementById("tblEstado");
                var tr = document.createElement("tr");
                var colId = document.createElement("th");
                var colestado = document.createElement("th");
                var actualizar = document.createElement("th");
                var eliminar = document.createElement("th");
                colId.innerHTML = item.id;
                colestado.innerHTML = item.nombre;
                //Creación de los botones dinámicos
                actualizar.innerHTML += '<input type="button" value ="' + "Actualizar" + ' "class="btn btn-success editar edit-modal btn btn-warning botonEditar" data-target= "#imodal" data-toggle="modal" onclick="CargaId()">';
                eliminar.innerHTML += '<input type="button" value ="' + "Borrar" + ' "class="btn btn-danger editar edit-modal botonEliminar"  data-target= "#eliminar" data-toggle="modal" onclick="CargaId()">';
                tabla.appendChild(tr);
                tr.appendChild(colId).style.display = 'none';
                tr.appendChild(colestado).className = "text-center";
                tr.appendChild(actualizar).className = "text-center";
                tr.appendChild(eliminar).className = "text-center";
            });
        })
        .catch(err => console.log(err));
}
//Función agregar del api
const Agregar = async () => {

    let estadoAgrega = document.getElementById("txtEstadoA").value;
    let _data = {
        nombre: `${estadoAgrega}`,
    };

    let response = await fetch(urlCentral, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(_data)
    }).then(() => {
        window.location.reload();
    });

    let result = await response.json();
    alert(result.message);
}
//Función modificar del api
const Modificar = async () => {

    let id1 = row;
    let estadoModifica = document.getElementById("txtEstado").value;
    let _data = {
        id: `${id1}`,
        nombre: `${estadoModifica}`,

    };
    let response = await fetch(urlCentral, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(_data)
    }).then(() => {
        window.location.reload();
    });

    let result = await response.json();
    alert(result.message);
}
//Función eliminar del api
const Eliminar = async () => {

    var url1 = new URL(urlCentral),
        params = { id: row1 }
    Object.keys(params).forEach(key => url1.searchParams.append(key, params[key]))
    fetch(url1);

    let response = await fetch(url1, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        }
    }).then(() => {
        window.location.reload();
    });

    let result = await response.json();
    alert(result.message);
}

var CargaId = () => {
    //Obtención del id para la respuesta json
    $(document).on('click', '.botonEditar', function (e) {
        row = $(this).parent().parent().children().first().text();
        console.log(row);
    });
    $(document).on('click', '.botonEliminar', function (e) {
        row1 = $(this).parent().parent().children().first().text();
        console.log(row);
    });

    CargaTexto();
}
//Función para cargar el texto del campo a modificar en los imput de texto
var CargaTexto = () => {
    $(document).on('click', '.botonEditar', function (e) {
        nom = $(this).parents('tr').children().eq(1).text();
        document.getElementById("txtEstado").value = `${nom}`;
    });
}
var LimpiaTexto = () => {
    document.getElementById("txtEstadoA").value = "";
}