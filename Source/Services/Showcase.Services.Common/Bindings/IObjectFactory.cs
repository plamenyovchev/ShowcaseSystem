﻿namespace Showcase.Services.Common.Bindings
{
    using System;

    using Showcase.Services.Common;

    public interface IObjectFactory : IService
    {
        T GetInstance<T>();

        object GetInstance(Type type);

        T TryGetInstance<T>();

        object TryGetInstance(Type type);
    }
}