using UnityEngine;

namespace DesignPatterns.Structural.Adapter
{
    public class AdapterTester : MonoBehaviour
    {
        private void Start()
        {
            ICurrency currency = new Gold(10);
            ICurrency anotherCurrency = new AdapterForGems(5);

            Debug.Log(currency.GetValue());
            Debug.Log(anotherCurrency.GetValue());
        }
    }
}