// на ГЕТ запросе передаем данные
// Загружаем все экзаменаторов
$().ready(() => {
    // получения экзаменаторов
    GetExaminators();
    // навешиваем событие
    SetupChangePhotoExaminer();
    // кнопка отмена
    SetupOutModal();
});

// На Get запросе загрузка данных
// отдаем частичное представление
// и при загрузки самих данные привязываем обработчики событий
function GetExaminators() {
    fetch('/App/GetExaminatorPartialView', { method: "GET" })
        .then(s => s.text())
        .then(s => {
            // Заполняем таблицу данными
            UpdateSetupsAndTableExaminer(s);       
        }).catch(s => console.error(s));
} // GetExaminators

/// создания обьекта
function SetupAddExaminer() {
    // для создания экзамена
    $("#item").click(() => { 
        // отчищаем путь
        $("#photo").val('');
        // ид
        let id = 0;

        // открыли данные
        CheckIdGetFetchExaminer(id);

        // на отправку данных
        // удаляем предущие обработчика
        // событий чтобы он при нажатии не добавлял 
        // по несколько раз 
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
            AddBodyExaminer(body);

            // fetch api       
            FetchUpdateOrAddExaminer(body);
        });
    });
} // SetupAdd


// редактирования обьекта
function SetupEditExaminer() {
    
    // навешиваем обработчик
    $("#tbody").on('click', '.edit-button', function () {
        // отчищаем путь
        $("#photo").val('');
        // извлекаем данные
        let data = $(this).data("id");

        // прочитали данные 
        CheckIdGetFetchExaminer(data);
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
        AddBodyExaminer(body);

        // передали маршрут
        FetchUpdateOrAddExaminer(body);
    });
} // SetuoEdit

// добавления данных
function FillValueExaminer(id, surname, name, patronymic,payment,path) {
    // добавили прочитанные данные
    $("#id").val(id);
    $("#path").attr('src',path)
    $("#surname").val(surname);
    $("#name").val(name);
    $("#patronymic").val(patronymic);
    $("#payment").val(payment);   
} // FileValueExaminer


// добавления в Body
function AddBodyExaminer(body) {
    // добавляем
    body.append('Id', $("#id").val());
    body.append('Path', $("#path").attr('src'));
    body.append('Surname', $("#surname").val());
    body.append('Name', $("#name").val());
    body.append('Patronymic', $("#patronymic").val());
    body.append('Payment', $("#payment").val());   
} // AddBodyExaminer


// Get запрос fetch
function CheckIdGetFetchExaminer(data) {

    // чтения для добавления экзамена
    if (data == 0) {
        // открыли данные
        fetch(`/App/AddOrUpdateExaminer/${data}`, { method: "GET" })
            .then(s => s.json())
            .then((s) => {
                // добавляем значения
                FillValueExaminer(data,
                    '', '', '', s.Payment, s.Path);
                // открываем
                $("#AddOrEditModal").modal('show');
            });

    } else {
        // или для редактирования
        fetch(`/App/AddOrUpdateExaminer/${data}`, { method: "GET" })
            .then(s => s.json())
            .then(s => {
                // добавили прочитанные данные
                FillValueExaminer(s.Id,
                    s.Surname, s.Name, s.Patronymic, s.Payment,s.Path);

                // открываем заполненое
                $("#AddOrEditModal").modal('show');
            });
    } // if-else

} // CheckIdGetFectchExaminer

// на отправку данных
function FetchUpdateOrAddExaminer(body) {
    // передали маршрут
    fetch('/App/AddOrUpdateExaminer', {
        method: "POST",
        body: body,
    }).then(response => response.text())
        .then(s => {
            // закрываем
            $('#AddOrEditModal').modal('toggle');

            // обновили таблицу и поставили обработчиков
            UpdateSetupsAndTableExaminer(s);
        });

} // FetchUpdateOrAddExaminer

// добавили обработчики
function UpdateSetupsAndTableExaminer(s) {
    // Заполняем таблицу данными
    $("#table").html(s);
    // навесили обработчик событий
    SetupAddExaminer();
    SetupEditExaminer();
} // UpdateSetupsAndTableExaminer


// для изменения фотографии
function SetupChangePhotoExaminer() {
    $("#photo").change(function () {

        // добавили
        let formData = new FormData();
        formData.append('file', $("#photo")[0].files[0]);

        // делаем запрос по заданному маршруту
        fetch('/App/ChangePhoto', {
            method: "POST",
            body: formData
        }).then(s => s.json())
            .then(s => {
                // вывели 
                $("#path").attr('src',s);              
            })
            .catch(s => console.error(s));
    });
} // SetupChangePhoto

// настройка выход из модального окна
function SetupOutModal() {
    $("#close").click(() => $('#AddOrEditModal').modal('toggle'));
} // SetupOutModal