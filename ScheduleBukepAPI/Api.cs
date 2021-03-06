﻿using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleBukepAPI.domain;
using ScheduleBukepAPI.service;

namespace ScheduleBukepAPI
{
    /// <summary>
    /// Нужен для упрощения работы с IFacultiesService и ISchedulesService.
    /// </summary>
    public class Api
    {
        private static IFacultiesService _facultiesService;
        private static ISchedulesService _schedulesService;

        /// <summary>
        /// Формат даты для api.
        /// </summary>
        public const string DateTimeFormat = "yyyy-MM-dd";

        //TODO: написать метод который бы получал учебный год.
        private const int Year = 2017;

        private const int IdFilial = 1000;

        /// <summary>
        /// Создать Api с переданными сервисами.
        /// </summary>
        /// <param name="facultiesService"></param>
        /// <param name="schedulesService"></param>
        public Api(IFacultiesService facultiesService, ISchedulesService schedulesService)
        {
            _facultiesService = facultiesService;
            _schedulesService = schedulesService;
        }

        /// <summary>
        /// Создать Api с стандартными сервисами.
        /// </summary>
        public Api() : this(new FacultiesService(), new SchedulesService())
        {
        }


        /// <summary>
        /// Факультеты
        /// </summary>
        /// <returns>Факультеты</returns>
        public IList<Faculty> GetFaculties()
        {
            return _facultiesService.GetFaculties(Year, IdFilial);
        }

        /// <summary>
        /// Специальности
        /// </summary>
        /// <param name="idFaculty">Идентификатор факультета</param>
        /// <returns>Специальности</returns>
        public IList<Specialty> GetSpecialtys(int idFaculty)
        {
            return _facultiesService.GetSpecialtys(Year, IdFilial, idFaculty);
        }

        /// <summary>
        /// Курсы
        /// </summary>
        /// <param name="idFaculty">Идентификатор факультета</param>
        /// <param name="idsSpecialty">Список специальностей</param>
        /// <returns>Курсы</returns>
        public IList<Course> GetCourses(int idFaculty, IList<int> idsSpecialty)
        {
            return _facultiesService.GetCourses(Year, IdFilial, idFaculty, idsSpecialty);
        }

        /// <summary>
        /// Группы
        /// </summary>
        /// <param name="idFaculty">Идентификатор факультета</param>
        /// <param name="idsSpecialty">Список специальностей</param>
        /// <param name="idCourse">Идентификатор курса</param>
        /// <returns>Группы</returns>
        public IList<Group> GetGroups(int idFaculty, int idCourse, IList<int> idsSpecialty)
        {
            return _facultiesService.GetGroups(Year, IdFilial, idFaculty, idCourse, idsSpecialty);
        }
        
        /// <summary>
        /// Расписание для группы
        /// </summary>
        /// <param name="idsSheduleGroup">Идентификатор группы расписания</param>
        /// <param name="dateFrom">Дата начала</param>
        /// <param name="dateTo">Дата окончания</param>
        /// <returns>Расписание для группы</returns>
        public IList<Lesson> GetGroupLessons(IList<int> idsSheduleGroup, DateTime dateFrom, DateTime dateTo)
        {
            return _schedulesService.GetGroupLessons(idsSheduleGroup, dateFrom, dateTo);
        }

        /// <summary>
        /// Кафедры
        /// </summary>
        /// <returns>Кафедры</returns>
        public List<Pulpit> GetPulpits()
        {
            return _facultiesService.GetPulpits(Year, IdFilial);
        }
        
        /// <summary>
        /// Преподаватели
        /// </summary>
        /// <param name="idPulpit">Идентификатор кафедры</param>
        /// <returns>Преподаватели</returns>
        public List<Teacher> GetTeacher(int idPulpit)
        {
            return _facultiesService.GetTeacher(Year, idPulpit);
        }

        /// <summary>
        /// Расписание для преподавателя
        /// </summary>
        /// <param name="idsTeacher">Идентификатор преподавателя</param>
        /// <param name="dateFrom">Дата начала</param>
        /// <param name="dateTo">Дата окончания</param>
        /// <returns>Расписание для преподавателя</returns>
        public IList<Lesson> GetTeacherLessons(IList<int> idsTeacher, DateTime dateFrom, DateTime dateTo)
        {
            return _schedulesService.GetTeacherLessons(idsTeacher, dateFrom, dateTo);
        }

        //TODO: Move
        /// <summary>
        /// Нужен для конвертирования списка id в string.
        /// </summary>
        /// <param name="ids">Список id</param>
        /// <returns>Список ids в формате string разделенный запятыми. Пример: [34,345,60]</returns>
        public static string ConvertIdsToString(IList<int> ids)
        {
            if (ids == null) throw new ArgumentException("Parameter ids cannot be null.");

            var result = string.Join(",", ids.ToArray());
            return $"[{result}]";
        }
    }
}