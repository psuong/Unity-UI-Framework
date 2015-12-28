using UnityEngine;
using System.Collections;

namespace UIFramework.Singleton
{
    /// <summary>
    /// This class is creates a Singleton Object. A Singleton object
    /// only allows one instance of the said object to be active. This
    /// class is very useful to create managers; ideally you only want 1 
    /// manager to run at any point in time.
    /// </summary>
    /// <typeparam name="T">T is the generic component type</typeparam>
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        private static object _lock = new object();

        public static T instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = (T)FindObjectOfType(typeof(T));

                        if (FindObjectsOfType(typeof(T)).Length > 1)
                        {
                            Debug.LogError("[Singleton] Something went really wrong " +
                                " - there should never be more than 1 singleton!" +
                                " Reopening the scene might fix it.");
                            return _instance;
                        }

                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent<T>();
                            singleton.name = "(singleton) " + typeof(T).ToString();

                            DontDestroyOnLoad(singleton);

                            Debug.Log("[Singleton] An instance of " + typeof(T) +
                                " is needed in the scene, so '" + singleton +
                                "' was created with DontDestroyOnLoad.");
                        }
                        else
                        {
                            Debug.Log("[Singleton] Instance created: " +
                                _instance.gameObject.name);
                        }
                    }
                    return _instance;
                }
            }
        }

        /// <summary>
        /// Uses Unity's Awake() call. Checks if there is a
        /// single instance of the singleton created.
        /// Call OnAwake() to make sure there aren't many
        /// singletons created.
        /// </summary>
        protected void Awake()
        {
            if (instance != null && instance != this)
                Destroy(this);
            else
                OnAwake();
        }
        
        /// <summary>
        /// Base method call, use this for an Awake call.
        /// </summary>
        protected virtual void OnAwake() { }
    }

}
