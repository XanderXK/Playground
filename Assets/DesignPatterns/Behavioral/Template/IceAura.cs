using UnityEngine;

namespace DesignPatterns.Behavioral.Template
{
    public class IceAura: Ability
    {
        protected override void Initialize()
        {
            base.Initialize();
            Debug.Log("IceAura Initialize");
        }
    }
}