# Introduction
Веб-приложение для просмотра активности чата. Пользователю доступны просмотр сообщений за последние 2 часа, участие в переписке путем добавления сообщений, а также просмотр сообщений
за определенный период. Проект реализован с помощью фреймворков ASP.NET Core 2.0, Angular ^5.2.0, Angular CLI ~1.7.0. Для хранения данных используется СУБД MySql.

# Getting Started
1.	Установить NodeJS, npm.
2.  Выполнить `git clone` для скачивания исходных кодов проекта.

# Build and Test
Открыть `WebMessenger.sln` в Visual Studio. Перейти в папку `app\wwwroot\app-client\` и выполнить `npm i` для восстановления зависимостей.
Для сборки клиентской части выполнить `npm run-script build`. Эта команда создаст каталог cо статическими веб-файлами. При отсутствии ошибок возможен запуск проекта. Также необходимо создать БД, соответствующей настройкам в `appsettings.json`, создать таблицу

```
CREATE TABLE messages (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserName TEXT,
    Text TEXT NOT NULL,
    CreateDateTime DATETIME
);
```

Для тестирования клиентской части необходимо выполнить `npm run-script test`.
Для тестирования серверной части необходимо загрузить проект из каталога `app.Tests`.

--
This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 1.7.4.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `-prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
