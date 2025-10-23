// на ГЕТ запросе передаем данные
// Загружаем всех абитуриентов
$().ready(() => {
    // получения абитуриентов
    GetApplicants()    
});


// На Get запросе загрузка данных
// отдаем частичное представление
// и при загрузки самих данные привязываем обработчики событий
function GetApplicants() {
    fetch('/App/GetExaminerCardsPartialView', { method: "GET" })
        .then(s => s.text())
        .then(s => {
            // Заполняем карточки данными
            $("#render").html(s);    
        }).catch(s => console.error(s));
} // GetApplicants

