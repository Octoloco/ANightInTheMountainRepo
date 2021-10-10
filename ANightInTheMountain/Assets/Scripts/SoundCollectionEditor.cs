using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;

[CustomEditor(typeof(SoundCollection))]
public class SoundCollectionEditor : Editor
{
    AudioSource preview;
    int index;
    private void OnEnable()
    {
        preview = EditorUtility.CreateGameObjectWithHideFlags("Preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
    }
    private void OnDisable()
    {
        DestroyImmediate(preview);
    }

    public override void OnInspectorGUI()
    {
        SoundCollection collection = (SoundCollection)target;
        DrawDefaultInspector();

        if (collection.audioClips == null || collection.audioClips.Count == 0) return;

        if (collection.audioClips.Count > 1)
            index = EditorGUILayout.IntSlider("Clip to test", index, 0, collection.audioClips.Count - 1);
        if (collection.audioClips != null && collection.audioClips.Count > 1)
            EditorGUILayout.LabelField("Main Clip to preview: " + collection.audioClips[index].name);
        if (GUILayout.Button("Preview"))
        {
            preview.volume = collection.volume;
            collection.PlayAudioClip(preview, index);
        }
    }

}
