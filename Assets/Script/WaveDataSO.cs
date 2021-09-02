using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WavedataSO", menuName = "Create WaveDataSO")]

public class WaveDataSO:ScriptableObject
{
    public List<WaveData> waveDatasList = new List<WaveData>();
}
