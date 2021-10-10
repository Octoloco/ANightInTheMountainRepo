using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "SoulsController")]
public class SoulsController : ScriptableObject
{
    [SerializeField] [Range(0, 100)] int currentSouls = 50;

    [SerializeField] int addFactor;
    [SerializeField] int removeFactor;

    [HideInInspector] public bool soulsAdded;
    [HideInInspector] public bool soulsRemove;
    [HideInInspector] public int CurrentSouls=>currentSouls;
    public void AddSouls(int add = 0)
    {
        currentSouls += add == 0 ? addFactor : add;
        currentSouls = currentSouls >= 100 ? 100 : currentSouls;
        soulsAdded = true;
    }
    public void Remove(int remove = 0)
    {
        currentSouls -= remove == 0 ? removeFactor : remove;
        currentSouls = currentSouls <= 0 ? 0 : currentSouls;
        soulsRemove = true;
    }
}
