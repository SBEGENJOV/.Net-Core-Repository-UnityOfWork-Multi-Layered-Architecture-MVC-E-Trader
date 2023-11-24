using DataLayer.Repository.IRepo;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class SiparisDurumRepository:Repository<siparisDurum>,ISiparisDurum
    {
        private ApplicationDbContext _context;
        public SiparisDurumRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
