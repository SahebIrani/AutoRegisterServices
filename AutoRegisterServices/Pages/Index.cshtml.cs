using AutoRegisterServices.Services;
using AutoRegisterServices.Services2;

using Microsoft.AspNetCore.Mvc.RazorPages;

using OtherAssemblyServices;

using OtherAssemblyServices2;

namespace AutoRegisterServices.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Service2 Service2;
        private readonly Service3 Service3;
        private readonly IService Service;
        private readonly IFoo Foo;
        private readonly IBar Bar;
        private readonly INewService NewService;
        private readonly IOtherService OtherService;
        private readonly IOtherService2 OtherService2;

        public IndexModel(Service2 service2, Service3 service3,
                           IService service, IFoo foo, IBar bar,
                           INewService newService, IOtherService otherService, IOtherService2 otherService2)
        {
            Service2 = service2 ?? throw new System.ArgumentNullException(nameof(service2));
            Service3 = service3 ?? throw new System.ArgumentNullException(nameof(service3));
            Service = service ?? throw new System.ArgumentNullException(nameof(service));
            Foo = foo ?? throw new System.ArgumentNullException(nameof(foo));
            Bar = bar ?? throw new System.ArgumentNullException(nameof(bar));
            NewService = newService ?? throw new System.ArgumentNullException(nameof(newService));
            OtherService = otherService ?? throw new System.ArgumentNullException(nameof(otherService));
            OtherService2 = otherService2 ?? throw new System.ArgumentNullException(nameof(otherService2));
        }

        public string[] ResultListString { get; set; }

        public void OnGet()
        {
            string servicesResult = $"{Service2.ReturnValue(nameof(Service2))}," +
                                         $"{Service3.ReturnValue(nameof(Service3))}," +
                                         $"{Service.ReturnValue(nameof(Service))}," +
                                         $"{Foo.ReturnValue(nameof(Foo))}," +
                                         $"{Bar.ReturnValue(nameof(Bar))}," +
                                         $"{NewService.ReturnValue(nameof(NewService))}," +
                                         $"{OtherService.ReturnValue(nameof(OtherService))}," +
                                         $"{OtherService2.ReturnValue(nameof(OtherService2))}"
            ;
            var result = servicesResult.Split(",");
            ResultListString = result;
        }
    }
}
