﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using AnnisaCake.Web.Models;
using AutoMapper.Configuration;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.UI;
using AnnisaCake.Web.Controllers;
using AnnisaCake.Web.Models.ModelView;

namespace AnnisaCake.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            //container.GetInstance<ThemeProvider>();

            //Register your type for instance

            //container.Register<>
            //container.Register<IMapper, MapperProvider>();
            container.RegisterSingleton(() => GetMapper(container));
            container.Register<MvcApplication.MapperProvider>(); 

            //This is an extension method from the integration package
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);




        }
        private AutoMapper.IMapper GetMapper(Container container)
        {
            var mp = container.GetInstance<MapperProvider>();
            return mp.GetMapper();
        } 

        public class MapperProvider
        {
            private readonly Container _container;
            public MapperProvider(Container container)
            {
                _container = container;
            }

            public IMapper GetMapper()
            {
                var mce = new MapperConfigurationExpression();
                mce.ConstructServicesUsing(_container.GetInstance);
                mce.AddProfile(new SomeProfile());

                var mc = new MapperConfiguration(mce);

                IMapper m = new Mapper(mc, t => _container.GetInstance(t));

                return m;
            }
        }

        public class SomeProfile : Profile
        {
            public SomeProfile()
            {
                CreateMap<SP_GetMenuByRoleUser_Result, MenuTree>();
                CreateMap<ViewModel.pelanggan, pelanggan_tamp>();
                CreateMap<pelanggan_tamp, pelanggan>();
                CreateMap<role_user, role_user_view>();
            }
        }
    }
}
