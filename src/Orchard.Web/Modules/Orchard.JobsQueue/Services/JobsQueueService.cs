using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Newtonsoft.Json;
using Orchard.Data;
using Orchard.JobsQueue.Models;

namespace Orchard.JobsQueue.Services {
    public class JobsQueueService : IJobsQueueService {
        private readonly IClock _clock;
        private readonly IRepository<QueuedJobRecord> _messageRepository;
        public JobsQueueService(
            IClock clock, 
            IRepository<QueuedJobRecord> messageRepository) {
            _clock = clock;
            _messageRepository = messageRepository;
        }
        public QueuedJobRecord Enqueue(string message, object parameters, int priority) {
            var queuedJob = new QueuedJobRecord {
                Parameters = JsonConvert.SerializeObject(parameters),
                Message = message,
                CreatedUtc = _clock.UtcNow,
                Priority = priority
            };
            _messageRepository.Create(queuedJob);
            return queuedJob;
    }
}
