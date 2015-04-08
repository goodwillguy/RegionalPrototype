using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Tz.Common
{
    public interface IDataModelService
    {
        string GetRegion();
        void SaveChanges();
        void ReleaseModel(DbContext model);
    }

    public static class DataModelServiceExtension
    {
        public static DbSet GetDbSet<T>(this IDataModelService svc) where T : DbContext
        {
            var dbContext=svc as DbContext;
            var dbSet = dbContext.Set<T>();

            if(dbSet==null)
            {
                throw new ApplicationException(string.Format("The DbSet of Type {0} is not available in the DbContext ({1})", typeof(T),dbContext.GetType().Name));
            }

            return dbSet;
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
