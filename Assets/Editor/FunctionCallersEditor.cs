using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(FunctionCallers))]
public class FunctionCallersEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FunctionCallers callers = target as FunctionCallers;

        if (callers == null) return;
        if (callers.All == null)
        {
            callers.All = new List<CallerInfo>();
        }
        
        if (GUILayout.Button("Add Caller"))
        {
            callers.All.Add(new CallerInfo()
            {
                Target = callers.gameObject
            });
        }

        GUILayout.Space(5);

        if (callers.All.Count == 0) return;

        CallerInfo toBeRemove = null;
        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);
        for (int i = 0; i < callers.All.Count; i++)
        {
            GUILayout.BeginVertical("Box");

            CallerInfo caller = callers.All[i];
            if (GUILayout.Button("x", GUILayout.Width(20)))
            {
                toBeRemove = caller;
            }
            GameObject newSendMessageTarget = EditorGUILayout.ObjectField("Target", caller.Target,
                typeof(GameObject), true, null) as GameObject;
            if (newSendMessageTarget != target)
            {
                caller.Target = newSendMessageTarget;
                GUI.changed = true;
            }
            if (caller.Target != null)
            {
                MethodBinding("Function", caller.Target, ref caller.MethodName);

                GUI.enabled = EditorApplication.isPlaying;
                if (GUILayout.Button("Call"))
                {
                    if (caller.Target != null && caller.MethodName.Length > 0)
                    {
                        caller.Target.SendMessage(caller.MethodName,
                            this, SendMessageOptions.RequireReceiver);
                    }
                }
                GUI.enabled = true;
            }

            GUILayout.EndVertical();
        }

        if (toBeRemove != null)
        {
            callers.All.Remove(toBeRemove);
        }
        EditorGUILayout.EndScrollView();
    }

    private void MethodBinding(string name, GameObject target, ref string methodName)
    {
        if (target == null)
        {
            bool oge = GUI.enabled;
            GUI.enabled = false;
            EditorGUILayout.Popup(name, -1, new string[0]);
            GUI.enabled = oge;
            return;
        }

        if (!_cache.ContainsKey(target))
        {
            CacheGameObject(target);
            CacheMethodsForGameObject(target);
        }

        List<string> cachedMethods = _cache[target];
        int idx = cachedMethods.IndexOf(methodName);
        GUILayout.BeginHorizontal();
        int nidx = EditorGUILayout.Popup(name, idx, cachedMethods.ToArray());
        if (nidx != idx)
        {
            methodName = cachedMethods[nidx];
        }
        if (!string.IsNullOrEmpty(methodName) && methodName.Length != 0)
        {
            if (GUILayout.Button("Clear", EditorStyles.miniButton, GUILayout.ExpandWidth(false)))
            {
                methodName = "";
                HandleUtility.Repaint();
            }
        }

        GUILayout.EndHorizontal();
    }

    private void CacheMethodsForGameObject(GameObject go)
    {
        List<System.Type> addedTypes = new List<System.Type>();
        MonoBehaviour[] behaviours = go.GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour beh in behaviours)
        {
            System.Type type = beh.GetType();
            if (addedTypes.IndexOf(type) == -1)
            {
                System.Reflection.MethodInfo[] methods = type.GetMethods(
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.NonPublic);
                foreach (System.Reflection.MethodInfo method in methods)
                {
                    // Only add variables added by user, 
                    // i.e. we don't want functions from the base UnityEngine baseclasses or lower
                    string moduleName = method.DeclaringType.Assembly.ManifestModule.Name;
                    if (!moduleName.Contains("UnityEngine") && !moduleName.Contains("mscorlib") &&
                        !method.ContainsGenericParameters &&
                        System.Array.IndexOf(ignoredMethodNames, method.Name) == -1)
                    {

                        System.Reflection.ParameterInfo[] paramInfo = method.GetParameters();
                        if (paramInfo.Length == 0)
                        {
                            _cache[go].Add(method.Name);
                        }
                    }
                }
            }
        }
    }

    private void CacheGameObject(GameObject go)
    {
        _cache.Add(go, new List<string>());
    }

    private static readonly string[] ignoredMethodNames = new string[] {
        "Start", "Awake", "OnEnable", "OnDisable",
        "Update", "OnGUI", "LateUpdate", "FixedUpdate"
    };

    private Dictionary<GameObject, List<string>> _cache =
        new Dictionary<GameObject, List<string>>();

    private Vector3 _scrollPosition;
}
