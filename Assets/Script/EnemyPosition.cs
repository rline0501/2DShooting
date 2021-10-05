using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyPosition
{
    public int positionNumber;

    public Transform transform;
    //敵を出現させたい位置情報のみを持ったPrefabゲームオブジェクトを用意して、それらをアサインする
}
