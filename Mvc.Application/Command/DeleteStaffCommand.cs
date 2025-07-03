using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Application.Command
{
    public record DeleteStaffCommand(int Id) : IRequest<bool>;
}
