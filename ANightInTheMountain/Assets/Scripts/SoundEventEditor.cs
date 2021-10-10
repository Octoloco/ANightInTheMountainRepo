using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;

[CustomEditor(typeof(SoundEvent))]
public class SoundEventEditor : Editor
{
    SoundEvent myTarget;

    private void OnEnable()
    {
        myTarget = (SoundEvent)target;
    }
    public override void OnInspectorGUI()
    {
        myTarget.collection = (SoundCollection)EditorGUILayout.ObjectField("Sounds", myTarget.collection, typeof(SoundCollection), true);
        if (myTarget.collection == null)
            return;
        if (myTarget.collection.audioClips == null || myTarget.collection.audioClips.Count == 0)
        {
            EditorGUILayout.HelpBox("No clips available", MessageType.Warning);
            return;
        }
        myTarget.playAwake = EditorGUILayout.Toggle("Play on Awake", myTarget.playAwake);
        myTarget.isRandom = EditorGUILayout.Toggle("Random clip", myTarget.isRandom);
        if (myTarget.isRandom)
            return;
        if (myTarget.collection.audioClips.Count > 1)
        {
            //myTarget.isRandom = EditorGUILayout.Toggle("Random clip", myTarget.isRandom);
            myTarget.index = EditorGUILayout.IntSlider(myTarget.index, 0, myTarget.collection.audioClips.Count - 1);
        }


        EditorGUILayout.LabelField("Main Clip: " + myTarget.collection.audioClips[myTarget.index].name);
    }
}
