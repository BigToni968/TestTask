namespace Game
{
    public interface IPointsCallback
    {
        public delegate void DelegatePoints(int points);
        public event DelegatePoints OnPointsCallback;

        public delegate int DelegateTotalPoints();
        public event DelegateTotalPoints OnTotalPointsCallback;
    }
}