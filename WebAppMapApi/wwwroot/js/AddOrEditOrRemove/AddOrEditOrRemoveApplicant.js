// на ГЕТ запросе передаем данные
// Загружаем всех абитуриентов
$().ready(() => {
    // получения абитуриентов
    GetApplicants()
    // навешаем событие для отображения превью
    SetupChangePhoto();
    // кнопка отмена
    SetupOutModal();
});


// На Get запросе загрузка данных
// отдаем частичное представление
// и при загрузки самих данные привязываем обработчики событий
function GetApplicants() {
    fetch('/App/GetApplicantPartialView', { method: "GET" })
        .then(s => s.text())
        .then(s => {
            // Заполняем таблицу данными
            $("#table").html(s);
            UpdateSetupsAndTableApplicant(s);
        }).catch(s => console.error(s));
} // GetApplicants
// создания обьекта
function SetupAddApplicant() {  
    
    // для создания экзамена
    $("#item").click(() => {

        // отчищаем путь
        $("#photo").val('');        
        // ид
        let id = 0;
        // открыли данные
        CheckIdGetFetchApplicant(id);

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
            AddBodyApplicant(body);

            // fetch api       
            FetchUpdateOrAddApplicant(body);
        });
    });
} // SetupAdd


// редактирования обьекта
function SetupEditApplicant() {
    
    // навешиваем обработчик
    $("#tbody").on('click', '.edit-button', function () {
        // отчищаем путь
        $("#photo").val('');
        // извлекаем данные
        let data = $(this).data("id");
        // прочитали данные 
        CheckIdGetFetchApplicant(data);
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
        AddBodyApplicant(body);

        // передали маршрут
        FetchUpdateOrAddApplicant(body);
    });
} // SetuoEdit



// добавления данных
function FillValueApplicant(id, surname, name, patronymic, born, passport, place, path) {

    // добавили прочитанные данные
    $("#id").val(id);
    $("#path").attr('src', path);    
    $("#surname").val(surname);
    $("#name").val(name);
    $("#patronymic").val(patronymic);
    $("#passport").val(passport);
    $("#place").val(place);   
    $("#date").val(moment(born,
        "DD.MM.YYYY")
        .format("YYYY-MM-DD"));
} // FileValueApplicant


// добавления в Body
function AddBodyApplicant(body) {
    // добавляем
    body.append('Id', $("#id").val());
    body.append('Path', $("#path").attr('src'));
    body.append('Surname', $("#surname").val());
    body.append('Name', $("#name").val());
    body.append('Patronymic', $("#patronymic").val());
    body.append('Born', $("#date").val());
    body.append('Place', $("#place").val());
    body.append('Passport', ($("#passport").val()));
} // AddBodyApplicant


// Get запрос fetch
function CheckIdGetFetchApplicant(data) {

    // чтения для добавления экзамена
    if (data == 0) {
        // открыли данные
        fetch(`/App/AddOrUpdateApplicant/${data}`, { method: "GET" })
            .then(s => s.json())
            .then((s) => {
                // добавляем значения
                FillValueApplicant(data,
                    '', '', '', s.Date,
                    '00 2525', 'г.Донецк',s.Path);
               
                // открываем
                $("#AddOrEditModal").modal('show');               
            });
    } else {
        // или для редактирования
        fetch(`/App/AddOrUpdateApplicant/${data}`, { method: "GET" })
            .then(s => s.json())
            .then(s => {  
                // добавили прочитанные данные
                FillValueApplicant(s.Id, s.Surname,
                    s.Name, s.Patronymic,
                    s.Born, s.Passport,
                    s.Place,s.Path);
                // открываем заполненое
                $("#AddOrEditModal").modal('show');             
            });
    } // if-else

} // CheckIdGetFectchApplicant

// на отправку данных
function FetchUpdateOrAddApplicant(body) {
    // передали маршрут
    fetch('/App/AddOrUpdateApplicant', {
        method: "POST",
        body: body,
    }).then(response => response.text())
        .then(s => {                       
            // закрываем
            $('#AddOrEditModal').modal('toggle');
            // обновили таблицу и поставили обработчиков
            UpdateSetupsAndTableApplicant(s);
        });

} // FetchUpdateOrAddApplicant

// добавили обработчики
function UpdateSetupsAndTableApplicant(s) {
    // Заполняем таблицу данными
    $("#table").html(s);
    // навесили обработчик событий
    SetupAddApplicant();  
    SetupEditApplicant();
} // UpdateSetupsAndTableApplicant


// для изменения фотографии
function SetupChangePhoto() {
    $("#photo").change(function () {

        // форма
        let formData = new FormData();
        // добавили
        formData.append('file', $("#photo")[0].files[0]);

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
} // ChangePhoto

// настройка выход из модального окна
function SetupOutModal() {
    $("#close").click(() => $('#AddOrEditModal').modal('toggle'));
} // SetupOutModal

