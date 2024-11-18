using UnityEngine;

namespace DesignPatterns.Creational.Singleton
{
    public class SingletonTester : Singleton<SingletonTester>
    {
        private void Start()
        {
            Debug.Log(gameObject);
        }
    }
}