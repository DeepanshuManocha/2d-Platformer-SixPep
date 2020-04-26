using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnableObjectData : MonoBehaviour
{
    public enum DataType 
    {
        platform, startPos, endPos, coin 
    };

    [Serializable]
    public struct Data
    {
        public Vector2 position;
        public DataType objectType; 
    }
    public Data data;
}
