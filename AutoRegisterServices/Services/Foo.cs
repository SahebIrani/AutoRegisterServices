namespace AutoRegisterServices.Services
{
    //[ServiceDescriptor(serviceType: typeof(Foo), lifetime: ServiceLifetime.Transient)]
    public class Foo : IFoo, IBar
    {
        public string ReturnValue(string str) => str;
    }
}
