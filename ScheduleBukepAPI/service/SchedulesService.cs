﻿using System;
using System.Collections.Generic;
using ScheduleBukepAPI.domain;
using ScheduleBukepAPI.service.paremeters;

namespace ScheduleBukepAPI.service
{
    public class SchedulesService : BaseService, ISchedulesService
    {
        private readonly ParameterBuilder _parameterBuilder = new ParameterBuilder();

        public IList<Lesson> GetGroupLessons(int idsSheduleGroup, DateTime dateFrom, DateTime dateTo)
        {
            IDictionary<string, string> parameters = _parameterBuilder
                .SetParameter(ParameterNameForApi.DateFrom, dateFrom)
                .SetParameter(ParameterNameForApi.DateTo, dateTo)
                .Build();
            string json = ExecutePost(MethodApi.GetGroupLessons, parameters, idsSheduleGroup.ToString());
            return ConvertToList<Lesson>(json);
        }

        public IList<Lesson> GetTeacherLessons(int idTeacher, DateTime dateFrom, DateTime dateTo)
        {
            IDictionary<string, string> parameters = _parameterBuilder
                .SetParameter(ParameterNameForApi.IdTeacher, idTeacher)
                .SetParameter(ParameterNameForApi.DateFrom, dateFrom)
                .SetParameter(ParameterNameForApi.DateTo, dateTo)
                .Build();

            string json = ExecuteGet(MethodApi.GetTeacherLessons, parameters);
            return ConvertToList<Lesson>(json);
        }
    }
}