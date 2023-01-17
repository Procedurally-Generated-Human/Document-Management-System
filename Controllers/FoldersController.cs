using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoDMS.Data;
using DemoDMS.Models;

namespace DemoDMS.Controllers
{
    public class FoldersController : Controller
    {
        private readonly DemoDMSContext _context;


        public FoldersController(DemoDMSContext context)
        {
            _context = context;

        }

        // GET: Folders
        public async Task<IActionResult> Index(int id)
        {
            
            var folders = from m in _context.Folder
            select m;
            var folder = folders.Where(m => m.Id==id);
            return View(folders);
        }

        public async Task<IActionResult> initial(int? id)
        {
            var folder = await _context.Folder.FirstOrDefaultAsync(m => m.Id == id);
            return View(folder);
        }

        // GET: Folders/Create
        public IActionResult Create(int id)
        {
            ViewData["parentId"] = id;
            return View();
        }

        // POST: Folders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, int parentId)
        {
                Folder folder = new Folder();
                folder.Name = name;
                _context.Add(folder);
                await _context.SaveChangesAsync();

    
                var parentFolder = await _context.Folder.FindAsync(parentId);
                parentFolder.Name = "AAAAAAAAAA";
                _context.Update(parentFolder);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

        }

        // GET: Folders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Folder == null)
            {
                return NotFound();
            }

            var folder = await _context.Folder.FindAsync(id);
            if (folder == null)
            {
                return NotFound();
            }
            return View(folder);
        }

        // POST: Folders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Folder folder)
        {
            if (id != folder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(folder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FolderExists(folder.Id))
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
            return View(folder);
        }

        // GET: Folders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Folder == null)
            {
                return NotFound();
            }

            var folder = await _context.Folder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (folder == null)
            {
                return NotFound();
            }

            return View(folder);
        }

        // POST: Folders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Folder == null)
            {
                return Problem("Entity set 'DemoDMScnt.Folder'  is null.");
            }
            var folder = await _context.Folder.FindAsync(id);
            if (folder != null)
            {
                _context.Folder.Remove(folder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FolderExists(int id)
        {
          return (_context.Folder?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
