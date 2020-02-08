﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentLogger.Data;
using StudentLogger.Models;

namespace StudentLogger.Controllers
{
    public class EnrolledInsController : Controller
    {
        private readonly StudentLoggerContext _context;

        public EnrolledInsController(StudentLoggerContext context)
        {
            _context = context;
        }

        // GET: EnrolledIns
        public async Task<IActionResult> Index()
        {
            var studentLoggerContext = _context.EnrolledIn.Include(e => e.Course).Include(e => e.Student);
            return View(await studentLoggerContext.ToListAsync());
        }

        // GET: EnrolledIns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolledIn = await _context.EnrolledIn
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EnrollId == id);
            if (enrolledIn == null)
            {
                return NotFound();
            }

            return View(enrolledIn);
        }

        // GET: EnrolledIns/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId");
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId");
            return View();
        }

        // POST: EnrolledIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollId,CourseId,StudentId")] EnrolledIn enrolledIn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrolledIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", enrolledIn.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", enrolledIn.StudentId);
            return View(enrolledIn);
        }

        // GET: EnrolledIns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolledIn = await _context.EnrolledIn.FindAsync(id);
            if (enrolledIn == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", enrolledIn.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", enrolledIn.StudentId);
            return View(enrolledIn);
        }

        // POST: EnrolledIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollId,CourseId,StudentId")] EnrolledIn enrolledIn)
        {
            if (id != enrolledIn.EnrollId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrolledIn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrolledInExists(enrolledIn.EnrollId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", enrolledIn.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", enrolledIn.StudentId);
            return View(enrolledIn);
        }

        // GET: EnrolledIns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrolledIn = await _context.EnrolledIn
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EnrollId == id);
            if (enrolledIn == null)
            {
                return NotFound();
            }

            return View(enrolledIn);
        }

        // POST: EnrolledIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrolledIn = await _context.EnrolledIn.FindAsync(id);
            _context.EnrolledIn.Remove(enrolledIn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrolledInExists(int id)
        {
            return _context.EnrolledIn.Any(e => e.EnrollId == id);
        }
    }
}
