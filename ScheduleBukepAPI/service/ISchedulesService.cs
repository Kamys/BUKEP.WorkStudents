﻿using System.Collections.Generic;
using ScheduleBukepAPI.domain;

namespace ScheduleBukepAPI.service
{
    public interface ISchedulesService
    {
        IList<GroupLesson> GetGroupLessons(string idsSheduleGroup, string dateFrom, string dateTo);
        //TODO: List заменить на IList      
        List<GroupLesson> GetTeacherLessons(string idTeacher, string dateFrom, string dateTo);
    }
}