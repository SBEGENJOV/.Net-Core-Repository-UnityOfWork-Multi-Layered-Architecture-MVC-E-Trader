using DataLayer.Repository;
using DataLayer.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;

namespace odevCoreUOF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OdemeYontemController : Controller
    {
        public readonly IUnityOfWork _unityOfWork;
        public OdemeYontemController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<OdemeYontem> sdList = _unityOfWork.OdemeYontem.GetAll();
            return View(sdList);
        }
        public IActionResult Crup(int? id = 0)
        {
            if (id <= 0 || id == null)
            {
                return View();
            }
            var deger = _unityOfWork.OdemeYontem.getById(m => m.odemeYontemID == id);
            if (id <= 0 || id == null)
            {
                return View();
            }
            return View(deger);
        }
        [HttpPost]
        public IActionResult Crup(OdemeYontem OdemeYontem)
        {
            if (OdemeYontem.odemeYontemID <= 0)
            {
                _unityOfWork.OdemeYontem.Add(OdemeYontem);
            }
            else
            {
                _unityOfWork.OdemeYontem.Update(OdemeYontem);
            }
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _unityOfWork.OdemeYontem.Remove(_unityOfWork.OdemeYontem.getById(x => x.odemeYontemID == id));
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
    }
}
