class BFS
{
    private List<Files> arrResult = new List<Files>();
    private List<string> arrDirMarked = new List<string>();
    private Queue q;
    private long dirsize;

    public BFS()
    {
        // Menciptakan queue kosong
        q = new Queue();
    }
    
    public List<Files> searchBFS(string rootDir, string pattern)
    {
        // Membaca file .txt
        Read R = new Read();
        Filesize FS = new Filesize(); // TAMBAHAN
        R.setDir(rootDir);
        arrResult = R.readTxt(pattern, arrResult);
        arrDirMarked.Add(rootDir);
        q.Enqueue(rootDir);
        long rootsize = FS.GetFileSize(rootDir);
        //Membaca file .docx
        arrResult = R.readDoc(pattern, arrResult);

        while (q.Count != 0)
        {
            object temp;
            temp = q.Dequeue();
            string s1 = temp.ToString();
            try
            {
                List<string> dirs = new List<string>(Directory.EnumerateDirectories(s1));

                foreach (var dir in dirs)
                {
                    string s2 = dir;
                   
                    if (!arrDirMarked.Contains(s2))
                    {
                        Console.WriteLine("{0}", s2);

                        dirsize += FS.GetSize(s2); // TAMBAHAN
                        R.setDir(s2);
                        // Membaca file .txt
                        arrResult = R.readTxt(pattern, arrResult);
                        // Membaca file .doc dan .docx
                        arrResult = R.readDoc(pattern, arrResult);

                        arrDirMarked.Add(s2);
                        q.Enqueue(s2);
                    }
                    Console.WriteLine("size :" + dirsize/1024 + "KB / " + rootsize/1024 + "KB"); // TAMBAHAN
                }
                
            }
            catch (Exception e)
            {
                // Console.WriteLine(e.Message);
            }
        }
        return arrResult;
    }
    public List<string> getDirMarked()
    {
        return arrDirMarked;
    }
}

class DFS
{
    private List<Files> arrResult = new List<Files>();
    private List<string> arrDirMarked = new List<string>();
    private Stack s;
    private long dirsize;
    public DFS()
    {
        // Menciptakan queue kosong
        s = new Stack();
    }
    public List<Files> searchDFS(string rootDir, string pattern)
    {
        // Membaca file .txt
        Read R = new Read();
        Filesize FS = new Filesize(); // TAMBAHAN
        long rootsize = FS.GetFileSize(rootDir);
        R.setDir(rootDir);
        arrResult = R.readTxt(pattern, arrResult);
        arrDirMarked.Add(rootDir);
        s.Push(rootDir);

        //Membaca file .docx
        arrResult = R.readDoc(pattern, arrResult);

        while (s.Count != 0)
        {
            object temp;
            temp = s.Pop();
            string s1 = temp.ToString();
            try
            {
                List<string> dirs = new List<string>(Directory.EnumerateDirectories(s1));
                //Console.WriteLine(s1);

                foreach (var dir in dirs)
                {

                    // Console.WriteLine("{0}", dir);
                    string s2 = dir;
                    if (!arrDirMarked.Contains(s2))
                    {
                        Console.WriteLine(s2);
                        dirsize += FS.GetSize(s2);  // TAMBAHAN
                        arrDirMarked.Add(s2);
                        s.Push(s2);
                        R.setDir(s2);
                        // Membaca file .txt
                        arrResult = R.readTxt(pattern, arrResult);
                        // Membaca file .doc dan .docx
                        arrResult = R.readDoc(pattern, arrResult);

                        Console.WriteLine("size :" + dirsize / 1024 + "KB / " + rootsize / 1024 + "KB"); // TAMBAHAN
                    }

                }

            }
            catch (Exception e)
            {
                // Console.WriteLine(e.Message);
            }
        }
        return arrResult;
    }
    public List<string> getDirMarked()
    {
        return arrDirMarked;
    }
}
