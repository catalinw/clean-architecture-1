using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Report
	{
		public string ReportId { get; set; }

		public ReportStatusEnum ReportStatus { get; set; }

		public string ReportContent { get; set; }
	}
}
