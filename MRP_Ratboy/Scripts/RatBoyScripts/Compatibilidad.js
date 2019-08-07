const $divContainerComponent = $('#content-component-div');

const $checkTarjeta = $('check-tarjetaMadre');
const $checkProcesador = $('check-procesador');
const $checkdisipador = $('check-disipador');
const $checkRam = $('check-ram');
const $checkTarjetaVideo = $('check-tarjetaVideo');
const $checkAlmacenamiento = $('check-almacenamiento');
const $checkGabinete = $('check-gabinete');
const $checkFuentePoder = $('check-fuentePoder');

var disipadoresArray = [];
var almacenamientoArray = [];
var fuentePoderArray = [];
var memoriaRamArray = [];
var procesadorArray = [];
var tarjetaVideoArray = [];

var objTarjetaMadre = []; // 1
var objDisipador = []; // 1
var objAlmacenamiento = [];
var objFuentePoder = [];
var objMemoriaRam = [];
var objProcesador = []; // 1
var objTarjetaVideo = [];

var ensamble = [];

var watageSumativa = 0;

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
            objTarjetaMadre = { "idPlacaMadre": $(this).attr('id') }
            mandarId($(this).attr('id'));
            $("#check-tarjetaMadre").attr('checked', true);
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
            pintarTodas();
        },
        error: function () {
            console.log("No se ha podido obtener la información");
        }
    });
}

function pintarProcesador() {
    try {
        $("#content-component-div").empty();
        for (var i = 0; i < procesadorArray.length; i++) {
            let procesador = procesadorArray[i];
            var cardComponent = "<div class='card' style='width: 25rem; height: 18rem; margin: 5px; margin-left: 30px; float:left; background: #D2D1E8; padding: 10px; border-radius: 5px'>" +
                "<img class='card-img-top'>" +
                "<div class='card-body'>" +
                "<h5 class='card-title' id='nombre'>" + procesador[i].nombre + "</h5>" +
                "<p class='card-text' id='" + procesador[i].watts + "'>Waths: " + procesador[i].watts + "</p>" +
                "<input type='submit' class='btn btn-primary' id='" + procesador[i].idProcesador + "' value='Aceptar Componente' onclick='funciona2()'/> " +
                "</div>" +
                "</div>";
            $("#content-component-div").append(cardComponent);
        }
    } catch (err) {

    }
}

function funciona2() {
    $(document).ready(function () {
        $('body').on('click', '#content-component-div input', function () {
            objProcesador = { "idProcesador": $(this).attr('id') }
            procesadorArray = [];
            $("#check-tarjetaMadre").attr('checked', false);
            $("#check-procesador").attr('checked', true);
            pintarTodas();
            $("#content-component-div").empty();
        });
    });
}

function ptintarDisipador() {
    $("#content-component-div").empty();
    //setTimeout(function () {
        for (var i = 0; i < disipadoresArray.length; i++) {
            let disipador = disipadoresArray[i];
            var cardComponent = "<div class='card' style='width: 25rem; height: 18rem; margin: 5px; margin-left: 30px; float:left; background: #D2D1E8; padding: 10px; border-radius: 5px'>" +
                "<img class='card-img-top'>" +
                "<div class='card-body'>" +
                "<h5 class='card-title' id='nombre'>" + disipador[i].nombre + "</h5>" +
                "<p class='card-text' id='" + disipador[i].watts + "'>Waths: " + disipador[i].watts + "</p>" +
                "<input type='submit' class='btn btn-primary' id='" + disipador[i].idDisipador + "' value='Aceptar Componente' onclick='funciona3()'/> " +
                "</div>" +
                "</div>";
            $("#content-component-div").append(cardComponent);
        }
    //}, 1000);
}

function funciona3() {
    $(document).ready(function () {
        $('body').on('click', '#content-component-div input', function () {
            objDisipador = { "idDisipador": $(this).attr('id') }
            $("#check-procesador").attr('checked', false);
            $("#check-disipador").attr('checked', true);
            disipadoresArray = [];
            $("#content-component-div").empty();
        });
    });
}

function pintarRam() {
    $("#content-component-div").empty();
    var arrayNuevoRam = [];
    arrayNuevoRam = memoriaRamArray[0];
    console.log(arrayNuevoRam);
    for (var i = 0; i < arrayNuevoRam.length; i++) {
        let memoriaRam = arrayNuevoRam[i];
        var cardComponent = "<div class='card' style='width: 25rem; height: 18rem; margin: 5px; margin-left: 30px; float:left; background: #D2D1E8; padding: 10px; border-radius: 5px'>" +
            "<img class='card-img-top'>" +
            "<div class='card-body'>" +
            "<h5 class='card-title' id='nombre'>" + memoriaRam.nombre + "</h5>" +
            "<p class='card-text' id='" + memoriaRam.watts + "'>Waths: " + memoriaRam.watts + "</p>" +
            "<input type='submit' class='btn btn-primary' id='" + memoriaRam.idRAM + "' value='Aceptar Componente' onclick='funciona4()'/> " +
            "</div>" +
            "</div>";
        $("#content-component-div").append(cardComponent);
    }
}

function funciona4() {
    $(document).ready(function () {
        $('body').on('click', '#content-component-div input', function () {
            objMemoriaRam = { "idDisipador": $(this).attr('id') }
            $("#check-disipador").attr('checked', false);
            $("#check-ram").attr('checked', true);
            memoriaRamArray = [];
            $("#content-component-div").empty();
        });
    });
}

function pintarTodas() {
    if ($("#check-tarjetaMadre").is(':checked')) {
        pintarProcesador();
    }

    if ($("#check-procesador").is(':checked')) {
        setTimeout(function () {
            ptintarDisipador();
        }, 1000);
    }

    if ($("#check-disipador").is(':checked')) {
        setTimeout(function () {
            pintarRam();
        }, 1000);
    }

    if ($("#check-disipador").is(':checked')) {
        setTimeout(function () {

        }, 1000);
    }
}