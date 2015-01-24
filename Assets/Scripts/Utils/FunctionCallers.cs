using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
[System.Serializable]
public class CallerInfo
{
    public GameObject Target;
    public string MethodName;
}
#endif

public class FunctionCallers : MonoBehaviour 
{
#if UNITY_EDITOR
    [SerializeField]
    public List<CallerInfo> All;
#endif
}
