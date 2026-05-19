# Домашнее задание 4: Отображение и редактирование профиля студента

Сейчас мы можем только просматривать данные студента, однако мы не можем их редактировать. На одном из прошлых занятий мы реализовывали функционал по редактированию заметок. Примените полученные знания, и реализуйте аналогичный функционал в данном проекте.

## Ссылки на группы с исходниками проектов:

| Группа | Ссылка на проект                                             | Ссылка на PR с изменениями                          |
| ------ | ------------------------------------------------------------ | --------------------------------------------------- |
| ПД-412 | https://github.com/TOP-PD-412/PersonalAccount/tree/Lesson-10 | проект был перенесен                                |
| П-318  | https://github.com/TOP-P-318/PersonalAccount/tree/lesson-9   | https://github.com/TOP-P-318/PersonalAccount/pull/4 |
| П-319  | https://github.com/TOP-P-319/PersonalAccount/fork            |                                                     |

# Ход работы

## 1.1 Отображение данных студента на странице

У некоторых групп эта часть задания уже реализована в ходе работы в классе. Ее необходимо выполнить только тем, у кого она еще не готова.

### 1.1.1 Доработать `View` для отображения всех полей студента.

```HTML
@model StudentModel;
<!-- File: Views/Cabinet/Index.cshtml -->
<!-- Тут просто отображаете все поля студента, кроме его ID.
    Если обладаете чувством прекрасного, то можете стилизовать данную страницу.
    В проекте уже подключена библиотека bootstrap, поэтому моежет воспользоваться классами из нее -->
```

### 1.1.2 Доработать метод `Index` в контроллере `CabinetController`

```C#
// File: Controllers/CabinetController.cs
public class CabinetController(/*...*/, IStudentService students) : Controller
{
    // ...

    /**
    * Метод, возвращающий страницу представления студента
    */
    [HttpGet]
    public async Task<IActionResult> Index() { // метод асинхронных, так как выполняет запрос в БД
        // TODO: получаем id студента из Cookie
        // TODO: остальные данные достаем из БД
        var student = // обращение к StudentService students
        return View(student); // Тут мы можем сразу передавать объект student, так он является моделью для этого View
    }
}
```

### 1.1.3 Как вы заметили, в контроллере мы обращаемся к некоему `StudentService`, а значит, его надо реализовать

```C#
// File: Services/IStudentService.cs
public interface IStudentService
{
    Task<StudentModel?> GetById(int id);
}
```

В соседнем файле реализуйте данный сервис. Зависеть он будет от `IStudentRepo<StudentModel>` (не `StudentAuthModel`)

### 1.1.4 В репозиторий `StudentRepo` необходимо джобавить новый метод
```C#
// File: Repositories/IStudentRepo.cs
public interface IStudentRepo<T> where T : StudentModel
{
    Task<T?> GetById(int id);
}
```

### 1.1.5 Добавить все зависимости в `Program.cs`
У нас появились:
- Сервис `StudentService`
- Репозиторий `StudentRepo<StudentModel>` (Из-за различия в `Generic`-параметре, это полностью другой класс от `StudentRepo<StudentAuthModel>`)

## Требования
- Все поля StudentModel отображаются на сайте

## 2.1 Реализация формы для редакирования

### 2.1.1 Добавление отдельной `View` с полями для редактирования полей студента

Редактируемыми должны быть поля:

- `FullName` - имя студента
- `GroupName` - название группы
- `PhotoUrl` - ссылка на фото

[ ВАЖНО ] Поле `Email` редактироваться не должно.

### 2.1.2 Для работы с редактируемыми полями необходимо добавить соответсвующую `ViewModel` с валидацонными полями

```C#
// New file: Models/StudentEditViewModel.cs
public class StudentEditViewModel
{
    [Required(ErrorMessage = /*сообщение об ошибке*/)]
    public string FullName { get; set; } = string.Empty;
    [Required(ErrorMessage = /*сообщение об ошибке*/)]
    public string GroupName { get; set; } = string.Empty;
    public string? PhotoUrl { get; set; }
}
```

### 2.1.3 Вместе их будет связывать соответвующая пара методов `Edit` в `CabinetController`

```C#
// File: Controllers/CabinetController.cs
public class CabinetController : Controller
{
    // ...

    /**
    * Метод, возвращающий страницу формы для редактирования
    */
    [HttpGet]
    public async Task<IActionResult> Edit() {
        // TODO: получаем id студента из Cookie
        // TODO: остальные данные достаем из БД

        return View(new StudentEditViewModel{
            // TODO: заполеняем данными студента из БД
        });
    }


    /**
    * Метод, применяющий изменения на основе данных из формы
    */
    [HttpPost]
    [ValidateAntiforgeryToken]
    public async Task<IActionResult> Edit(StudentEditViewModel model) {
        // TODO: проверяем ModelState на наличие ошибок
        // TODO: обновляем данные в БД на основе model

       return RedirectToAction("Index");
    }

    // ...
}
```

### 2.1.4 Обновить `StudentService`
```C#
// File: Services/IStudentService.cs
public interface IStudentService
{
    Task UpdateById(int id, StudentModel student);
}
```

### 2.1.5 В `StudentRepo` необходимо добавить метод для обновления записи в БД
```C#
// File: Repositories/IStudentRepo.cs
public interface IStudentRepo<T> where T : StudentModel
{
    Task UpdateById(int id, StudentModel student);
}
```

### 2.1.4 Чтобы иметь возможность перейти в режим редактирвоания, необзодимо добавить кнопку на главную страницу кабинета

```HTML
<!-- File: Views/Cabinet/Index.cshtml -->

<form method="get" asp-controller="Cabinet" asp-action="Edit">
    <!-- Просто фрма с кнопкой редактироватью.
      Она через метод GET перебросит на страницу для редактирования,
      а та, в свою очередь будет иметь форму уже с методом POST,
      которая будет вызывать метод для применения результатов редактирования -->
    <button type="submit">Редактировать</button>
</form>
```

## Требования
- Страница редактирования переключается по нажатию на кнопку
- Поля `FullName`, `GroupName`, `PhotoUrl` редактируются
- Данные формы валидируются, и ошибки отображаются на экране
- Контроллер не пропускает форму с невалидными данными
- При валидных данных контроллер обновляет данные студента