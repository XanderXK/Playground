using UnityEngine;

namespace DesignPatterns.Behavioral.Memento
{
    public class MementoTester : MonoBehaviour
    {
        private void Start()
        {
            var stats = new Stats();
            stats.TakeDamage(5);
            stats.UseMana(5);
            Debug.Log($"Health: {stats.Health}, Mana: {stats.Mana}");

            var saveData = stats.GetState();

            stats.TakeDamage(10);
            stats.UseMana(5);
            Debug.Log($"Health: {stats.Health}, Mana: {stats.Mana}");

            stats.SetState(saveData);
            Debug.Log($"Health: {stats.Health}, Mana: {stats.Mana}");
        }
    }
}