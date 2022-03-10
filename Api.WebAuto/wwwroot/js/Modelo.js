let urlCentral = "https://localhost:44306/api/Modelos";
let row;
//Función obtener respuesta del api
var Obtener = () => {
    fetch(urlCentral)
        .then(response => response.json())
        .then(function (data) {
            document.getElementById("tblModelo").innerHTML = "";
            data.map(function (item) {
                var tabla = document.getElementById("tblModelo");
                var tr = document.createElement("tr");
                var colId = document.createElement("th");
                var ColIdMarca = document.createElement("th");
                var colMarca = document.createElement("th");
                var colModelo = document.createElement("th");
                var actualizar = document.createElement("th");
                var eliminar = document.createElement("th");
                colId.innerHTML = item.id;
                ColIdMarca.innerHTML = item.id_Marca;
                colMarca.innerHTML = item.marca;
                colModelo.innerHTML = item.nombre;
                //Creación de los botones dinámicos
                actualizar.innerHTML += '<input type="button" value ="' + "Actualizar" + ' "class="btn btn-success editar edit-modal btn btn-warning botonEditar" data-target= "#imodal" data-toggle="modal" onclick="CargaCombos()">';
                eliminar.innerHTML += '<input type="button" value ="' + "Borrar" + ' "class="btn btn-danger editar edit-modal botonEliminar"  data-target= "#eliminar" data-toggle="modal" onclick="CargaCombos()">';
                tabla.appendChild(tr);
                tr.appendChild(colId).style.display = 'none';
                tr.appendChild(ColIdMarca).style.display = 'none';
                tr.appendChild(colMarca).className ="text-center";
                tr.appendChild(colModelo).className = "text-center";
                tr.appendChild(actualizar).className = "text-center";
                tr.appendChild(eliminar).className = "text-center";
            });
        })
        .catch(err => console.log(err));
}
//Función agregar del api
const Agregar = async () => {

    let marcaAgrega = document.getElementById("cmbMarcaA").value;
    let modeloAgrega = document.getElementById("txtModeloA").value;
    let _data = {
        marca: `${marcaAgrega}`,
        nombre: `${modeloAgrega}`,
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
    let marc = mod;
    let marcaModifica = document.getElementById("cmbMarca").value;
    let modeloModifica = document.getElementById("txtModelo").value;
    let _data = {
        id: `${id1}`,
        marca: `${marcaModifica}`,
        nombre: `${modeloModifica}`,
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
//Llenado de los select para los combos del modal para modificar
var CargaCombos = () => {
    //Obtención del id para la respuesta json
    $(document).on('click', '.botonEditar', function (e) {
        row = $(this).parents('tr').children().eq(0).text();
        mod = $(this).parents('tr').children().eq(1).text();
        console.log(row);
        console.log(mod);
    });
    $(document).on('click', '.botonEliminar', function (e) {
        row1 = $(this).parents('tr').children().eq(0).text();
        console.log(row);
    });

    fetch("https://localhost:44306/api/Marcas")
        .then(response => response.json())
        .then(function (data) {
            document.getElementById("cmbMarca").innerHTML = "";
            var cmbModelo = document.getElementById("cmbMarca");
            data.map(function (item) {

                var option = document.createElement("option");

                option.value = item.id;
                option.text = item.nombre;

                cmbModelo.appendChild(option);
                $('select').val(`${mod}`);

            });
        })
        .catch(err => console.log(err));
    const select = document.querySelector('select');
    select.value = $(this).parents('tr').children().eq(1).text();
    CargaTexto();
};
//Llenado de los select para los combos del modal para agregar
var CargaCombosAgrega = () => {
    fetch("https://localhost:44306/api/Marcas")
        .then(response => response.json())
        .then(function (data) {
            document.getElementById("cmbMarcaA").innerHTML = "";
            var cmbModelo = document.getElementById("cmbMarcaA");

            data.map(function (item) {
                var option = document.createElement("option");
                option.value = item.id;
                option.text = item.nombre;
                cmbModelo.appendChild(option);
            });
        })
        .catch(err => console.log(err));
};
//Función para cargar el texto del campo a modificar en los imput de texto
var CargaTexto = () => {
    $(document).on('click', '.botonEditar', function (e) {
        marcaM = $(this).parents('tr').children().eq(2).text();
        modeloM = $(this).parents('tr').children().eq(3).text();

        document.getElementById("txtModelo").value = `${modeloM}`;
        /*document.getElementById("cmbMarca").value = `${marcaM}`;*/
    });
}