using Application.Core;
using AutoMapper;
using GetriWebApi.DataAccess;
using GetriWebApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities
{
    public class Delete
    {
        public class Command : IRequest<Result<Activity>>
        {
            public Guid Id { get; set; }
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
                Activity activity = await _context.Activities.FindAsync(request.Id);
                if (activity == null)
                {
                    return null;
                }
                _context.Activities.Remove(activity);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result)
                {
                    return Result<Activity>.Failure("Failed to delete Activity");
                }
                return Result<Activity>.Success(activity);
                
            }
        }

    }
}
