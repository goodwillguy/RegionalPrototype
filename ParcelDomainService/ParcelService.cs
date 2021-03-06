﻿using Tz.Parcel.Common.Factory;
using Tz.Parcel.Common.Interface;
using Tz.Parcel.Common.Service;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Tz.Common;
using Tz.Region;

namespace ParcelService
{
    public class ParcelService : IParcelService
    {
        private IRegionalFactory _domianFactory;
        Container _container = Bootstrapper.Container;
        public ParcelService()
        {
            _domianFactory = _container.GetInstance(typeof(IRegionalFactory)) as IRegionalFactory;

        }



        void InitialiseComponents()
        {

        }


        public void CreateAndReservceParcel(string region)
        {

        }

        public string GetFirstParcel(string region)
        {
            return "test";
        }

        public bool PickupParcel(string region, string parcelData)
        {
            bool result;
            var singaporetype = _domianFactory.GetType<IRegionalParcelDomainService<IRegionalConfiguration>>(parcelData);

            var singaporeInstance = _container.GetInstance(singaporetype) as IRegionalParcelDomainService<IRegionalConfiguration>;

            result = singaporeInstance.PickupParcel(region, parcelData);

            return result;

        }
    }
}