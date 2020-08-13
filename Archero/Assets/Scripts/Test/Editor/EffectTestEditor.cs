using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EffectTest))]
public class EffectTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EffectTest effectTest = (EffectTest)target;
        if (GUILayout.Button("Add"))
        {
            effectTest.AddEffect();
        }
    }
}
