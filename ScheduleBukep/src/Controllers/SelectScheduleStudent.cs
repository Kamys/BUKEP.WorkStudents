﻿﻿using System.Collections.Generic;
using Bukep.Sheduler.View;
using ScheduleBukepAPI.domain;

namespace Bukep.Sheduler.Controllers
{
    internal class SelectScheduleStudent : SelectItem
    {
        private Faculty _selectedFaculty;
        private Specialty _selectedSpecialty;
        private Course _selectedCourse;

        public SelectScheduleStudent(SelectItemActivity view) : base(view)
        {
        }

        public override void Update()
        {
            ItemChoiceFaculty();
        }

        private void ItemChoiceFaculty()
        {
            InitSelect(
                DataProvider.GetFaculties(),
                InitChoiceSpecialty,
                faculty => faculty.Info.Value);
        }

        private void InitChoiceSpecialty(Faculty faculty)
        {
            _selectedFaculty = faculty;
            InitSelect(
                DataProvider.GetSpecialtys(faculty.Info.Key),
                InitChoiceCourse,
                specialty => specialty.Info.Value);
        }

        private void InitChoiceCourse(Specialty specialty)
        {
            _selectedSpecialty = specialty;
            IList<Course> courses = DataProvider.GetCourses(
                _selectedFaculty.Info.Key,
                specialty.Info.Key
            );

            InitSelect(
                courses,
                InitChoiceGroup,
                course => course.Info.Value);
        }

        private void InitChoiceGroup(Course course)
        {
            _selectedCourse = course;
            IList<Group> groups = DataProvider.GetGroups(
                _selectedFaculty.Info.Key,
                _selectedCourse.Info.Key,
                _selectedSpecialty.Info.Key
            );

            InitSelect(
                groups,
                StartScheduleActivity,
                group => $"{group.Info[0].Group.Value} {group.TypeShedule.Value}");
        }

        protected void StartScheduleActivity(Group group)
        {
            ScheduleActivity.StartScheduleActivity(View, group);
        }
    }
}