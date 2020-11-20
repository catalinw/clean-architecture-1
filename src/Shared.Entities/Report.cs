using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities.Domain
{
	public class Report
	{
		public string Id { get; set; }

		public ReportStatusEnum Status { get; set; }

		public string Content { get; set; }
	}
}
