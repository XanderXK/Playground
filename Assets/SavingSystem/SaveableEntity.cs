using System.Collections.Generic;
using UnityEngine;

public class SaveableEntity : MonoBehaviour
{
    [SerializeField] private string _id;


#if UNITY_EDITOR
    private void OnValidate()
    {
        if (!string.IsNullOrEmpty(_id) || string.IsNullOrEmpty(gameObject.scene.path))
        {
            return;
        }

        var serializedObject = new UnityEditor.SerializedObject(this);
        var serializedProperty = serializedObject.FindProperty("id");

        var gameObjectName = gameObject.name;
        if (gameObjectName.Contains(" ("))
        {
            gameObjectName = gameObjectName.Remove(gameObjectName.IndexOf(" (", System.StringComparison.Ordinal));
        }

        serializedProperty.stringValue = gameObjectName.ToLower() + Random.Range(10000, 99999).ToString();
        serializedObject.ApplyModifiedProperties();
    }
#endif


    public string GetId()
    {
        return _id;
    }

    public object CaptureState()
    {
        var state = new Dictionary<string, object>();
        foreach (var item in GetComponents<ISaveable>())
        {
            state[item.GetType().ToString()] = item.CaptureState();
        }

        return state;
    }

    public void RestoreState(object state)
    {
        var stateDictionary = state as Dictionary<string, object>;
        if (stateDictionary == null)
        {
            return;
        }

        foreach (var item in GetComponents<ISaveable>())
        {
            var typeString = item.GetType().ToString();
            if (stateDictionary.TryGetValue(typeString, out var value))
            {
                item.RestoreState(value);
            }
        }
    }
}