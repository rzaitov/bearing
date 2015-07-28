using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
	public class VariantsGenerator
	{
		readonly Node root;
		readonly StringBuilder builder;
		readonly HashSet<string> hset;

		public VariantsGenerator (Node node)
		{
			if (node == null)
				throw new ArgumentNullException ();

			root = node;
			builder = new StringBuilder ();
			hset = new HashSet<string> ();
		}

		public IEnumerable<string> GetVariants ()
		{
			return Traverse (root);
		}

		IEnumerable<string> Traverse (Node node)
		{
			if (node == root) {
				hset.Clear ();
				builder.Clear ();
			}

			if (node == null) {
				string result = builder.ToString ();
				if (hset.Add (result))
					yield return result;
				yield break;
			}

			int len = builder.Length;
			foreach (var item in node.Options) {
				builder.Length = len;

				if (!IsValidOption (item))
					continue;

				builder.Append (item);

				foreach (var variant in Traverse (node.Child))
					yield return variant;
			}
		}

		bool IsValidOption (string option)
		{
			return option != " " ||
				   builder.Length == 0 ||
				   builder [builder.Length - 1] != ' ';
		}
	}
}