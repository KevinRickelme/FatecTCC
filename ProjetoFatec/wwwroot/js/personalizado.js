$(function Details(id) {
    $.get("@Url.Action('ShowpopUp','Publicacao')" / + id,
        function (data) {
            $('.modal-body').html(data);
        });

    $("#modalPublicacao").modal("show");
});


$(
    function Curtir(id) {
        $.post("@Url.Action('CurtirPublicacao','Publicacao')/" + id,
            function (data) {
                if (data == -1) {
                    document.getElementById(id).children[0].children[1].children[2].classList.remove("fa-solid");
                    document.getElementById(id).children[0].children[1].children[2].classList.add("fa-regular");

                    let valorElems = document.getElementById(id).children[0].children[1].childElementCount;
                    if (valorElems == 8)
                        document.getElementById(id).children[0].children[1].children[7].children[0].innerHTML = "<span class=\" fa-regular fa-heart\"></span> Gostei";
                    else
                        document.getElementById(id).children[0].children[1].children[6].children[0].innerHTML = "<span class=\" fa-regular fa-heart\"></span> Gostei";
                    let valor = document.getElementById(id).children[0].children[1].children[3].innerHTML;
                    if (valorElems == 8) {
                        let valor = document.getElementById(id).children[0].children[1].children[4].innerHTML;
                        document.getElementById(id).children[0].children[1].children[4].innerHTML = " " + --valor;
                    }
                    else {
                        let valor = document.getElementById(id).children[0].children[1].children[3].innerHTML;
                        document.getElementById(id).children[0].children[1].children[3].innerHTML = " " + --valor;
                    }

                }
                else {
                    document.getElementById(id).children[0].children[1].children[2].classList.remove("fa-regular");
                    document.getElementById(id).children[0].children[1].children[2].classList.add("fa-solid");
                    let valorElems = document.getElementById(id).children[0].children[1].childElementCount;
                    if (valorElems == 8)
                        document.getElementById(id).children[0].children[1].children[7].children[0].innerHTML = "<span class=\" fa-solid fa-heart\"></span> Descurtir";
                    else
                        document.getElementById(id).children[0].children[1].children[6].children[0].innerHTML = "<span class=\" fa-solid fa-heart\"></span> Descurtir";
                    let valor = document.getElementById(id).children[0].children[1].children[3].innerHTML;
                    if (valorElems == 8) {
                        let valor = document.getElementById(id).children[0].children[1].children[4].innerHTML;
                        document.getElementById(id).children[0].children[1].children[4].innerHTML = " " + ++valor;
                    }
                    else {
                        let valor = document.getElementById(id).children[0].children[1].children[3].innerHTML;
                        document.getElementById(id).children[0].children[1].children[3].innerHTML = " " + ++valor;
                    }
                }
            });

    }
);