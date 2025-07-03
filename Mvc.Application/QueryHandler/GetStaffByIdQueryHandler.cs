using MediatR;
using Microsoft.EntityFrameworkCore;
using Mvc.Application.Queries;
using Mvc.Domain.Entities;
using Mvc.Infrastructure.Data;


namespace Mvc.Application.QueryHandler
{
    public class GetStaffByIdQueryHandler : IRequestHandler<GetStaffByIdQuery, Staff>
    {
        private readonly AppDbContext _context;

        public GetStaffByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Staff?> Handle(GetStaffByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Staffs.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
        }
    }
}
