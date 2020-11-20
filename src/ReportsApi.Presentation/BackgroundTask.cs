using ReportsApi.Application.MessageQueue;
using ReportsApi.Application.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ReportsApi
{
	public class BackgroundTask
	{
		private readonly IMessageListener _messageListener;
		private readonly IMessageHandler _messageHandler;
		private readonly string _reportRequestsTopic;

		public BackgroundTask(IMessageListener messageListener, IMessageHandler messageHandler, string reportRequestsTopic)
		{
			_messageListener = messageListener;
			_messageHandler = messageHandler;
			_reportRequestsTopic = reportRequestsTopic;
		}

		public async Task RunAsync()
		{
			await _messageListener.ListenToTopicAsync(_reportRequestsTopic, _messageHandler);
		}
	}
}