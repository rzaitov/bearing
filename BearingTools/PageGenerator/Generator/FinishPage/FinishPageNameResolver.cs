using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageGenerator
{
    public class FinishPageNameResolver
    {
        readonly string directory;

        public FinishPageNameResolver(string dir)
        {
            directory = dir;
        }

        public string GetFileName(string article)
        {
            if (string.IsNullOrWhiteSpace(article))
                throw new ArgumentException();
            
            article = article.Trim().ToLower();
            List<char> lst = new List<char>(article.Length);

            for (int i = 0; i < article.Length; i++)
            {
                char c = article[i];
                if (char.IsLetterOrDigit(c))
                    lst.Add(c);
                else if (lst.Count > 0 && char.IsLetterOrDigit(lst[lst.Count - 1]))
                    lst.Add('-');
            }

            string fileName = string.Format("podshipnik-{0}.html", new string(lst.ToArray()));
            return fileName;
        }

        public string GetFilePath(string article)
        {
            string path = Path.Combine(directory, GetFileName(article));
            return path;
        }
    }
}
