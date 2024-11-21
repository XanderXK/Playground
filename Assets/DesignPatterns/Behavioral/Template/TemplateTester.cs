using UnityEngine;

namespace DesignPatterns.Behavioral.Template
{
    public class TemplateTester : MonoBehaviour
    {
        private void Start()
        {
            Ability fireball = new Fireball();
            fireball.Use();

            Ability iceAura = new IceAura();
            iceAura.Use();
        }
    }
}