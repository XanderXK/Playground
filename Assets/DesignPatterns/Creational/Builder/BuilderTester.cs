using UnityEngine;

namespace DesignPatterns.Creational.Builder
{
    public class BuilderTester : MonoBehaviour
    {
        private void Start()
        {
            var character = new CharacterBuilder()
                .Reset()
                .WithName("Player")
                .WithPosition(Vector3.one)
                .WithRotation(Quaternion.identity).Build();
            Debug.Log(character, character);
        }
    }
}