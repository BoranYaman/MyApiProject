
namespace HotelProject.DataAccessLayer.Abstrack
{
    public interface IGenericDal1<T> where T : class
    {
        void Delete(T t);
        T GetById(int id);
        List<T> GetList();
        void Insert(T t);
        void Update(T t);
    }
}