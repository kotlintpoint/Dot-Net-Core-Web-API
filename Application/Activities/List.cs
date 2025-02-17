using Application.Core;
using GetriWebApi.DataAccess;
using GetriWebApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<Activity>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<Activity>>>
        {
            private readonly ApplicationDbContext _context;
            private readonly ILogger<List> _logger;
            public Handler(ApplicationDbContext context, ILogger<List> logger)
            {
                _context = context;
                _logger = logger;
            }
            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                /*try
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    for (var i = 0; i < 10; i++)
                    {
                        await Task.Delay(1000, cancellationToken);
                        _logger.LogInformation($"Task {i} has completed.");
                    }
                }
                catch (Exception)
                {
                    _logger.LogInformation("Task was Cancelled");
                    return [];
                }*/

                return Result<List<Activity>>.Success(await _context.Activities.ToListAsync());
            }
        }

    }
}
