using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyPositionDataSO", menuName ="Create EnemyPositionDataSO")]

public class EnemyPositionDataSO :ScriptableObject
{
    public List<EnemyPosition> enemyPositionsList = new List<EnemyPosition>();
}
