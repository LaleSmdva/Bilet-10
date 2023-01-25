using Business.Utilities;
using Business.ViewModels.TeamMember;
using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Test.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IWebHostEnvironment _env;

        public TeamMemberController(AppDbContext context, ITeamMemberRepository teamMemberRepository, IWebHostEnvironment env)
        {
            _context = context;
            _teamMemberRepository = teamMemberRepository;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_context.TeamMembers);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var model = await _teamMemberRepository.GetByIdAsync(id);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTeamMemberVM createTeamMemberVM)
        {
            if (!ModelState.IsValid) return View(createTeamMemberVM);
            if (createTeamMemberVM.Image.CheckFileSize(100))
            {
                ModelState.AddModelError("Image", "Size must be less than 100");
                return View(createTeamMemberVM);
            }
            var fileName = await createTeamMemberVM.Image.CopyFileAsync(_env.WebRootPath, "assets", "img", "team");
            TeamMember teamMember = new()
            {
                Name = createTeamMemberVM.Name,
                Position = createTeamMemberVM.Position,
                Image = fileName
            };
            await _teamMemberRepository.CreateAsync(teamMember);
            await _teamMemberRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var model=await _teamMemberRepository.GetByIdAsync(id);
            UpdateTeamMemberVM updateTeamMemberVM = new()
            {
                Name=model.Name,
                Position=model.Position
            };
            return View(updateTeamMemberVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int id,UpdateTeamMemberVM updateTeamMemberVM)
        {
            var model=await _teamMemberRepository.GetByIdAsync(id);
            var fileName = await updateTeamMemberVM.Image.CopyFileAsync(_env.WebRootPath, "assets", "img", "team");

            model.Name = updateTeamMemberVM.Name;
            model.Position = updateTeamMemberVM.Position;
            model.Image = fileName;
            
            _teamMemberRepository.Update(model);
            await _teamMemberRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
