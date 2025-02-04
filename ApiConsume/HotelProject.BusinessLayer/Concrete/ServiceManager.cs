using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstrack;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace HotelProject.BusinessLayer.Concrete
{

    public class ServiceManager : IServiceService
    {
        private readonly IServicesDal _serviceDal;

        public ServiceManager(IServicesDal serviceDal)
        {
            _serviceDal = serviceDal ?? throw new ArgumentNullException(nameof(serviceDal));
        }
        public void TDelete(Service t)
        {
            _serviceDal.Delete(t);
        }
        public Service TGetById(int id)
        {
            return _serviceDal.GetById(id);
        }
        public List<Service> TGetList()
        {
            return _serviceDal.GetList();
        }
        public void TInsert(Service t)
        {
            _serviceDal.Insert(t);
        }
        public void TUpdate(Service t)
        {
            _serviceDal.Update(t);

        }
    }
}
