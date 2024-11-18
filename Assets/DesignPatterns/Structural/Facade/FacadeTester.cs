using UnityEngine;

namespace DesignPatterns.Structural.Facade
{
    public class FacadeTester : MonoBehaviour
    {
        private void Start()
        {
            MerchantFacade.Buy();
            MerchantFacade.Sell();
            MerchantFacade.Repair();
            Debug.Log(MerchantFacade.Gold);
        }
    }
}