using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Tz.Region;

namespace Tz.Common
{
    public interface IDataModelService<T> where T : IRegionalConfiguration
    {
        string GetCountryRegion();
        void SaveChanges();
        void ReleaseModel();
    }

    public static class DataModelServiceExtension
    {
        public static DbSet GetDbSet<T>(this IDataModelService<IRegionalConfiguration> model) where T: class
        {
            var dbContext = model as DbContext;
            var dbSet = dbContext.Set<T>();

            if(dbSet==null)
            {
                throw new ApplicationException(string.Format("The DbSet of Type {0} is not available in the DbContext ({1})", typeof(T),dbContext.GetType().Name));
            }

            return dbSet;
        }

        public static void ReleaseModel(this IDataModelService<IRegionalConfiguration> model)
        {
            var dbContext = model as DbContext;

            if(dbContext==null)
            {
                throw new Exception("There are no db context to dispose");
            }
            dbContext.Dispose();
        }

        //public static TResult UsingModel<TModel, TResult>(this IDataModelService svc, Func<TModel, TResult> func) where TModel : DbContext
        //{
            
        //    TModel model = svc.GetModel<TModel>();
        //    TResult rs;
        //    try
        //    {
        //        rs = func(model);
        //    }
        //    finally
        //    {
        //        svc.ReleaseModel(model);
        //    }

        //    return rs;
        //}

        //public static void UsingModel<TModel>(this IDataModelService svc, Action<TModel> action) where TModel : DbContext
        //{
        //    TModel model = svc.GetModel<TModel>();
          
        //    try
        //    {
        //        action(model);
        //    }
        //    finally
        //    {
        //        svc.ReleaseModel(model);
        //    }

           
        //}
    }
}
