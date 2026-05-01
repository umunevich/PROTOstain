namespace Proto.Scripts.Item
{
    public interface IItem
    {
        float Cost();
        float Volume();
    }
    public class Item : IItem
    {
        public float Cost() => _cost;
        public float Volume() => _volume;
        
        private float _cost;
        private float _volume;
    }
}
