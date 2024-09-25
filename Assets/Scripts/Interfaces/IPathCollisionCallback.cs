namespace Game
{
    public interface IPathCollisionCallback
    {
        public delegate void DelegatePathCollision();
        public event DelegatePathCollision PathCollisionEnterCallback;
    }
}