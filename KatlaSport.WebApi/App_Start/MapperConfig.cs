using AutoMapper;
using System;
using System.Linq;

namespace KatlaSport.WebApi
{
    /// <summary>
    /// Represents a mapper configuration.
    /// </summary>
    public static class MapperConfig
    {
        /// <summary>
        /// Configures a mapper with static configuration.
        /// </summary>
        public static void Configure()
        {
#pragma warning disable CS0618 // Тип или член устарел
            Mapper.Initialize(cfg =>
            {
                var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("KatlaSport")).ToArray();
#pragma warning disable CS0618 // Тип или член устарел
                cfg.AddProfiles(assemblies);
#pragma warning restore CS0618 // Тип или член устарел
            });
#pragma warning restore CS0618 // Тип или член устарел
        }
    }
}
