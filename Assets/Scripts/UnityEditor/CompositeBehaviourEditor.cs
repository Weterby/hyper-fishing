using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CompositeBehaviour))]
public class CompositeBehaviourEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CompositeBehaviour compositeBehaviour = (CompositeBehaviour)target;

        if(compositeBehaviour.FlockBehaviours == null || compositeBehaviour.FlockBehaviours.Length == 0)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.HelpBox("No behaviours in list.", MessageType.Warning);
            EditorGUILayout.EndHorizontal();
        }
        else
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Number", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
            EditorGUILayout.LabelField("Behaviors", GUILayout.MinWidth(60f));
            EditorGUILayout.LabelField("Weights", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < compositeBehaviour.FlockBehaviours.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(i.ToString(), GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
                compositeBehaviour.FlockBehaviours[i] = (FlockBehaviour)EditorGUILayout.ObjectField(compositeBehaviour.FlockBehaviours[i], typeof(FlockBehaviour), false, GUILayout.MinWidth(60f));
                compositeBehaviour.BehaviourWeights[i] = EditorGUILayout.FloatField(compositeBehaviour.BehaviourWeights[i], GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
                EditorGUILayout.EndHorizontal();
            }

        }
    }
}
