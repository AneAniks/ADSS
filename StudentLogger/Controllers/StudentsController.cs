using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentLogger.Data;
using StudentLogger.Models;
using StudentLogger.Services;


namespace StudentLogger.Controllers
{
    public class StudentsController : Controller
    {
        //private readonly StudentLoggerContext _context;

        //public StudentsController(StudentLoggerContext context)
        //{
        //    _context = context;
        //}
        private readonly IStudentService __studentService;

        public StudentsController(IStudentService studentService)
        {
            __studentService = studentService;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await __studentService.GetStudents());
        }

        //// GET: Students/Details/5
        //public async Task<IActionResult> Details(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var students = await __studentService.GetStudentById(id);
        //       //var students =  await .FirstOrDefaultAsync(m => m.StudentId == id);
        //    if (students == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(students);
        //}

        //// GET: Students/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Students/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("StudentId,FullName,EnrollDate")] Students students)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        __studentService.Add(students);
        //        await __studentService.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(students);
        //}

        //// GET: Students/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var students = await __studentService.Students.FindAsync(id);
        //    if (students == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(students);
        //}

        //// POST: Students/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("StudentId,FullName,EnrollDate")] Students students)
        //{
        //    if (id != students.StudentId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            __studentService.Update(students);
        //            await __studentService.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!StudentsExists(students.StudentId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(students);
        //}

        //// GET: Students/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var students = await __studentService.Students
        //        .FirstOrDefaultAsync(m => m.StudentId == id);
        //    if (students == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(students);
        //}

        //// POST: Students/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var students = await __studentService.Students.FindAsync(id);
        //    __studentService.Students.Remove(students);
        //    await __studentService.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool StudentsExists(int id)
        //{
        //    return __studentService.Students.Any(e => e.StudentId == id);
        //}
    }
}
