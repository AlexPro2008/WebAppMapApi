// на ГЕТ запросе передаем данные
// Загружаем все дисциплины
$().ready(() => GetDisciplines());


// На Get запросе загрузка данных
// отдаем частичное представление
// и при загрузки самих данные привязываем обработчики событий
function GetDisciplines() {
    fetch('/App/GetDisciplinePartialView', { method: "GET" })
        .then(s => s.text())
        .then(s => {
            // Заполняем таблицу данными
            $("#table").html(s);          
        }).catch(s => console.error(s));
} // GetDisciplines

