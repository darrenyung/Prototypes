using PickANumber.Data.Interface;
using System.Collections.Generic;
using PickANumber.Data.Model;

namespace PickANumber.Data.Repository
{
    public class ChildRepository : IChildRepository
    {
        public List<Child> GetSetOfChildren(int number)
        {
            var children = new List<Child>();

            for (int i = 0; i < number; i++)
                children.Add(new Child { ChildId = i + 1 });

            return children;
        }
    }
}
