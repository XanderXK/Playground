using System;
using UnityEngine;

namespace DesignPatterns.Structural.Facade
{
    public class Merchant : MonoBehaviour
    {
        public int Gold { get; private set; }


        private void Awake()
        {
            MerchantFacade.Init(this);
        }

        public void Sell()
        {
            Debug.Log("Merchant Sell");
        }

        public void Buy()
        {
            Debug.Log("Merchant Buy");
        }

        public void Repair()
        {
            Debug.Log("Merchant Repair");
        }
    }
}