using System;
using System.Collections.Generic;

namespace Core
{
	public class Node
	{
		public IEnumerable<string> Options { get; set; }
		public Node Child { get; set; }
	}
}

