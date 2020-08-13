# Fan-Bot's ![](https://img.shields.io/badge/PRICE-free-%231DC8EE) ![](https://img.shields.io/badge/.Net_Framework-4.7-%231DC8EE)
![GitHub All Releases](https://img.shields.io/github/downloads/Lako-FC/Fan-Bots/total?color=%231DC8EE&label=DOWNLOADS&logo=GitHub&logoColor=%231DC8EE&style=flat-square)
![GitHub last commit](https://img.shields.io/github/last-commit/Lako-FC/Fan-Bots?color=%231DC8EE&label=LAST%20COMMIT&style=flat-square)
![GitHub Release Date](https://img.shields.io/github/release-date/Lako-FC/Fan-Bots?color=%231DC8EE&label=RELEASE%20DATE&style=flat-square)

Fan-Bot's - **бесплатное ПО**, которое запускает ботов для игры Warface.

Группа ВК: **[Fan-Bot's ● (Fun-Bot's for Warface)][group_vk]**

Связанный проект: **[WarfaceBotFB][warfacebotfb]**

[group_vk]: https://vk.com/fanbots_wf
[wbl]: https://github.com/Levak/warfacebot
[wf_ru]: https://ru.warface.com/
[releases]: https://github.com/Lako-FC/Fan-Bots/releases/
[warfacebotfb]: https://github.com/Lako-FC/warfacebot_fb/releases/
[commands_wb]: https://github.com/Lako-FC/warfacebot_fb#команды
[screenshots]: https://github.com/Lako-FC/Fan-Bots/tree/master/SCREENSHOTS/README.md

## Основной функционал

- Запуск ботов (warfacebot_fb) на игровые сервера Warface.
- Авторизация MailRu, MyCom, GoPlay.
- Поддержка двухфакторной авторизации.
- Настройка запуска, ботов, цветов и т.д.
- Автоматические команды (выполняются при запуске бота).
- Автоматическое обновление ключей.
- Поддержка нескольких языков (требует доработки).
- Запуск всех ботов и их рестарт.
- Сохранение данных аккаунта, настроек и логов (авторизации и ботов).

## Главное меню  **[(остальные скрины)][screenshots]**
![](https://github.com/Lako-FC/Fan-Bots/blob/master/SCREENSHOTS/1.png?raw=true)

## Как использовать

- ### Безопасный запуск
Запускайте на **виртуальной машине**, где **НЕТ** **Warface** и **Игрового Центра**, иначе вы можете получить **блокировку основного аккаунта** (который запущен в игре Warface на данный момент).

- ### Поддержка: @mail.ru | @inbox.ru | @list.ru | @bk.ru | в будущем возможно и другие

- ### Вы должны иметь игровой аккаунт в Warface

1. Вы должны зарегистрироваться на нужном вам сервере (для RU: **[ru.warface.com][wf_ru]**). 
2. Ваш игровой аккаунт для бота должен быть свободен.
3. Он не должен быть заблокирован.

- ### Запуск бота
1. Скачайте последний релиз **Fan-Bot's** : **[Releases][releases]**
2. Перекиньте папку `Fan-Bot's` в удобное место.
3. Запустите `START.exe`.
4. Выберите `сервер`.
5. Введите `логин` и `пароль` от игрового аккаунта, который будет ботом.
6. Нажмите `ВОЙТИ`.

- ### Команды можете узнать [тут][commands_wb].

## Для разработчиков
- ### Информация о проекте
1. Целевая рабочая среда: `.Net Framework 4.7`
2. Среда разработки: `Visual Studio 2019`

- ### Сборка проекта
1. Установите Visual Studio (не забудьте поставить C# и .Net Framework 4.7).
2. Скачайте данный исходный код (лучше из релиза).
3. Выполните сборку проекта по очереди (`AUTHORIZATION` -> `LAUNCHER_FANBOT` -> `START`).
4. Запускайте по [инструкции запуска](https://github.com/Lako-FC/Fan-Bots#как-использовать).
