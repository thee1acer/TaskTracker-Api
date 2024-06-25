﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskTracker.Database.Models.Task;

namespace TaskTracker.Database.Services.Task
{
    public class GetAllTasks
    {
        private TaskTrackerContext _taskTrackerContext;
        public ILogger<GetAllTasks> _logger;

        public GetAllTasks(TaskTrackerContext taskTrackerContext, ILogger<GetAllTasks> logger)
        {
            _taskTrackerContext = taskTrackerContext;
            _logger = logger;
        }

        public async Task<List<TaskEntity>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var tasks = await _taskTrackerContext.Tasks.Include(v => v.TaskBlockers).ToListAsync(cancellationToken).ConfigureAwait(false);

            return tasks;
        }
    }
}
