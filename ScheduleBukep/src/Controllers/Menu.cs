using System;
using Android.Content;
using Bukep.Sheduler.logic;
using Bukep.Sheduler.View;
using ScheduleBukepAPI.helpers;

namespace Bukep.Sheduler.Controllers
{
    public class Menu : Controller
    {
        private const string Tag = "Menu";
        private readonly MenuActivity _view;

        public Menu(MenuActivity view) : base(view)
        {
            _view = view;
        }

        public override void Update()
        {
        }

        public void ClickScheduleForStudent(object sender, EventArgs ea)
        {
            StartActivitySchedule(SelectItemType.SelectScheduleStudent);
        }

        public void ClickScheduleForTeacher(object sender, EventArgs e)
        {
            StartActivitySchedule(SelectItemType.SelectScheduleTeacher);
        }

        public void ClickScheduleBell(object sender, EventArgs e)
        {
        }

        public void ClickScheduleFavorite(object sender, EventArgs e)
        {
            StartActivitySchedule(SelectItemType.SelectFavoritesGroup);
        }

        private void StartActivitySchedule(SelectItemType selectItemType)
        {
            var intent = new Intent(_view, typeof(SelectItemActivity));
            intent.PutExtra(
                SelectItem.IntentKeyDateSelectItemType,
                JsonConvert.ConvertToJson(selectItemType));
            _view.StartActivity(intent);
        }
    }
}