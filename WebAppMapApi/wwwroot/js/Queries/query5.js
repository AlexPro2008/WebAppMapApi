// На GET-запросе вызываем модальное окно
$(document).ready(() => {

    // вызываем модальное окно
    $('#modalQuery5').modal('show');

});

$('#LowAndHighForm').submit((e) => {

    // отменяем стандартное действие
    e.preventDefault()

    // для рендеринга таблицы
    let table = $('#tbody');

    // загрузили данные с формы пасспорт
    let low = $('#low').val();

    // загрузили данные с формы фамилия
    let high = $('#high').val();

    // для формы
    let body = new FormData();

    // добавляем данные
    body.append('low', low);
    body.append('high', high);

    // fetch api
    fetch('/Query/Query5', {
        method: "POST",
        body: body
    }).then(s => s.text())
        .then(s => {
            // Плавно скрываем модалку
            $('#modalQuery5').fadeOut();

            // Убираем затемнение фона, если оно осталось
            $('.modal-backdrop').fadeOut();

            // рендерим таблицу
            $("#table").html(s);
        }).catch(s => console.dir(s));

});
