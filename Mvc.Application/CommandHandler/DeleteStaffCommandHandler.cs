using MediatR;
using Microsoft.EntityFrameworkCore;
using Mvc.Application.Command;
using Mvc.Infrastructure.Data;

namespace Mvc.Application.CommandHandler
{
    public class DeleteStaffCommandHandler : IRequestHandler<DeleteStaffCommand, bool>
    {
        private readonly AppDbContext _context;

        public DeleteStaffCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteStaffCommand request, CancellationToken cancellationToken)
        {
            var staff = await _context.Staffs.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (staff == null)
                return false;

            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
