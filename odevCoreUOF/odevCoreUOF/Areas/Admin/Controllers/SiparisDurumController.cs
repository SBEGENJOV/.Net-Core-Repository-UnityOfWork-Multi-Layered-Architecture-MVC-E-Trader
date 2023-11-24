using DataLayer.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelLayer;
using ModelLayer.VM;

namespace odevCoreUOF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SiparisDurumController : Controller
    {
        public readonly IUnityOfWork _unityOfWork;
        public SiparisDurumController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<siparisDurum> sdList = _unityOfWork.SiparisDurum.GetAll();
            return View(sdList);
        }
        public IActionResult Crup(int? id = 0)
        {
            if (id <= 0 || id == null)
            {
                return View();
            }
            var deger = _unityOfWork.SiparisDurum.getById(m => m.siparisDurumID == id);
            if (id <= 0 || id == null)
            {
                return View();
            }
            return View(deger);
        }
        [HttpPost]
        public IActionResult Crup(siparisDurum siparisDurum)
        {
            if (siparisDurum.siparisDurumID <= 0)
            {
                _unityOfWork.SiparisDurum.Add(siparisDurum);
            }
            else
            {
                _unityOfWork.SiparisDurum.Update(siparisDurum);
            }
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _unityOfWork.SiparisDurum.Remove(_unityOfWork.SiparisDurum.getById(x => x.siparisDurumID == id));
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
    }
}
