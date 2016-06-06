using System.Collections.Generic;
using PickANumber.Service.Interface;
using PickANumber.Data.Interface;
using PickANumber.Data.Model;

namespace PickANumber.Service.Service
{
    public class Game : IGame
    {
        #region Private Variables

        private IChildRepository _childRepository;
        private IFinder _finder;
        private List<Child> children;

        #endregion

        public Game(IChildRepository childRepository, IFinder finder)
        {
            _childRepository = childRepository;
            _finder = finder;
        }

        public void CreateGame(int playerCount)
        {
            children = _childRepository.GetSetOfChildren(playerCount);
        }

        public void Start(int luckyNumber)
        {
            while(children.Count > 0)
            {
                var currPos = _finder.FindSelectedPosition(children.Count, luckyNumber);
                children.RemoveAt(currPos);
            }
        }
    }
}
