using DataLayer.Repository.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ModelLayer;
using ModelLayer.VM;

namespace odevCoreUOF.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SiparisController : Controller
    {
        public readonly IUnityOfWork _unityOfWork;
        public SiparisController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Siparis> sList = _unityOfWork.Siparis.GetAll(null, "Musteri,OdemeYontem,KargoSirketleri,Urun,SiparisDurum");
            return View(sList);
        }
        public IActionResult Crup(int? id)
        {
           
            SiparisVM siparisVM = new SiparisVM()
            {
                Siparis = new Siparis(),
                MusteriList = _unityOfWork.Musteri.GetAll().Select(m => new SelectListItem
                {
                    Text = m.ad,
                    Value = m.musteriID.ToString()
                }),
                OdemeYontemList = _unityOfWork.OdemeYontem.GetAll().Select(a => new SelectListItem
                {
                    Text = a.ad,
                    Value = a.odemeYontemID.ToString()
                }),
                KargoSirketList = _unityOfWork.KargoSirket.GetAll().Select(a => new SelectListItem
                {
                    Text = a.ad,
                    Value = a.kargoSirketID.ToString()
                }),
                SiparisDurumList = _unityOfWork.SiparisDurum.GetAll().Select(a => new SelectListItem
                {
                    Text = a.ad,
                    Value = a.siparisDurumID.ToString()
                }),
                UrunList = _unityOfWork.Urun.GetAll().Select(a => new SelectListItem
                {
                    Text = a.ad,
                    Value = a.urunID.ToString()
                })
            };
            if (id <= 0 || id == null)
            {
                return View(siparisVM);
            }
            siparisVM.Siparis = _unityOfWork.Siparis.getById(m => m.siparisID == id);
            if (id <= 0 || id == null)
            {
                return View(siparisVM);
            }
            return View(siparisVM);
        }
        [HttpPost]
        public IActionResult Crup(SiparisVM siparisVM)
        {
            if (siparisVM.Siparis.siparisID<=0)
            {
                _unityOfWork.Siparis.Add(siparisVM.Siparis);
            }
            else
            {
                _unityOfWork.Siparis.Update(siparisVM.Siparis);
            }
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _unityOfWork.Siparis.Remove(_unityOfWork.Siparis.getById(x => x.siparisID == id));
            _unityOfWork.save();
            return RedirectToAction("Index");
        }
    }
}
