using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NixMdm.Data;
using NixMdm.Models;

namespace NixMdm.Controllers
{
    public partial class DeviceController : Controller
    {
        private readonly MDMContext _context;

        public DeviceController(MDMContext context)
        {
            _context = context;
        }

        // GET: Search
        public async Task<IActionResult> Index(String searchString)
        {
            var devices = _context.Device.Include(d => d.User).AsNoTracking();

            if(!String.IsNullOrEmpty(searchString))
            {
                devices = devices.Where(d => d.PhoneNumber.Contains(searchString));
            }
            return View(await devices.ToListAsync());
        }

        // GET: Device/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device.Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Device/Create
        public IActionResult Create()
        {
            var model = new DeviceViewModel();
            model.OSVersion = "android";
            return View(model);
        }

        // POST: Device/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IMEI,Name,UserID,PhoneNumber,OSVersion,DateAdded")] DeviceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var device = new Device()
                {
                    IMEI = viewModel.IMEI,
                    Name = viewModel.Name,
                    User = viewModel.User,
                    PhoneNumber = viewModel.PhoneNumber,
                    OSVersion = viewModel.OSVersion,
                    DateAdded = viewModel.DateAdded
                };
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Device/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var device = await _context.Device.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            var model = new DeviceViewModel()
            {
                Id = device.Id,
                IMEI = device.IMEI,
                Name = device.Name,
                User = device.User,
                PhoneNumber = device.PhoneNumber,
                OSVersion = device.OSVersion,
                DateAdded = device.DateAdded
            };
            return View(model);
        }

        // POST: Device/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IMEI,Name,UserID,PhoneNumber,OSVersion,DateAdded")] DeviceViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var device = new Device()
                    {
                        Id = model.Id,
                        IMEI = model.IMEI,
                        Name = model.Name,
                        User = model.User,
                        PhoneNumber = model.PhoneNumber,
                        OSVersion = model.OSVersion,
                        DateAdded = model.DateAdded
                    };
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Device/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device
                .FirstOrDefaultAsync(m => m.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Device/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Device.FindAsync(id);
            _context.Device.Remove(device);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(int id)
        {
            return _context.Device.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        {
            return await _context.Device.Select(d => deviceToDTO(d)).ToListAsync();
        }

        private static Device deviceToDTO(Device d) => 
            new Device()
            {
                Id = d.Id,
                IMEI = d.IMEI,
                Name = d.Name,
                User = d.User,
                PhoneNumber = d.PhoneNumber
            };
    }
}
