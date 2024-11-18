using UnityEngine;

namespace DesignPatterns.Creational.Singleton
{
    public class SingletonRes<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Instantiate(Resources.Load<T>(nameof(T)));
                    DontDestroyOnLoad(_instance.gameObject);
                }

                return _instance;
            }
        }
    }
}