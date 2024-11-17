using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DesignPatterns.Creational.AbstractFactory
{
    public class FactoryTester : MonoBehaviour
    {
        private ISpawnerFactory _factory;

        private void Start()
        {
            SetLocalSpawnFactory();
        }

        private void Update()
        {
            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                SetLocalSpawnFactory();
            }

            if (Keyboard.current.digit2Key.wasPressedThisFrame)
            {
                SetNetSpawnFactory();
            }

            if (Keyboard.current.sKey.wasPressedThisFrame)
            {
                _factory.SpawnPlayer();
                _factory.SpawnSlime();
                _factory.SpawnWorldItem();
            }
        }


        private void SetLocalSpawnFactory()
        {
            _factory = new LocalSpawnFactory();
        }

        private void SetNetSpawnFactory()
        {
            _factory = new NetSpawnerFactory();
        }
    }
}