using System;
using BrewCrewDB.Models;
using System.Collections.Generic;

namespace BrewCrewLib
{
    public interface IService<T>
    {
        void AddResource(T entity);
        void DeleteResource(T entity);
        T GetResource(string id);
        List<T> GetAllResources();
        List<T> GetAllResources(string identifier);
        void UpdateResource(T entity);
    }
}
