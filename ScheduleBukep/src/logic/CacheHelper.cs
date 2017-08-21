using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;

namespace Bukep.Sheduler.logic
{
    public class CacheHelper
    {
        private const string Tag = "CacheHelper";
        private static readonly IBlobCache Cache = BlobCache.LocalMachine;
        private static readonly IBlobCache UserData = BlobCache.UserAccount;

        /// <summary>
        /// �������� ��� �� �����, 
        /// ���� ���� ��� ����� ������ �� ���������� ������� � �������� � ���.
        /// </summary>
        /// <typeparam name="T">��� ������ ���������� �� ����.</typeparam>
        /// <param name="key">���� ����.</param>
        /// <param name="fetchFunc">������� ��������� ������.��������� � ������ ���� ������ ��� � ����.</param>
        /// <returns>������ �� ����</returns>
        public static T GetOrPutCached<T>(string key, Func<T> fetchFunc)
        {
            try
            {
                T result = Cache.GetObject<T>(key).Wait();
                if (result == null)
                {
                    return PutCache(key, fetchFunc.Invoke());
                }
                return result;
            }
            catch (KeyNotFoundException)
            {
                return PutCache(key, fetchFunc.Invoke());
            }
        }

        //TODO: ����� �� ��� � GetOrPutInCached
        public static T GetOrPutUserData<T>(string key, Func<T> fetchFunc)
        {
            try
            {
                T result = UserData.GetObject<T>(key).Wait();
                if (result == null)
                {
                    return PutUserData(key, fetchFunc.Invoke());
                }
                return result;
            }
            catch (KeyNotFoundException)
            {
                return PutUserData(key, fetchFunc.Invoke());
            }
        }

        /// <summary>
        /// ���������� ������ � ��� � ���������� ��.
        /// </summary>
        /// <typeparam name="T">��� ����������� ������ � ����.</typeparam>
        /// <param name="key">���� ����.</param>
        /// <param name="value">������ ������� ����� ��������.</param>
        /// <returns>value</returns>
        private static T PutCache<T>(string key, T value)
        {
            Cache.InsertObject(key, value);
            return value;
        }

        public static T PutUserData<T>(string key, T value)
        {
            UserData.InsertObject(key, value);
            return value;
        }

        public static T GetUserData<T>(string key)
        {
            return UserData.GetObject<T>(key).Wait();
        }

        public static void DeleteUserData(string key)
        {
            UserData.Invalidate(key);
        }
    }
}