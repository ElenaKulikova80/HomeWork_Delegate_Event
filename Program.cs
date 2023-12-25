
using Delegate;

//1.Написать обобщённую функцию расширения, находящую и возвращающую максимальный элемент коллекции.
MaxElementSearch.Run();

//2.Написать класс, обходящий каталог файлов и выдающий событие при нахождении каждого файла
var fileLister = new FileSearch();
int filesFound = 0;

EventHandler<FileFoundArgs> onFileFound = (sender, eventArgs) =>
{
    Console.WriteLine(eventArgs.FoundFile);
    //если найден файл ".docx", то отменить дальнейший поиск 
    if (eventArgs.FoundFile.Contains(".docx"))
    {
        eventArgs.CancelRequested = true;
        
    }

    filesFound++;
};

fileLister.FileFound += onFileFound;
fileLister.Search(@"C:\Users\123\source\repos\findFile", "*");
fileLister.FileFound -= onFileFound;

Console.WriteLine("filesFound:" + filesFound);


