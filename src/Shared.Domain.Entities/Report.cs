using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Domain.Entities
{
	public class Report
	{
		public string Id { get; set; }

		public ReportStatusEnum Status { get; set; }

		public string Content { get; set; }
	}
}
