using MediatR;
using Mvc.Domain.Entities;


namespace Mvc.Application.Queries
{
    public record GetStaffByIdQuery(int Id) : IRequest<Staff>;
}
