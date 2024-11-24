using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace AddressablesPlayground
{
    public class AddressablesTester : MonoBehaviour
    {
        [SerializeField] private AssetReferenceGameObject _environmentPrefab;
        [SerializeField] private AssetReferenceGameObject _aiPrefab;

        private AsyncOperationHandle _aiHandle;

        private async void Start()
        {
            var environmentSpawnTask = Addressables.InstantiateAsync(_environmentPrefab).Task;
            Debug.Log("Loading environment");
            var environment = await environmentSpawnTask;
            Debug.Log("Loaded", environment);
        }

        private void Update()
        {
            if (Keyboard.current.aKey.wasPressedThisFrame)
            {
                Addressables.InstantiateAsync(_aiPrefab).Completed += OnCompleted;
            }
        }

        private void OnCompleted(AsyncOperationHandle<GameObject> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log(handle.Result);
                _aiHandle = handle;
            }
        }

        private void OnDestroy()
        {
            if (!_aiHandle.IsValid())
            {
                return;
            }

            _aiHandle.Release();
        }
    }
}