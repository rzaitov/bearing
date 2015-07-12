﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageGenerator
{
    class FinishPageNameResolver
    {
        readonly string directory;

        public FinishPageNameResolver(string dir)
        {
            directory = dir;
        }

        public string GetFilePath(string article)
        {
            article = article.Trim().ToLower();
            char[] arr = article.ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                char c = arr[i];
                if (!char.IsLetterOrDigit(c))
                    arr[i] = '-';
            }


            string fileName = string.Format("podshipnik-{0}.html", new string(arr));
            string path = Path.Combine(directory, fileName);
            return path;
        }
    }
}