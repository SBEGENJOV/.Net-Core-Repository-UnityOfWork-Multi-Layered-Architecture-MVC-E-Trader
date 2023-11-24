using DataLayer.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace odevCoreUOF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KargoSirketController : Controller
    {
        public readonly IUnityOfWork _unityOfWork;
        public KargoSirketController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<KargoSirketleri> sdList = _unityOfWork.KargoSirket.GetAll();
            return View(sdList);
        }
        public IActionResult Crup(int? id = 0)
        {
            if (id <= 0 || id == null)
            {
                return View();
            }
            var deger = _unityOfWork.KargoSirket.getById(m => m.kargoSirketID == id);
            if (id <= 0 || id == null)
            {
                return View();
            }
            return View(deger);
        }
        [HttpPost]
        public IActionResult Crup(KargoSirketleri KargoSirketleri)
        {
            if (KargoSirketleri.kargoSirketID <= 0)
            {
                _unityOfWork.KargoSirket.Add(KargoSirketleri);
            }
            else
            {
                _unityOfWork.KargoSirket.Update(KargoSirketleri);
            }
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _unityOfWork.KargoSirket.Remove(_unityOfWork.KargoSirket.getById(x => x.kargoSirketID == id));
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
    }
}
