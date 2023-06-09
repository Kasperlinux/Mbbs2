using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mbbs2.Data;
using Mbbs2.Models;

namespace Mbbs2.Controllers
{
    public class ApplicantsMbbsController : Controller
    {
        private readonly DhsMagacousesContext _context;

        public ApplicantsMbbsController(DhsMagacousesContext context)
        {
            _context = context;
        }

        // GET: ApplicantsMbbs
        public async Task<IActionResult> Index()
        {
              return _context.ApplicantsMbbs != null ? 
                          View(await _context.ApplicantsMbbs.ToListAsync()) :
                          Problem("Entity set 'DhsMagacousesContext.ApplicantsMbbs'  is null.");
        }

        // GET: ApplicantsMbbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ApplicantsMbbs == null)
            {
                return NotFound();
            }

            var applicantsMbb = await _context.ApplicantsMbbs
                .FirstOrDefaultAsync(m => m.ApplicantId == id);
            if (applicantsMbb == null)
            {
                return NotFound();
            }

            return View(applicantsMbb);
        }

        // GET: ApplicantsMbbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicantsMbbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicantId,AplicantName,Dob,PermanentState,PermanentDistrict,PermanentBlock,PermanentVillage,PermanentAddress,PresentState,PresentDistrict,PresentBlock,PresentVillage,PresentAddress,EMail,Mobile,Nationality,Category,Gender,Religion,PassportPhoto,PrCetificate,CategoryCertificate,AgeProof,Marksheet,CharacterCertificate,GuardianName,GuardianOccupation,GuardianOfficeName,GuardianOfficeAddress,GuardianEmployerCertificate,MarksPhysicsTheory,MarksPhysicsPractical,FullmarksPhysics,MarksChemistryTheory,MarksChemistryPractical,FullmarksChemistry,MarksBiologyTheory,MarksBiologyPractical,FullmarksBiology,MarksEnglishTheory,MarksEnglishPractical,FullmarksEnglish,PercentageXii,PercentagePcbXii,PercentagePcbeXii,NeetUgCurrentScore,NeetUgScoresheet,ApplicationStatus,Remarks,DataEntryTimestamp,DataEntryIp,ModifiedBy,ModifiedTimestamp,ModifiedIp,AgeAsOnCutOffDate")] ApplicantsMbb applicantsMbb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicantsMbb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicantsMbb);
        }

        // GET: ApplicantsMbbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ApplicantsMbbs == null)
            {
                return NotFound();
            }

            var applicantsMbb = await _context.ApplicantsMbbs.FindAsync(id);
            if (applicantsMbb == null)
            {
                return NotFound();
            }
            return View(applicantsMbb);
        }

        // POST: ApplicantsMbbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicantId,AplicantName,Dob,PermanentState,PermanentDistrict,PermanentBlock,PermanentVillage,PermanentAddress,PresentState,PresentDistrict,PresentBlock,PresentVillage,PresentAddress,EMail,Mobile,Nationality,Category,Gender,Religion,PassportPhoto,PrCetificate,CategoryCertificate,AgeProof,Marksheet,CharacterCertificate,GuardianName,GuardianOccupation,GuardianOfficeName,GuardianOfficeAddress,GuardianEmployerCertificate,MarksPhysicsTheory,MarksPhysicsPractical,FullmarksPhysics,MarksChemistryTheory,MarksChemistryPractical,FullmarksChemistry,MarksBiologyTheory,MarksBiologyPractical,FullmarksBiology,MarksEnglishTheory,MarksEnglishPractical,FullmarksEnglish,PercentageXii,PercentagePcbXii,PercentagePcbeXii,NeetUgCurrentScore,NeetUgScoresheet,ApplicationStatus,Remarks,DataEntryTimestamp,DataEntryIp,ModifiedBy,ModifiedTimestamp,ModifiedIp,AgeAsOnCutOffDate")] ApplicantsMbb applicantsMbb)
        {
            if (id != applicantsMbb.ApplicantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicantsMbb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicantsMbbExists(applicantsMbb.ApplicantId))
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
            return View(applicantsMbb);
        }

        // GET: ApplicantsMbbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ApplicantsMbbs == null)
            {
                return NotFound();
            }

            var applicantsMbb = await _context.ApplicantsMbbs
                .FirstOrDefaultAsync(m => m.ApplicantId == id);
            if (applicantsMbb == null)
            {
                return NotFound();
            }

            return View(applicantsMbb);
        }

        // POST: ApplicantsMbbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ApplicantsMbbs == null)
            {
                return Problem("Entity set 'DhsMagacousesContext.ApplicantsMbbs'  is null.");
            }
            var applicantsMbb = await _context.ApplicantsMbbs.FindAsync(id);
            if (applicantsMbb != null)
            {
                _context.ApplicantsMbbs.Remove(applicantsMbb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicantsMbbExists(int id)
        {
          return (_context.ApplicantsMbbs?.Any(e => e.ApplicantId == id)).GetValueOrDefault();
        }
    }
}
