# Library
Для запуска проекта:
1. Склонируйте репозиторий 
```
https://github.com/SergeyBrykulskii/Library.git
```
2. Поменяйте строку подключения к БД в следующих файлах (укажите данные своего пользователя Postgre):
```
Library\Library.API\appsettings.json
Library\IdentityServer\appsettings.json
```
3. Настройте решение, чтобы запускалось два проекта Library.API и IdentityServer (после запуска в БД будут тестовые данные)

В БД есть два тестовых пользователя с ролями Admin и User
---
Admin:
```
UserName: "Sany",
password: "7777"
```
User:
```
UserName: "Serega",
password: "1111"
```

Функционал удобно тестировать через Swagger, но ниже будут указаны конкретные эндпоинты приложения 
---
Авторизация (нужна для всех запросов кроме Get)
```
https://localhost:7132/api/Auth/login
```
Взаимодействие с авторами
  * Get, Put, Delete
```
https://localhost:7059/Author/{id}
```
  * Post
```
https://localhost:7059/Author
```
Взаимодействие с книгами
  * Get, Put, Delete
```
https://localhost:7059/Book/{id}
```
  * Get (все), Post
```
https://localhost:7059/Book
```
  * Get (по isbn)
```
https://localhost:7059/Book/isbn/{isbn}
```
