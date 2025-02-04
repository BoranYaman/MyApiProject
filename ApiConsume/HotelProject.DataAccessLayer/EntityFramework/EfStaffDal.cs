using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Abstrack;
using HotelProject.DataAccessLayer.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>,IStaffDal
    {
        public EfStaffDal(Context contex): base(contex) 
        {
            
        }
    }
}
