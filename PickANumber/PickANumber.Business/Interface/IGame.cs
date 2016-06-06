namespace PickANumber.Service.Interface
{
    public interface IGame
    {
        void CreateGame(int playerCount);

        void Start(int luckyNumber);
    }
}
