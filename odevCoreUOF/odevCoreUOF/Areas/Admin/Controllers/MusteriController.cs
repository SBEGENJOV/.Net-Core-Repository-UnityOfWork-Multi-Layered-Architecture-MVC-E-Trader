using DataLayer.Repository;
using DataLayer.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace odevCoreUOF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MusteriController : Controller
    {
        private readonly IUnityOfWork _unityOfWork;
        public MusteriController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public IActionResult Index()    
        {
            IEnumerable<Musteri> mList = _unityOfWork.Musteri.GetAll();
            return View(mList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Musteri musteri)
        {
            _unityOfWork.Musteri.Add(musteri);
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
           var deger = _unityOfWork.Musteri.getById(k=>k.musteriID==id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult Edit(Musteri musteri)
        {
            _unityOfWork.Musteri.Update(musteri);
            _unityOfWork.save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var deger=_unityOfWork.Musteri.getById(k=>k.musteriID == id);
            _unityOfWork.Musteri.Remove(deger);
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
    }
}
