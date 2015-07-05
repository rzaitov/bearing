using System;
using System.Text;

namespace SchemaGenerator
{
	public class ColumnsMetaGenerator
	{
		public ColumnsMetaGenerator ()
		{
		}

		public string Generage (ColumnMap headers)
		{
			if (headers == null)
				throw new ArgumentNullException ();

			var sb = new StringBuilder ();
			sb.AppendLine (
@"INSERT INTO `meta_columns` (`id`, `name`, `header`, `description`)
VALUES");

			int id = 1;
			foreach (var kvp in headers.Map) {
				ColumnInfo value = kvp.Value;
				sb.Append ("(")
					.AppendFormat ("{0}, ", value.ColumnsMetaId = id++)
					.AppendFormat ("\"{0}\", ", value.Name)
					.AppendFormat ("\"{0}\", ", kvp.Key);

				if (!string.IsNullOrWhiteSpace (value.Description))
					sb.AppendFormat ("\"{0}\"", value.Description);
				else
					sb.Append ("NULL");

				sb.AppendLine ("),");
			}

			sb.Length -= 2;
			sb.Append (";");

			return sb.ToString ();
		}
	}
}

