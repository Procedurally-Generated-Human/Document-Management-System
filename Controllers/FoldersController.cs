using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoDMS.Data;
using DemoDMS.Models;
using System.Collections;
using System.Dynamic;

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
        public async Task<IActionResult> Index(int id, string searchString)
        {
            ViewBag.currentID = id;

            var folders = from m in _context.Folder select m;
            var documents = from m in _context.Document select m;
            dynamic model = new ExpandoObject();

            if(!String.IsNullOrEmpty(searchString))
            {
                model.Folders = folders.Where(m => m.Name!.Contains(searchString));
                model.Documents = documents.Where(m => m.Name!.Contains(searchString));
            }
            else
            {
                model.Folders = folders.Where(m => m.ParentId == id);
                model.Documents = documents.Where(m => m.ParentId == id);
            }

            if(id==0){
                ViewBag.parentId = 0;
            }
            else{
                var folder = await _context.Folder.FirstOrDefaultAsync(m => m.Id == id);
                ViewBag.parentId = folder.ParentId;
            }

            return View(model);
        }

        // GET: Folders/Create
        public IActionResult Create(int id)
        {
            ViewBag.parentId = id;

            return View();
        }

        // POST: Folders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, int parentId)
        {
            Folder folder = new Folder {
                Name = name,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                ParentId = parentId,
            };
            
            var parentFolder = await _context.Folder.FindAsync(parentId);

            if(parentFolder != null) {
                parentFolder.Contents.Add(folder);
            }

            _context.Add(folder);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new {id = parentId});
        }

        // GET: Folders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Folder == null)
            {
                return NotFound();
            }

            var folder = await _context.Folder.FindAsync(id);

            if(folder == null)
            {
                return NotFound();
            }

            ViewBag.parentId = folder.ParentId;

            return View(folder);
        }

        // POST: Folders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string name, int parentId)
        {
            if(id == null || _context.Folder == null)
            {
                return NotFound();
            }
            
            var folder = await _context.Folder.FindAsync(id);

            if(folder == null)
            {
                return NotFound();
            }

            if(id != folder.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    folder.Name = name;
                    folder.DateModified = DateTime.Now;
                    _context.Update(folder);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!FolderExists(folder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index", new {id = parentId});
            }

            return View(folder);
        }

        // GET: Folders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _context.Folder == null)
            {
                return NotFound();
            }

            var folder = await _context.Folder.FirstOrDefaultAsync(m => m.Id == id);

            if(folder == null)
            {
                return NotFound();
            }

            ViewBag.parentId = folder.ParentId;

            return View(folder);
        }

        // POST: Folders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_context.Folder == null)
            {
                return Problem("Entity set 'DemoDMScnt.Folder' is null.");
            }

            var folder = await _context.Folder.FindAsync(id);
            var parentId = folder.ParentId;

            if(folder != null)
            {
                _context.Folder.Remove(folder);
            }
            
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new {id = parentId});
        }

        private bool FolderExists(int id)
        {
          return (_context.Folder?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
