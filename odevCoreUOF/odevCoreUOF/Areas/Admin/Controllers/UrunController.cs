using DataLayer.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelLayer;
using ModelLayer.VM;

namespace odevCoreUOF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UrunController : Controller
    {
        
        public readonly IUnityOfWork _unityOfWork;
        public UrunController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Urun> uList = _unityOfWork.Urun.GetAll(null, "Kategori").ToList();
            return View(uList);
        }
        public IActionResult Crup(int? id = 0)
        {
            UrunlerVM urunlerVM = new()
            {
                Urun = new(),
                KategoriList = _unityOfWork.Kategori.GetAll().Select(m => new SelectListItem
                {
                    Text = m.ad,
                    Value = m.kategoriID.ToString()
                })
            };
            if (id <= 0 || id == null)
            {
                return View(urunlerVM);
            }
            urunlerVM.Urun = _unityOfWork.Urun.getById(m => m.urunID == id);
            if (id <= 0 || id == null)
            {
                return View(urunlerVM);
            }
            return View(urunlerVM);
        }
        [HttpPost]
        public IActionResult Crup(UrunlerVM urunlerVM)
        {
            if (urunlerVM.Urun.urunID <= 0)
            {
                _unityOfWork.Urun.Add(urunlerVM.Urun);
            }
            else
            {
                _unityOfWork.Urun.Update(urunlerVM.Urun);
            }
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _unityOfWork.Urun.Remove(_unityOfWork.Urun.getById(x => x.urunID == id));
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
    }
}
