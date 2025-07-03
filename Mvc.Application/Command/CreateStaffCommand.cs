using MediatR;

namespace Mvc.Application.Command
{
    public record CreateStaffCommand(string Name, string Department, string Email, string Phone) : IRequest<int>;
}
