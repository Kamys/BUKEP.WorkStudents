﻿using System.Collections.Generic;
using ScheduleBukepAPI.domain;
using ScheduleBukepAPI.helpers;
using ScheduleBukepAPI.service.paremeters;

namespace ScheduleBukepAPI.service
{
    public class FacultiesService : BaseService, IFacultiesService
    {
        private readonly ParameterConstructor _parameterConstructor = new ParameterConstructor();

        public List<Faculty> GetFaculties(int year, int idFilial)
        {
            IDictionary<string, string> parameters = _parameterConstructor
                .SetParameter(NameParameterForApi.Year, year)
                .SetParameter(NameParameterForApi.IdFilial, idFilial)
                .GetResults();
            string json = ExecuteGet(MethodApi.GetFaculties, parameters);
            return ConvertToList<Faculty>(json);
        }

        public List<Specialty> GetSpecialtys(int year, int idFilial, int idFaculty)
        {
            IDictionary<string, string> parameters = _parameterConstructor
                .SetParameter(NameParameterForApi.Year, year)
                .SetParameter(NameParameterForApi.IdFilial, idFilial)
                .SetParameter(NameParameterForApi.IdFaculty, idFaculty)
                .GetResults();
            string json = ExecuteGet(MethodApi.GetSpecialtys, parameters);
            return ConvertToList<Specialty>(json);
        }

        public List<Course> GetCourses(int year, int idFilial, int idFaculty, IList<int> idsSpecialty)
        {
            IDictionary<string, string> parameters = _parameterConstructor
                .SetParameter(NameParameterForApi.Year, year)
                .SetParameter(NameParameterForApi.IdFilial, idFilial)
                .SetParameter(NameParameterForApi.IdFaculty, idFaculty)
                .GetResults();
            string json = ExecutePost(MethodApi.GetCourses, parameters, idsSpecialty);
            return ConvertToList<Course>(json);
        }

        //TODO: idCourse поменять местами с idsSpecialty
        public List<Group> GetGroups(int year, int idFilial, int idFaculty, int idCourse,
            IList<int> idsSpecialty)
        {
            IDictionary<string, string> parameters = _parameterConstructor
                .SetParameter(NameParameterForApi.Year, year)
                .SetParameter(NameParameterForApi.IdFilial, idFilial)
                .SetParameter(NameParameterForApi.IdFaculty, idFaculty)
                .SetParameter(NameParameterForApi.IdCourse, idCourse)
                .GetResults();
            string json = ExecutePost(MethodApi.GetGroups, parameters, idsSpecialty);
            return ConvertToList<Group>(json);
        }

        public List<Pulpit> GetPulpits(int year, int idFilial)
        {
            IDictionary<string, string> parameters = _parameterConstructor
                .SetParameter(NameParameterForApi.Year, year)
                .SetParameter(NameParameterForApi.IdFilial, idFilial)
                .GetResults();
            var json = ExecuteGet(MethodApi.GetPulpit, parameters);
            return ConvertToList<Pulpit>(json);
        }

        public List<Teacher> GetTeacher(int year, int idPulpit)
        {
            IDictionary<string, string> parameters = _parameterConstructor
                .SetParameter(NameParameterForApi.Year, year)
                .SetParameter(NameParameterForApi.IdPulpit, idPulpit)
                .GetResults();
            var json = ExecuteGet(MethodApi.GetTeacher, parameters);
            return ConvertToList<Teacher>(json);
        }
    }
}