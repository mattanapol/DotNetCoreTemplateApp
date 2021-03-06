﻿using System;
using AutoMapper;

namespace TemplateApp.Common.AutoMapper
{
    public sealed class AutoMapperConfig
    {
        /// <summary>
        /// Initialsies a new instance of <see cref="AutoMapperConfig"/>
        /// </summary>
        private AutoMapperConfig()
        {

        }

        /// <summary>
        /// Registers all mapping globally
        /// </summary>
        public static void RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            //config.AssertConfigurationIsValid();
            IMapper mapper = config.CreateMapper();
            AutoMapperProvider.SetMapper(mapper);
        }
    }
}
