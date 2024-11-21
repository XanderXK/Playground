using UnityEngine;

namespace DesignPatterns.Behavioral.Template
{
    public abstract class Ability
    {
        protected virtual void Initialize()
        {
            Debug.Log("Ability Initialize");
        }

        protected virtual void PreApply()
        {
        }

        protected virtual void Apply()
        {
        }

        protected virtual void PostApply()
        {
        }
        
        public void Use()
        {
            Initialize();
            PreApply();
            Apply();
            PostApply();
        }
    }
}