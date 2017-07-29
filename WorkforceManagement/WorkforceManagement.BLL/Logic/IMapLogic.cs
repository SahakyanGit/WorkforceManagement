﻿using System.Collections.Generic;
using WorkforceManagement.DAL.DataProvider;

namespace WorkforceManagement.BLL.Logic
{
    public interface IMapLogic<TSource, TDestination> where TSource : class where TDestination : class
    {
        IEnumerable<TDestination> MapEntity();

        TSource MapEntitySingle(TDestination entity);
    }
}