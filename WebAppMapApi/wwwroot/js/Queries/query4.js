// На GET - запросе выплывает модальное окно
$().ready(() => {
    $("#modalQuery4").modal('show');
})

// На отправку данных
$("#PassportAndSurnameForm").submit((e) => {

    // отменяем стандартуную отправку
    e.preventDefault();

    // для рендеринга таблицы
    let table = $("#tbody");

    // получаем с поля фамилии
    let surname = $("#surname").val();

    // получаем с поля паспорт
    let passport = $("#passport").val();

    // ссылка на обьект 
    let body = new FormData();

    // добавляем
    // фамилия
    body.append('surname', surname);

    // пасспорт
    body.append('passport', passport);

    // fetch api
    fetch('/Query/Query4', {
        method: "POST",
        body: body
    }).then(d => d.text())
        .then(s => {
            // Плавно скрываем модалку
            $('#modalQuery4').fadeOut();

            // Убираем затемнение фона, если оно осталось
            $('.modal-backdrop').fadeOut();

            // рендерим таблицу
            $("#table").html(s);
            

        });
});