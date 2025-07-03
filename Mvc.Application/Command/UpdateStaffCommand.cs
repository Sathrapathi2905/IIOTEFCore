using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Application.Command
{
    public record UpdateStaffCommand(int Id, string Name, string Department, string Email, string Phone) : IRequest<bool>;
}
