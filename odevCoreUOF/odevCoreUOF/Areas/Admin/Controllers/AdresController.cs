using DataLayer;
using DataLayer.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelLayer;
using ModelLayer.VM;

namespace odevCoreUOF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdresController : Controller
    {
        public readonly IUnityOfWork _unityOfWork;
        public AdresController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Adresler> aList = _unityOfWork.Adres.GetAll(null, "Musteri").ToList();
            return View(aList);
        }
        public IActionResult Crup(int? id = 0)
        {
            AdreslerVM adreslerVM = new()
            {
                Adresler = new(),
                MusteriList = _unityOfWork.Musteri.GetAll().Select(m => new SelectListItem
                {
                    Text = m.ad,
                    Value = m.musteriID.ToString()
                })
            };
            if (id <= 0 || id == null)
            {
                return View(adreslerVM);
            }
            adreslerVM.Adresler = _unityOfWork.Adres.getById(m => m.adresID == id);
            if (id <= 0 || id == null)
            {
                return View(adreslerVM);
            }
            return View(adreslerVM);
        }
        [HttpPost]
        public IActionResult Crup(AdreslerVM adreslerVM)
        {
            if (adreslerVM.Adresler.adresID<=0)
            {
                _unityOfWork.Adres.Add(adreslerVM.Adresler);
            }
            else
            {
                _unityOfWork.Adres.Update(adreslerVM.Adresler);
            }
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _unityOfWork.Adres.Remove(_unityOfWork.Adres.getById(x => x.adresID == id));
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
    }
}
