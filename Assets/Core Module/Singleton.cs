using UnityEngine;
using System.Collections;

namespace Utilities
{

    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {

        private T instance;
        private static object _lock = new object();

        public static T instance
        {
            get
            {

            }
        }
    }
}