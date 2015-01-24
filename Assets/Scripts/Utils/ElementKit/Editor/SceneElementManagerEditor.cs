using UnityEngine;
using UnityEditor;
using Rotorz.ReorderableList;

namespace Fangtang
{
    [CustomEditor(typeof(SceneElementManager))]
    public class SceneElementManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            SceneElementManager manager = target as SceneElementManager;

            if (target == null) return;

            if (_listAdaptor == null)
            {
                _listAdaptor = new GenericListAdaptor<SceneElement>(manager.Elements, ItemDrawer, 15);
            }
            if (_listControl == null)
            {
                _listControl = new ReorderableListControl(ReorderableListFlags.DisableDuplicateCommand | ReorderableListFlags.DisableContextMenu);
            }

            _listControl.Draw(_listAdaptor);
        }

        private void OnEnable()
        {
            MonoScript monoScript = MonoScript.FromMonoBehaviour(target as SceneElementManager);
            if (MonoImporter.GetExecutionOrder(monoScript) != -5000)
            {
                MonoImporter.SetExecutionOrder(monoScript, -5000);
            }
        }

        private SceneElement ItemDrawer(Rect position, SceneElement item)
        {
            if (item != null && string.IsNullOrEmpty(item.ID))
            {
                item.ID = item.GetType().ToString();
            }
            item = EditorGUI.ObjectField(position, 
                item != null ? item.ID : string.Empty, item, typeof(SceneElement), true) as SceneElement;
            return item;
        }

        private GenericListAdaptor<SceneElement> _listAdaptor;
        private ReorderableListControl _listControl;
    }
}
