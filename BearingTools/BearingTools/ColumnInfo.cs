using System;

namespace SchemaGenerator
{
	public class ColumnInfo
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public string Description { get; set; }

		public int? ColumnsMetaId { get; set; }
	}
}

