namespace AutoRegisterServices.Services
{
    // ------------------------Default Interface Methods---------------------------

    //public interface IGenericFilter<T>
    //{
    //    IEnumerable<T> ApplyFilter(IEnumerable<T> collection, Func<T, bool> predicate)
    //    {
    //        foreach (var item in collection)
    //        {
    //            if (predicate(item))
    //            {
    //                yield return item;
    //            }
    //        }
    //    }
    //}

    //public interface IDummyFilter<T> : IGenericFilter<T>
    //{
    //    IEnumerable<T> IGenericFilter<T>.ApplyFilter(IEnumerable<T> collection, Func<T, bool> predicate)
    //    {
    //        return default;
    //    }
    //}

    //public class GenericFilterExample : IGenericFilter<int>, IDummyFilter<int>
    //{
    //}

    //IGenericFilter<int> genericFilter = new GenericFilterExample();
    //var result = genericFilter.ApplyFilter(new Collection<int>() { 1, 2, 3 }, x => x > 1);


    //interface IAbstractInterface
    //{
    //    abstract void M1() { }
    //    abstract private void M2() { }
    //    abstract static void M3() { }
    //    static extern void M4() { }
    //}

    //class TestMe : IAbstractInterface
    //{
    //    void IAbstractInterface.M1() { }
    //    void IAbstractInterface.M2() { }
    //    void IAbstractInterface.M3() { }
    //    void IAbstractInterface.M4() { }
    //}
}
