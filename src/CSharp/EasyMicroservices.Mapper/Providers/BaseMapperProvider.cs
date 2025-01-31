﻿using EasyMicroservices.Mapper.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EasyMicroservices.Mapper.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseMapperProvider : IMapperProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="uniqueRecordId"></param>
        /// <param name="language"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public TTo Map<TFrom, TTo>(TFrom fromObject, string uniqueRecordId = default, string language = default, params object[] parameters)
        {
            return Map<TTo>(fromObject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="uniqueRecordId"></param>
        /// <param name="language"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public abstract TTo Map<TTo>(object fromObject, string uniqueRecordId = default, string language = default, params object[] parameters);


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="uniqueRecordId"></param>
        /// <param name="language"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<TTo> MapSingleToList<TTo>(object fromObject, string uniqueRecordId = default, string language = default, params object[] parameters)
        {
            return new List<TTo>()
            {
                Map<TTo>(fromObject)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="uniqueRecordId"></param>
        /// <param name="language"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public TTo MapToFirst<TTo>(IEnumerable fromObject, string uniqueRecordId = default, string language = default, params object[] parameters)
        {
            if (fromObject == null)
                return default;
            var enumerator = fromObject.GetEnumerator();
            // check first
            if (!enumerator.MoveNext())
                return default;
            return Map<TTo>(enumerator.Current);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="uniqueRecordId"></param>
        /// <param name="language"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<TTo> MapToList<TTo>(IEnumerable fromObject, string uniqueRecordId = default, string language = default, params object[] parameters)
        {
            if (fromObject == null)
                return default;
            List<TTo> result = new List<TTo>();
            foreach (var item in fromObject)
            {
                result.Add(Map<TTo>(item));
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="uniqueRecordId"></param>
        /// <param name="language"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<TTo> MapAsync<TFrom, TTo>(TFrom fromObject = default, string uniqueRecordId = null, string language = null, params object[] parameters)
        {
            return Task.FromResult(Map<TFrom, TTo>(fromObject, uniqueRecordId, language, parameters));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="uniqueRecordId"></param>
        /// <param name="language"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual Task<TTo> MapAsync<TTo>(object fromObject, string uniqueRecordId = null, string language = null, params object[] parameters)
        {
            return Task.FromResult(Map<TTo>(fromObject, uniqueRecordId, language, parameters));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="uniqueRecordId"></param>
        /// <param name="language"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TTo>> MapSingleToListAsync<TTo>(object fromObject, string uniqueRecordId = null, string language = null, params object[] parameters)
        {
            return new List<TTo>()
            {
                await MapAsync<TTo>(fromObject)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="uniqueRecordId"></param>
        /// <param name="language"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<TTo> MapToFirstAsync<TTo>(IEnumerable fromObject, string uniqueRecordId = null, string language = null, params object[] parameters)
        {
            if (fromObject == null)
                return default;
            var enumerator = fromObject.GetEnumerator();
            // check first
            if (!enumerator.MoveNext())
                return default;
            return await MapAsync<TTo>(enumerator.Current);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="fromObject"></param>
        /// <param name="uniqueRecordId"></param>
        /// <param name="language"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<TTo>> MapToListAsync<TTo>(IEnumerable fromObject, string uniqueRecordId = null, string language = null, params object[] parameters)
        {
            if (fromObject == null)
                return default;
            List<TTo> result = new List<TTo>();
            foreach (var item in fromObject)
            {
                result.Add(await MapAsync<TTo>(item));
            }
            return result;
        }
    }
}
