using DataLayer.Repository.IRepo;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class KategoryRepository:Repository<Kategori>,IKategory
    {
        private ApplicationDbContext _context;
        public KategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
