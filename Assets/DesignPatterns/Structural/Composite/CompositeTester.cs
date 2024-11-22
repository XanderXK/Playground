using UnityEngine;

namespace DesignPatterns.Structural.Composite
{
    public class CompositeTester : MonoBehaviour
    {
        private void Start()
        {
            var item1 = new Item("Item 1");
            var item2 = new Item("Item 2");
            var item3 = new Item("Item 3");

            var container1 = new ItemContainer("Container 1");
            var container2 = new ItemContainer("Container 2");

            container1.Add(item1);
            container1.Add(item2);
            container1.Add(container2);
            container2.Add(item3);

            container1.Run();
        }
    }
}