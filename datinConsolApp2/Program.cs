using datinConsolApp2;

Console.WriteLine(Mysentences.Salam);
Console.WriteLine(Mysentences.Tozihat);

string response = Console.ReadLine();
string path = response + ".txt";

FileOperations fileOperations = new();

Console.WriteLine(fileOperations.CheckFileExist(path));
Console.WriteLine(Mysentences.DastorChist);
string order = Console.ReadLine();
bool typeselected = false;
while (!typeselected)
    if ((typeselected = fileOperations.Chooseoptype(order)))
    {
        Console.WriteLine(Mysentences.FileisRead);
        Console.WriteLine(Mysentences.DastorChist);
        order = Console.ReadLine();
        typeselected = false;
    }
       
