using System;
using System.Collections.Generic;

namespace Core
{
	public class GeneratorBuilder
	{
		readonly string key;

		int start, sepIndex;
		List<int> separators;

		Node root, current;

		public GeneratorBuilder (string key)
		{
			if (string.IsNullOrWhiteSpace (key))
				throw new ArgumentException ();

			this.key = key.Trim ();
		}

		public VariantsGenerator Build ()
		{
			string chunk;
			while ((chunk = GetNextChunk ()) != null) {
				Node node = new Node {
					Options = GetOptions (chunk)
				};
				Store (node);
			}

			return new VariantsGenerator (root);
		}

		IEnumerable<string> GetOptions (string str)
		{
			if (str.Length == 1) {
				char c = str [0];
				if(char.IsWhiteSpace(c))
					return new string[] { str, string.Empty };
				else if (!char.IsLetterOrDigit (c))
					return new string[] { str, " ", string.Empty };
			}

			if (str.ToLower () == "skf")
				return new string[] { "SKF", "СКФ" };

			return new string[] { str };
		}

		void Store(Node node)
		{
			if (root == null) {
				root = current = node;
			} else {
				current.Child = node;
				current = node;
			}
		}

		public string GetNextChunk ()
		{
			if (separators == null)
				separators = FindSeparators ();
			else if (start >= key.Length)
				return null;

			string chunk;
			int end = (sepIndex >= separators.Count) ? key.Length : separators [sepIndex];
			if (start == end) {
				chunk = key.Substring (start, 1);
				sepIndex++;
				start++;
			} else {
				chunk = key.Substring (start, end - start);
				start = end;
			}
			return chunk;
		}

		public List<int> FindSeparators ()
		{
			var indexes = new List<int> ();
			for (int i = 0; i < key.Length; i++) {
				if (!char.IsLetterOrDigit (key [i]))
					indexes.Add (i);
			}

			return indexes;
		}
	}
}