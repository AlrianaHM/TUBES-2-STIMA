class Filesize{
    private List<string> arrDirMarked = new List<string>();
    private long size;
    private long fsize;
    private Queue qf;
    
    public Filesize()
    {
        size = 0;
        qf = new Queue();
    }
    
    public long GetSize(string directory)
    {
        // Make a reference to a directory.
        DirectoryInfo di = new DirectoryInfo(directory);

        // Get a reference to each file in that directory.
        FileInfo[] fiArr = di.GetFiles();
        // Display the names and sizes of the files.
        long size = 0;
        foreach (FileInfo f in fiArr)
        {
            string exe = f.Extension;
            if (exe.Contains(".txt") || exe.Contains(".doc") || exe.Contains(".html") || exe.Contains(".h") || exe.Contains(".c") || exe.Contains(".java") || exe.Contains(".php"))
            {
                size += f.Length;
            }
        }
        return size;
    }

    public long GetFileSize(string rootDir)
    {
        Read R = new Read();
        R.setDir(rootDir);
        arrDirMarked.Add(rootDir);
        qf.Enqueue(rootDir);

        while (qf.Count != 0)
        {
            object temp;
            temp = qf.Dequeue();
            string s1 = temp.ToString();
            try
            {
                List<string> dirs = new List<string>(Directory.EnumerateDirectories(s1));

                foreach (var dir in dirs)
                {
                    string s2 = dir;

                    if (!arrDirMarked.Contains(s2))
                    {
                        fsize += GetSize(s2);
                        R.setDir(s2);
                        
                        arrDirMarked.Add(s2);
                        qf.Enqueue(s2);
                    }
                }
            }
            catch (Exception e)
            {
                // Console.WriteLine(e.Message);
            }
        }
        return fsize;
    }
}
