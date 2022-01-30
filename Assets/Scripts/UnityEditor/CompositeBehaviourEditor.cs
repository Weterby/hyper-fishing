using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CompositeBehaviour))]
public class CompositeBehaviourEditor : Editor
{
    #region Public Methods

    public override void OnInspectorGUI()
    {
        CompositeBehaviour compositeBehaviour = (CompositeBehaviour) target;

        if (compositeBehaviour.FlockBehaviours == null || compositeBehaviour.FlockBehaviours.Length == 0)
        {
            EditorGUILayout.HelpBox("No behaviours in list.", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Number", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
            EditorGUILayout.LabelField("Behaviors", GUILayout.MinWidth(60f));
            EditorGUILayout.LabelField("Weights", GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
            EditorGUILayout.EndHorizontal();

            EditorGUI.BeginChangeCheck();

            for (int i = 0; i < compositeBehaviour.FlockBehaviours.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField(i.ToString(), GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
                compositeBehaviour.FlockBehaviours[i] = (FlockBehaviour) EditorGUILayout.ObjectField(compositeBehaviour.FlockBehaviours[i], typeof(FlockBehaviour), false, GUILayout.MinWidth(60f));
                compositeBehaviour.BehaviourWeights[i] = EditorGUILayout.FloatField(compositeBehaviour.BehaviourWeights[i], GUILayout.MinWidth(60f), GUILayout.MaxWidth(60f));
                EditorGUILayout.EndHorizontal();
            }

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(compositeBehaviour);
            }
        }

        GUILayout.Space(10f);

        EditorGUILayout.BeginVertical();

        if (GUILayout.Button("Add behaviour"))
        {
            AddBehaviour(compositeBehaviour);
            EditorUtility.SetDirty(compositeBehaviour);
        }

        GUILayout.Space(5f);

        if (GUILayout.Button("Remove Behaviour"))
        {
            RemoveBehaviour(compositeBehaviour);
            EditorUtility.SetDirty(compositeBehaviour);
        }

        EditorGUILayout.EndVertical();
    }

    #endregion

    #region Private Methods

    private void AddBehaviour(CompositeBehaviour compositeBehaviour)
    {
        int oldCount = compositeBehaviour != null ? compositeBehaviour.FlockBehaviours.Length : 0;
        FlockBehaviour[] newBehaviours = new FlockBehaviour[oldCount + 1];
        float[] newWeights = new float[oldCount + 1];

        for (int i = 0; i < oldCount; i++)
        {
            newBehaviours[i] = compositeBehaviour.FlockBehaviours[i];
            newWeights[i] = compositeBehaviour.BehaviourWeights[i];
        }

        newWeights[oldCount] = 1f;
        compositeBehaviour.FlockBehaviours = newBehaviours;
        compositeBehaviour.BehaviourWeights = newWeights;
    }

    private void RemoveBehaviour(CompositeBehaviour compositeBehaviour)
    {
        int oldCount = compositeBehaviour.FlockBehaviours.Length;

        if (oldCount == 1)
        {
            compositeBehaviour.FlockBehaviours = null;
            compositeBehaviour.BehaviourWeights = null;

            return;
        }

        FlockBehaviour[] newBehaviours = new FlockBehaviour[oldCount - 1];
        float[] newWeights = new float[oldCount - 1];

        for (int i = 0; i < oldCount - 1; i++)
        {
            newBehaviours[i] = compositeBehaviour.FlockBehaviours[i];
            newWeights[i] = compositeBehaviour.BehaviourWeights[i];
        }

        compositeBehaviour.FlockBehaviours = newBehaviours;
        compositeBehaviour.BehaviourWeights = newWeights;
    }

    #endregion
}