using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelComponent))]
public class LevelComponentEditor : Editor {

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        LevelComponent component = target as LevelComponent;

        EditorGUILayout.Separator();
        component.ID = component.name;
        EditorGUILayout.LabelField("ID", component.ID.ToString());
		
		EditorGUILayout.Separator();
		component.DistanceToGround =
			EditorGUILayout.FloatField("Distance to Ground", component.DistanceToGround);
		component.transform.SetPositionY(component.DistanceToGround);

        EditorGUILayout.Separator();
        component.IsScalable =
            EditorGUILayout.Toggle("可缩放 IsScalable", component.IsScalable);

        EditorGUILayout.Separator();
        component.SnapToVerticalLine =
            EditorGUILayout.Toggle("吸附到竖线上 SnapHorizontally", component.SnapToVerticalLine);

        EditorGUILayout.Separator();
        component.SnapToHorizontalLine =
            EditorGUILayout.Toggle("吸附到横线上 SnapVertically", component.SnapToHorizontalLine);

        EditorGUILayout.Separator();
        component.PoolStartCount =
            EditorGUILayout.IntField("Pool Init Count", component.PoolStartCount);

        EditorGUILayout.Separator();
        component.IsHighEndOnly =
            EditorGUILayout.Toggle("只在高端机上创建", component.IsHighEndOnly);
        EditorGUILayout.LabelField("Is High-end Only");

        EditorGUILayout.Separator();
        if (GUILayout.Button("Rebuild", GUILayout.Height(30)))
        {
            component.Rebuild();
        }
        serializedObject.ApplyModifiedProperties();
    }

    protected void OnEnable()
    {
        TrySnapToGrid(target as LevelComponent);
    }

    protected void OnSceneGUI()
    {
        if (Event.current != null && Selection.activeGameObject != null)
        {
            if (Event.current.type == EventType.MouseUp)
            {
                foreach (Transform transform in Selection.transforms)
                {
                    LevelComponent component = transform.GetComponent<LevelComponent>();
                    TrySnapToGrid(component);
                }
            }
        }
    }

    protected void TrySnapToGrid(LevelComponent component)
    {
        component.DoSnapToGrid();
    }

    private Vector2 _scrollPosition;
}