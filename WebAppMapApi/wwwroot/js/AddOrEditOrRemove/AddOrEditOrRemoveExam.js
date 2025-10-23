// на ГЕТ запросе передаем данные
// Загружаем все экзамены
$().ready(() => GetExams());

// На Get запросе загрузка данных
// отдаем частичное представление
// и при загрузки самих данные привязываем обработчики событий
function GetExams() {
    fetch('/App/GetExamPartialView', { method: "GET" })
        .then(s => s.text())
        .then(s => {
            // обновили таблицу и поставили обработчиков
            UpdateSetupsAndTable(s);
        }).catch(s => console.error(s));
} // GetExams


// создания обьекта
function SetupAdd() {
    // для создания экзамена
    $("#item").click(() => {

        // ид
        let id = 0;

        // открыли данные
        CheckIdGetFectch(id);

        // на отправку данных
        // удаляем предущие обработчика
        // событий чтобы он при нажатии не добавлял по несколько раз 
        // обьект
        $("#AddOrEdit").off('submit').on('submit', (e) => {
            // отменяем стандартных действия            
            e.preventDefault();

            // проверка на формы на валидацию
            if (!$("#AddOrEdit").valid()) {
                return;
            } // if
            // для данных 
            let body = new FormData();
            // добавляем
            AddBody(body);
            // fetch api       
            FetchUpdateOrAdd(body);
        });
    });
} // SetupAdd


// редактирования обьекта
function SetupEdit() {
    $("#tbody").on('click', '.edit-button', function () {

        // извлекаем данные
        let data = $(this).data("id");

        // прочитали данные 
        CheckIdGetFectch(data);
               
    });

    // на отправку данных
    $("#AddOrEdit").off('submit').on('submit', (s) => {
        // отменяем стандартных действия
        s.preventDefault();

        // Если валидация не прошла, выходим
        if (!$("#AddOrEdit").valid()) {
            return;
        } // if

        // для передачи данных
        let body = new FormData();

        // добавляем
        AddBody(body);

        // передали маршрут
        FetchUpdateOrAdd(body);
    });
} // SetuoEdit

// Удаления
function SetupDelete() {
    // Делегируем обработчик событий для кнопок "Удалить"
    $("#tbody").on('click', '.delete-button', function () {
        // получаем ид
        let id = $(this).data("id");
        // на fetch api
        fetch(`/App/RemoveExam/${id}`, { method: "GET" })
            .then(s => s.text())
            .then(s => {
                // рендерим таблицу
                UpdateSetupsAndTable(s);
            });
    });
} // SetupDelete


// добавления данных
function FillValue(id, applicantId, examinatorId, disciplineId, mark, date) {

    // добавили прочитанные данные
    $("#examId").val(id);
    $("#applicants").val(applicantId);
    $("#examiners").val(examinatorId);
    $("#disciplines").val(disciplineId);
    $("#mark").val(mark);
    $("#date").val(moment(date, "DD.MM.YYYY")
        .format("YYYY-MM-DD"));

} // FileValue


// добавления в Body
function AddBody(body) {
    // добавляем
    body.append('Id', $("#examId").val());
    body.append('ApplicantId', $("#applicants").val());
    body.append('ExaminatorId', $("#examiners").val());
    body.append('DisciplineId', $("#disciplines").val());
    body.append('Mark', $("#mark").val());
    body.append('Date', ($("#date").val()));
} // AddBody


// Get запрос fetch
function CheckIdGetFectch(data) {

    // чтения для добавления экзамена
    if (data == 0) {
        // открыли данные
        fetch(`/App/AddOrUpdateExam/${data}`, { method: "GET" })
            .then(s => s.json())
            .then((s) => {
                // добавляем значения
                FillValue(data, 1,
                    1,
                    1,
                    s.Mark,
                    s.Date);

                // открываем
                $("#AddOrEditModal").modal('show');
            });

    } else {
        // или для редактирования
        fetch(`/App/AddOrUpdateExam/${data}`, { method: "GET" })
            .then(s => s.json())
            .then(s => {
                // добавили прочитанные данные
                FillValue(s.Id, s.ApplicantId,
                    s.ExaminatorId,
                    s.DisciplineId,
                    s.Mark,
                    s.Date);
                // открываем заполненое
                $("#AddOrEditModal").modal('show');
            });
    } // if-else

} // CheckIdGetFectch

// на отправку данных
function FetchUpdateOrAdd(body) {
    // передали маршрут
    fetch('/App/AddOrUpdatePost', {
        method: "POST",
        body: body,
    }).then(response => response.text())
        .then(s => {
            // закрываем
            $('#AddOrEditModal').modal('toggle');

            // обновили таблицу и поставили обработчиков
            UpdateSetupsAndTable(s);
        });

} // FetchUpdateOrAdd

// добавили обработчики
function UpdateSetupsAndTable(s) {
    // Заполняем таблицу данными
    $("#table").html(s);
    // навесили обработчик событий
    SetupAdd();
    SetupDelete();
    SetupEdit();
} // UpdateSetupsAndTable

