using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Application.Entities
{
	public class DbReport
	{
		public string ReportId { get; set; }

		public int ReportStatus { get; set; }

		public string ReportContent { get; set; }
	}
}
