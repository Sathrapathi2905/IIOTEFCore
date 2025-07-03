using MediatR;
using Microsoft.EntityFrameworkCore;
using Mvc.Application.Command;
using Mvc.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Application.CommandHandler
{
    public class UpdateStaffCommandHandler : IRequestHandler<UpdateStaffCommand, bool>
    {
        private readonly AppDbContext _context;

        public UpdateStaffCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateStaffCommand request, CancellationToken cancellationToken)
        {
            var staff = await _context.Staffs.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (staff == null)
                return false;

            staff.Name = request.Name;
            staff.Department = request.Department;
            staff.Email = request.Email;
            staff.Phone = request.Phone;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
