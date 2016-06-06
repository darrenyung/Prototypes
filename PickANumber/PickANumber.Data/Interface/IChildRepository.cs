using PickANumber.Data.Model;
using System.Collections.Generic;

namespace PickANumber.Data.Interface
{
    public interface IChildRepository
    {
        List<Child> GetSetOfChildren(int number);
    }
}
