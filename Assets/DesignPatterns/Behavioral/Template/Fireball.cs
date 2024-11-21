using UnityEngine;

namespace DesignPatterns.Behavioral.Template
{
    public class Fireball: Ability
    {
        protected override void Apply()
        {
            Debug.Log("Fireball");
        }
    }
}