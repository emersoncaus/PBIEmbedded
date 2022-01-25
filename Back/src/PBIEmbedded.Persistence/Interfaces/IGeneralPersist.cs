using System.Threading.Tasks;
using PBIEmbedded.Domain;

namespace PBIEmbedded.Persistence.Interface
{
    public interface IGeneralPersist
    {
         void Add<T> (T entity) where T: class;
         void Update<T> (T entity) where T: class;
         void Delete<T> (T entity) where T: class;
         void DeleteRange<T> (T[] entity) where T: class;
         Task<bool> SaveChangesAsync();
    }
}