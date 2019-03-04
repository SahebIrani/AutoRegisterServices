using System;

namespace AutoRegisterServices.Service
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public int Get() => new Random().Next();
    }
}
