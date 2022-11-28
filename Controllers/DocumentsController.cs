using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using DemoDMS.Data;
using DemoDMS.Models;

namespace DemoDMS.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly IStringLocalizer<DocumentsController> _localizer;
        private readonly DemoDMSContext _context;

        public DocumentsController(IStringLocalizer<DocumentsController> localizer, DemoDMSContext context)
        {
            _localizer = localizer;
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index(string searchString)
        {
            var documents = from m in _context.Document
            select m;

            if(!String.IsNullOrEmpty(searchString))
            {
                documents = documents.Where(s => s.Name!.Contains(searchString) || s.UserName!.Contains(searchString));
            }

            ViewData["searchString"] = searchString;

            return View(await documents.ToListAsync());
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document.FirstOrDefaultAsync(m => m.Id == id);

            if(document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        public async Task<IActionResult> Download(int? id)
        {
            if(id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document.FindAsync(id);
            if(document == null)
            {
                return NotFound();
            }
            
            string filePath = document.FilePath;
            string fileName = document.Name + document.Extension;
            string fileType = document.FileType;
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, fileType, fileName);
        }
        
        // GET: Documents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<IFormFile> files, String name, String userName, Category category)
        {
            foreach(var file in files)
            {
                var basePath = Path.Combine("Documents");
                bool basePathExists = System.IO.Directory.Exists(basePath);

                if(!basePathExists)
                {
                    Directory.CreateDirectory(basePath);
                }

                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);

                Console.WriteLine(file.ContentType);
                Console.WriteLine(file.Length);

                if(!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                
                var document = new Document
                {
                    UploadDate = DateTimeOffset.Now,
                    ModifiedDate = DateTimeOffset.Now,
                    UserName = userName,
                    Name = name,
                    FilePath = filePath,
                    FileType = file.ContentType,
                    Extension = extension,
                    Size = file.Length,
                    Category = category
                };

                _context.Document.Add(document);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Documents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document.FindAsync(id);

            if(document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, List<IFormFile> files, String name, String userName, Category category)
        {
            if(id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document.FindAsync(id);

            if(document == null)
            {
                return NotFound();
            }

            if(id != document.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                bool isEmpty = !files.Any();
                IFormFile file = null;

                if (!isEmpty)
                {
                    file = files[0];
                }

                document.Name = name;
                document.UserName = userName;
                document.Category = category;

                if(!isEmpty)
                {
                    var basePath = Path.Combine("Documents");
                    bool basePathExists = System.IO.Directory.Exists(basePath);
                    
                    if(!basePathExists)
                    {
                        Directory.CreateDirectory(basePath);
                    }

                    var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    var filePath = Path.Combine(basePath, file.FileName);

                    if (!System.IO.File.Exists(filePath))
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }

                    document.ModifiedDate = DateTimeOffset.Now;
                    document.Extension = Path.GetExtension(file.FileName);
                    document.Size = file.Length;
                    document.FileType = file.ContentType;
                    document.FilePath = filePath;
                }
                try
                {
                    _context.Update(document);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!DocumentExists(document.Id))
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

            return View(document);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document.FirstOrDefaultAsync(m => m.Id == id);

            if(document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if(_context.Document == null)
            {
                return Problem("Entity set 'DemoDMSContext.Document'  is null.");
            }

            var document = await _context.Document.FindAsync(id);

            if(document != null)
            {
                _context.Document.Remove(document);
            }
            
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
          return (_context.Document?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
