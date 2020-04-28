ПО для хранения обучающих материалов (книги, курсы, статьи, ссылки, цитаты, инструкции и так далее).  
Software for storing training materials (books, courses, articles, links, quotes, instructions, and so on).

При добавлении локализаций был использован проект [WPF-Localization](https://github.com/Epsil0neR/WPF-Localization).  
При добавлении chrome-стиля и настроек был использован проект [Bachup](https://github.com/ChrisStayte/Bachup).

Code for localizations was taken from [WPF-Localization](https://github.com/Epsil0neR/WPF-Localization)  
Code for chrome style and setting was taken from [Bachup](https://github.com/ChrisStayte/Bachup)

Настройка проекта:
1. В проекте LearningDataStorage скопировать файл appsettings.sample.json и переименовать его в appsettings.json. В этом файле в параметре DefaultConnection указать подключение к существующему серверу и имя для новой базы данных. В параметре ServerUploadFolder указать путь к папке с файловыми таблицами.
2. Открыть проект папка Migrations, миграция InitDatabase, метод Up. Указать имя базы данных в значении для локальной переменной dbName, путь к папке с файловыми таблицами в локальной переменной fileTablesPath.
3. Проверить, включен ли FileStream в установленном SQL Server. Инструкция [здесь](https://docs.microsoft.com/ru-ru/sql/relational-databases/blob/enable-and-configure-filestream?view=sql-server-ver15)
4. Открыть Package Manager Console и выполнить миграцию командой Update-Database.

Project setup:
1. In the LearningDataStorage project, copy the appsettings.sample.json file and rename it to appsettings.json. Specify the connection to the existing server and the name for the new database in the DefaultConnection parameter. Specify the path to the folder with file tables in the ServerUploadFolder parameter.
2. Open the project folder Migrations, migration InitDatabase, method Up. Specify the database name in the value for the local variable dbName, the path to the folder with file tables in the local variable fileTablesPath.
3. Check if FileStream is enabled on the installed SQL Server. Instruction [here](https://docs.microsoft.com/en-us/sql/relational-databases/blob/enable-and-configure-filestream?view=sql-server-ver15)
4. Open the Package Manager Console and migrate using the Update-Database command.
