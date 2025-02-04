using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstrack;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace HotelProject.BusinessLayer.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal ?? throw new ArgumentNullException(nameof(staffDal));
        }

        public void TDelete(Staff t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t), "The staff object cannot be null.");

            _staffDal.Delete(t);
        }

        public Staff TGetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("The ID must be greater than zero.", nameof(id));

            var staff = _staffDal.GetById(id);
            if (staff == null)
                throw new InvalidOperationException($"Staff with ID {id} was not found.");

            return staff;
        }

        public List<Staff> TGetList()
        {
            var staffList = _staffDal.GetList();
            return staffList ?? new List<Staff>(); // Eğer null dönerse boş bir liste döndür.
        }

        public void TInsert(Staff t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t), "The staff object cannot be null.");

            _staffDal.Insert(t);
        }

        public void TUpdate(Staff t)
        {
            if (t == null)
                throw new ArgumentNullException(nameof(t), "The staff object cannot be null.");

            _staffDal.Update(t);
        }
    }
}
