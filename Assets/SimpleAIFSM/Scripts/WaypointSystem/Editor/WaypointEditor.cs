using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SimpleAIFSM
{
    [CustomEditor(typeof(Waypoint))]
    public class WaypointEditor : Editor
    {
        private void OnSceneGUI()
        {
            if (Application.isPlaying)
            {
                return;
            }

            var waypoint = target as Waypoint;
            var points = waypoint!.Points;
            if (points == null || !points.Any())
            {
                return;
            }

            for (var i = 0; i < points.Count; i++)
            {
                EditorGUI.BeginChangeCheck();
                var handlePosition = Handles.FreeMoveHandle(waypoint.Points[i] + (Vector2)waypoint.transform.position,
                    0.25f, Vector3.zero, Handles.CubeHandleCap);

                var style = new GUIStyle();
                style.fontSize = 16;
                style.normal.textColor = Color.blue;
                Handles.Label(waypoint.Points[i] + (Vector2)waypoint.transform.position, i.ToString(), style);
                if (!EditorGUI.EndChangeCheck())
                {
                    continue;
                }

                Undo.RecordObject(waypoint, "Move Waypoint");
                points[i] = handlePosition - waypoint.transform.position;
            }
        }
    }
}