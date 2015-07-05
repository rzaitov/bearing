using System;
using System.Collections.Generic;

namespace SchemaGenerator
{
	public class ColumnMap
	{
		const string Text = "TEXT";
		const string Float = "FLOAT";

		readonly Dictionary<string, ColumnInfo> map;

		public ColumnMap ()
		{
			map = new Dictionary<string, ColumnInfo> {
				{ "Артикул", new ColumnInfo { Name = "article", Type = Text, Description = null } },
				{ "Артикул подкладного кольца", new ColumnInfo { Name = "article_backing_ring", Type = Text, Description = null } },
				{ "Артикул стопорного кольцоа", new ColumnInfo { Name = "article_locking_wheel", Type = Text, Description = null } },
				{ "Артикул (подшипник + закрепительная втулка)", new ColumnInfo { Name = "article_bearing_clamping_sleeve", Type = Float, Description = null } },
				{ "Фасонное кольцо", new ColumnInfo { Name = "shaped_ring", Type = Text, Description = null } },

				{ "d мм", new ColumnInfo { Name = "d_low", Type = Float, Description = null } },
				{ "D мм", new ColumnInfo { Name = "d_high", Type = Float, Description = null } },
				{ "D3", new ColumnInfo { Name = "d3", Type = Float, Description = null } },

				{ "B мм", new ColumnInfo { Name = "b", Type = Float, Description = null } },
				{ "2B мм", new ColumnInfo { Name = "2b", Type = Float, Description = null } },
				{ "H мм", new ColumnInfo { Name = "H", Type = Float, Description = null } },
				{ "Dw", new ColumnInfo { Name = "dw", Type = Float, Description = null } },
				{ "Lw", new ColumnInfo { Name = "lw", Type = Float, Description = null } },

				{ "C", new ColumnInfo { Name = "C", Type = Float, Description = null } },
				{ "C kN", new ColumnInfo { Name = "C_kn", Type = Float, Description = null } },
				{ "C0", new ColumnInfo { Name = "C0", Type = Float, Description = null } },
				{ "CO kN", new ColumnInfo { Name = "CO", Type = Float, Description = null } },
				{ "CO 0", new ColumnInfo { Name = "CO0", Type = Float, Description = null } },

				{ "Pu kN", new ColumnInfo { Name = "PU", Type = Float, Description = null } },
				{ "PuO kN", new ColumnInfo { Name = "PUO", Type = Float, Description = null } },

				{ "A", new ColumnInfo { Name = "A", Type = Float, Description = null } },
				{ "A max", new ColumnInfo { Name = "A_max", Type = Float, Description = null } },

				{ "V nom об/мин", new ColumnInfo { Name = "V_nom", Type = Float, Description = null } },
				{ "V max об/мин", new ColumnInfo { Name = "V_max", Type = Float, Description = null } },

				{ "кг", new ColumnInfo { Name = "weight", Type = Float, Description = null } },
				{ "кг (подшипник + кольцо)", new ColumnInfo { Name = "weight_with_circle", Type = Float, Description = null } },
				{ "Вес в 1000 штук", new ColumnInfo { Name = "weight_per_thousand", Type = Float, Description = null } },

				{ "r, r1,2 мин", new ColumnInfo { Name = "r_r1_2_min", Type = Float, Description = null } },
				{ "r1,2 min", new ColumnInfo { Name = "r1_2_min", Type = Float, Description = null } },
				{ "r1 max", new ColumnInfo { Name = "r1_max", Type = Float, Description = null } },
				{ "r2", new ColumnInfo { Name = "r2", Type = Float, Description = null } },
				{ "r min мкм", new ColumnInfo { Name = "r_min", Type = Float, Description = null } },
				{ "r max мкм", new ColumnInfo { Name = "r_max", Type = Float, Description = null } },
			};
		}
	}
}