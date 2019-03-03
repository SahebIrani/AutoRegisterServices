namespace AutoRegisterServices.Service
{

    public class GenericThing<T> : IThing<T>
    {
        public GenericThing() => GetName = typeof(T).Name;
        public string GetName { get; }
    }
}
