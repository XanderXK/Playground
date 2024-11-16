using UnityEngine;
using UnityEngine.InputSystem;

namespace DesignPatterns.Structural.Proxy
{
    
    public class ProxyTester : MonoBehaviour
    {
        private IStatsData _statsData;

        private void Awake()
        {
            var original = new StatsData();
            var statsDataProxy = new StatsDataProxy(original);
            statsDataProxy.OnHpChanged += (hp) =>
            {
                Debug.Log($"New HP: {hp}");
                var json = JsonUtility.ToJson(original);
                Debug.Log(json);
            };

            _statsData = statsDataProxy;
        }

        private void Update()
        {
            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                Test();
            }
        }

        private void Test()
        {
            var randomValue = UnityEngine.Random.Range(-1000, 1000);
            _statsData.Hp = randomValue;
            Debug.Log($"Value: {randomValue} HP: {_statsData.Hp}");
            _statsData.Act();
        }
    }
}