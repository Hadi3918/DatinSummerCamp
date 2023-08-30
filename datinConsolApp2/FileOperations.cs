using System.IO;

namespace datinConsolApp2
{
    internal class FileOperations
    {
        private List<string> StrList { get; set; } = new();
        private static string projectDirPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\")) + @"\Myfile\";
        private static string CurrentFilePath = "";
        public string CheckFileExist(string path)
        {
            while (!File.Exists(projectDirPath + path))
            {
                Console.WriteLine(Mysentences.NotFound);
                path = Console.ReadLine() + ".txt";
            }
            CurrentFilePath = projectDirPath + path;
            return FileReader();
        }

        public bool Chooseoptype(string inner)
        {
            try
            {
                short inner_short = (short)int.Parse(inner);
                switch (inner_short)
                {
                    case (short)ENOperations.ShowText: ShowText(); break;
                    case (short)ENOperations.Search: ChoosSearchtype(); break;
                    case (short)ENOperations.AddText: Console.WriteLine(Mysentences.AppendString); string matn = Console.ReadLine(); AppendString(matn); break;
                    case (short)ENOperations.NewFile: Console.WriteLine(Mysentences.ChooseNewFile); string filename = Console.ReadLine(); CheckFileExist(filename); break;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ChoosSearchtype()
        {
            try {
                Console.WriteLine(Mysentences.SearchLetter);
                string searchstring = Console.ReadLine();
                Console.WriteLine(Mysentences.ChooseSearchType);
                string choosentype = Console.ReadLine();
                short searchtype = (short)int.Parse(choosentype);
                Search(searchstring, searchtype); 
            }
            catch
            {
                Console.WriteLine(Mysentences.AdadRoVaredKonid);
                Task.Delay(1500);
                ChoosSearchtype();
            }
        }
        private string FileReader()
        {
            using (StreamReader stream = File.OpenText(CurrentFilePath))
            {
                string[] sentences;
                string? line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    if (line.Trim() != string.Empty)
                    {
                        sentences = line.Split('.');
                        for (int index = 0; index < sentences.Length; index++)
                        {
                            StrList.Add(sentences[index]);
                        }
                    }
                }
                return Mysentences.FileisRead;
            }
        }

        private void ShowText()
        {
            for (int index = 0; index < StrList.Count; index++)
            {
                Console.WriteLine(StrList[index]);
            }
        }

        private void Search(string searchstring, short enSearch)
        {
            bool showtextfind = false;
            if (enSearch == (short)ENSearch.CheckExist)
                StrList.ForEach(item =>
                {
                    if (item.Contains(searchstring))
                    {
                        Console.WriteLine(Mysentences.LetterFind);
                        return;
                    }
                });
            else if (enSearch == (short)ENSearch.FindSentences)
                StrList.ForEach(item =>
                {
                    if (item.Contains(searchstring))
                    {
                        if (showtextfind)
                        {
                            showtextfind = !showtextfind;
                            Console.WriteLine(Mysentences.AllTextFinds);
                        }
                        Console.WriteLine(item);
                    }
                });
        }

        private void AppendString(string appendstring)
        {
            using (StreamWriter w = File.AppendText(CurrentFilePath))
            {
                w.Write(appendstring);
            }
            string[] sentences = appendstring.Split('.');
            for (int index = 0; index < sentences.Length; index++)
            {
                StrList.Add(sentences[index]);
            }
        }
    }
}
