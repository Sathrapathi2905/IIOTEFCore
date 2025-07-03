using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc.Application.Command;
using Mvc.Application.Queries;
using Mvc.Domain.Entities;
using Mvc.Infrastructure.Data;
using System.Diagnostics;

namespace Mvc.Api.Controllers
{
    public class StaffController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public StaffController(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Staffs.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Staff staff)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateStaffCommand(staff.Name, staff.Department, staff.Email, staff.Phone);
                await _mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null) return NotFound();

            return View(staff);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Staff staff)
        {
            if (id != staff.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var command = new UpdateStaffCommand(staff.Id, staff.Name, staff.Department, staff.Email, staff.Phone);
                var result = await _mediator.Send(command);

                if (!result)
                    return NotFound();

                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null) return NotFound();

            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var command = new DeleteStaffCommand(id);
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var staff = await _mediator.Send(new GetStaffByIdQuery(id.Value));

            if (staff == null)
                return NotFound();

            return View(staff);
        }
    }
}
