using System;
using System.Net;
using Android.Content;
using Android.Net;
using Android.Util;
using Bukep.Sheduler.View;

namespace Bukep.Sheduler.logic
{
    /// <summary>
    /// ����� ��� �������� ��������� ����� ����������� ����� ���� ��������.
    /// </summary>
    public class InternetChecker
    {
        private const string Tag = "InternetChecker";
        private ConnectivityManager _connectivityManager;
        private readonly BaseActivity _activity;

        public InternetChecker(BaseActivity activity)
        {
            _activity = activity;
        }

        /// <summary>
        /// ������������ ��� �������� ����������� � ��������� ����� ����������� �������.
        /// ���� ��� ����������� ������� ��������� �� ������.
        /// </summary>
        /// <typeparam name="TResult">��������� ���������� �������.</typeparam>
        /// <param name="func">������� ������� ����� ���������.</param>
        /// <param name="defaultValue">���������� � ������ �������.</param>
        /// <returns></returns>
        public TResult ExecuteOperation<TResult>(Func<TResult> func, TResult defaultValue)
        {
            if (!CheckInternetConnect())
            {
                FailedInternetConnect();
            }

            try
            {
                return func.Invoke();
            }
            catch (WebException e)
            {
                Log.Error(Tag, e.ToString());
                FailedInternetConnect();
                return defaultValue;
            }
        }

        private bool CheckInternetConnect()
        {
            if (_connectivityManager == null)
            {
                _connectivityManager = (ConnectivityManager) _activity.GetSystemService(Context.ConnectivityService);
            }

            NetworkInfo info = _connectivityManager.ActiveNetworkInfo;
            return info != null && info.IsConnected;
        }

        public void FailedInternetConnect()
        {
            //TODO: move in res
            _activity.ShowError("����������� ����������� � ���������.");
        }
    }
}