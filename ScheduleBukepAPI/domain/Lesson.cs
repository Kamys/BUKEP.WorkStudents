﻿using System.Collections.Generic;

namespace ScheduleBukepAPI.domain
{
    //TODO: Конфликт имени класса и метода
    public class Lesson
    {
        public KeyValuePair<int, string> TypeShedule { get; set; }
        public KeyValuePair<int, string> TypeWeek { get; set; }
        public KeyValuePair<int, string> Day { get; set; }
        public KeyValuePair<int, string> LessonInfo { get; set; }
        public KeyValuePair<int, string> TypeLesson { get; set; }
        public string DateLesson { get; set; }
        public TimeLesson TimeLesson { get; set; }
        public List<KeyValuePair<int, string>> Auditory { get; set; }
        public List<KeyValuePair<int, string>> Teachers { get; set; }
        public KeyValuePair<int, string> Discipline { get; set; }
    }

    public class TimeLesson
    {
        public string NameLessonTime { get; set; }
        public string StartLesson { get; set; }
        public string EndLesson { get; set; }
        public string Durability { get; set; }
    }
}