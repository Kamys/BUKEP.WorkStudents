﻿using System.Collections.Generic;
using ScheduleBukepAPI.helpers;
using ScheduleBukepAPI.service.paremeters;

namespace ScheduleBukepAPI.service
{
    public class BaseService
    {
        private readonly HttpRequstHelper _httpRequestHelper;
        private readonly JsonConvert _jsonConvert;

        public BaseService(HttpRequstHelper httpRequestHelper, JsonConvert jsonConvert)
        {
            _httpRequestHelper = httpRequestHelper;
            _jsonConvert = jsonConvert;
        }

        public BaseService() : this(new HttpRequstHelper(), new JsonConvert())
        {
        }

        protected List<T> ConvertToList<T>(string json)
        {
            return _jsonConvert.ConvertToList<T>(json);
        }

        protected T ConvertTo<T>(string json)
        {
            return _jsonConvert.ConvertTo<T>(json);
        }

        protected string ConvertToJson<T>(T dto)
        {
            return _jsonConvert.ConvertToJson(dto);
        }

        protected string ExecuteGet(MethodApi nameMethod, IDictionary<string, string> parameters)
        {
            var url = CreatorUrl.CreateUrl(nameMethod.ToString(), parameters);
            return _httpRequestHelper.ExecuteGet(url);
        }

        protected string ExecutePost(MethodApi nameMethod, IDictionary<string, string> parameters,
            IList<int> bodyForPost)
        {
            var url = CreatorUrl.CreateUrl(nameMethod.ToString(), parameters);
            return _httpRequestHelper.ExecutePost(url, bodyForPost);
        }
    }
}