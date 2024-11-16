using System;
using UnityEngine;

namespace DesignPatterns.Structural.Proxy
{
    public class StatsDataProxy : IStatsData
    {
        private readonly StatsData _original;
        public event Action<int> OnHpChanged;

        public int Hp
        {
            get => _original.Hp;
            set
            {
                var newHp = Mathf.Clamp(value, 0, 100);
                if (newHp != _original.Hp)
                {
                    _original.Hp = newHp;
                    OnHpChanged?.Invoke(newHp);
                }
            }
        }

        public StatsDataProxy(StatsData original)
        {
            _original = original;
        }

        public void Act()
        {
            Debug.Log("StatsDataProxy");
            _original.Act();
            Debug.Log("StatsDataProxy After");
        }
    }
}