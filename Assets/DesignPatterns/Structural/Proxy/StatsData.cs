using System;
using UnityEngine;

namespace DesignPatterns.Structural.Proxy
{
    [Serializable]
    public class StatsData : IStatsData
    {
        [SerializeField] private int _hp;
        
        public int Hp { get=> _hp; set=> _hp = value; }
        
        public void Act()
        {
            Debug.Log("StatsData Act");
        }
    }
}