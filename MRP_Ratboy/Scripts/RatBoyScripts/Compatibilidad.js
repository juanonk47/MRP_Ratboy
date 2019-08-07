const $divContainerComponent = $('#content-component-div');

var disipadoresArray = [];
var almacenamientoArray = [];
var fuentePoderArray = [];
var memoriaRamArray = [];
var procesadorArray = [];
var tarjetaVideoArray = [];

var objTarjetaMadre = [];
var objDisipador = [];
var objAlmacenamiento = [];
var objFuentePoder = [];
var objMemoriaRam = [];
var objProcesador = [];
var objTarjetaVideo = [];

var ensamble = [];

var watageSumativa = [];

$(document).ready(function () {
    getPlacaMadre();
});

function getPlacaMadre() {
    $.ajax({
        url: 'https://localhost:44327/Compatibilidad/mostrarPlacasMadre',
        success: function (respuesta) {
            for (var i = 0; i < respuesta.length; i++) {
                var cardComponent = "<div class='card' style='width: 16rem; height: 18rem; margin: 5px; margin-left: 60px;'>" +
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
            objTarjetaMadre = { "idPlacaMadre": $(this).attr('id') }
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
            disipadoresArray.push(respuesta.Disipadores);
            almacenamientoArray.push(respuesta.almacenamientos);
            fuentePoderArray.push(respuesta.fuentePoder);
            memoriaRamArray.push(respuesta.memoriaRAMs);
            procesadorArray.push(respuesta.procesadors);
            tarjetaVideoArray.push(respuesta.tarjetaVideos);

            // Pintamos los procesadores

        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
}