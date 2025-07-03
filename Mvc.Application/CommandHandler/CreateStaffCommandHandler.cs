using MediatR;
using Mvc.Application.Command;
using Mvc.Domain.Entities;
using Mvc.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Application.CommandHandler
{
    public class CreateStaffCommandHandler : IRequestHandler<CreateStaffCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateStaffCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            var staff = new Staff
            {
                Name = request.Name,
                Department = request.Department,
                Email = request.Email,
                Phone = request.Phone
            };

            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync(cancellationToken);

            return staff.Id;
        }
    }
}
