using Application.Core;
using AutoMapper;
using GetriWebApi.DataAccess;
using GetriWebApi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest<Result<Activity>>
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Activity>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;
            public Handler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Activity>> Handle(Command request, CancellationToken cancellationToken)
            {
                Activity activity = await _context.Activities.FindAsync(request.Activity.Id);
                if (activity == null)
                {
                    return null;
                }
                _mapper.Map(request.Activity, activity);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                {
                    return Result<Activity>.Failure("Failed to update Activity");
                }

                return Result<Activity>.Success(activity);
            }
        }

    }
}
