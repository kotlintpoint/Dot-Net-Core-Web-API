using GetriWebApi.DataAccess;
using GetriWebApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Application.Core;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest<Result<Activity>>
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Activity>>
        {
            private readonly ApplicationDbContext _context;
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Activity>> Handle(Command request, CancellationToken cancellationToken)
            {
                EntityEntry<Activity> entity = await _context.Activities.AddAsync(request.Activity);

                var result = await _context.SaveChangesAsync() > 0;
                
                if (!result)
                {
                    return Result<Activity>.Failure("Failed to create Activity");
                }
                
                return Result<Activity>.Success(entity.Entity);
            }
        }

    }
}
