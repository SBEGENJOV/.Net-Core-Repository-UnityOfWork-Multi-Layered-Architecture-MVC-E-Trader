using DataLayer.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace odevCoreUOF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KategoriController : Controller
    {
        
        private readonly IUnityOfWork _unityOfWork;
        public KategoriController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Kategori> kategoriList = _unityOfWork.Kategori.GetAll();
            return View(kategoriList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Kategori kategori)
        {
            _unityOfWork.Kategori.Add(kategori);
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var kategori = _unityOfWork.Kategori.getById(k => k.kategoriID == id);
            return View(kategori);
        }
        [HttpPost]
        public IActionResult Edit(Kategori kategori)
        {
            _unityOfWork.Kategori.Update(kategori);
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var kategori = _unityOfWork.Kategori.getById(k => k.kategoriID == id);
            _unityOfWork.Kategori.Remove(kategori);
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
    }
}
