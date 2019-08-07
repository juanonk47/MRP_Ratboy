const $divContainerComponent = $('#content-component-div');

var procesadorArray = [];
var tarjetaVideoArray = [];
var memoriaRamArray = [];
var AlmacenamientoArray = [];

$(document).ready(function () {
    getPlacaMadre();
});

function getPlacaMadre() {
    $.ajax({
        url: 'https://localhost:44327/Compatibilidad/mostrarPlacasMadre',
        success: function (respuesta) {

            for (var i = 0; i < respuesta.length; i++) {
                var cardComponent = "<div class='card' style='width: 25rem; height: 18rem; margin: 5px; margin-left: 30px; float:left; background: #D2D1E8; padding: 10px; border-radius: 5px'>" +
                    "<img class='card-img-top'>" +
                    "<div class='card-body'>" +
                    "<h5 class='card-title' id='nombre'>" + respuesta[i].Nombre + "</h5>" +
                    "<p class='card-text'>" + respuesta[i].Descripcion + "</p>" +
                    "<input type='submit' class='btn btn-primary' id='" + respuesta[i].idPlacaMadre + "' value='Aceptar Componente' onclick='funciona()'/> " +
                    "</div>" +
                    "</div>";
                $("#content-component-div").append(cardComponent);
            }
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
}

function funciona() {
    $(document).ready(function () {
        $('body').on('click', '#content-component-div input', function () {
            mandarId($(this).attr('id'));
            $("#content-component-div").empty();
        })
    });
}

function mandarId(id) {
    $.ajax({
        url: 'https://localhost:44327/Compatibilidad/piezasSoportadas/' + id,
        success: function (respuesta) {
            // Almacenamos los datos en variables
            procesadorArray.push(respuesta.procesadors);
            tarjetaVideoArray.push(respuesta.tarjetaVideos);
            memoriaRamArray.push(respuesta.memoriaRAMs);
            AlmacenamientoArray.push(respuesta.almacenamientos);
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
}