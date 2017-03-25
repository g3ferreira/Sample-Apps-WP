using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8pos.Models.ModelsInterface
{
    public interface IModelCrud<T>
    {
        void insert(T entidade);
        void update(T entidade);
        void delete(T entidade);
        T getById(int Id);
        IList<T> get();
    }
}
