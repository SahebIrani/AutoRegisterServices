﻿namespace AutoRegisterServices.Application
{
    public interface IResultConverter
    {
        T Map<T>(object source);
    }
}
