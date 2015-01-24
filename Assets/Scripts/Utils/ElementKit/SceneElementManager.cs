using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;

namespace Fangtang
{
    public class SceneElementManager : MonoBehaviour
    {
        public List<SceneElement> Elements { get { return _elements; } }

        private void Awake()
        {
            _typeToElements = new Dictionary<Type, SceneElement>();
            for (int i = 0; i < _elements.Count; i++)
            {
                _typeToElements.Add(_elements[i].GetType(), _elements[i]);
            }

            for (int i = 0; i < _elements.Count; i++)
            {
                Inject(_elements[i]);
            }

            for (int i = 0; i < _elements.Count; i++)
            {
                _elements[i].OnInit();
            }
        }

        private void Inject(object obj)
        {
            if (obj == null) return;

            var members = obj.GetType().GetMembers();
            foreach (var memberInfo in members)
            {
                var injectAttribute =
                    memberInfo.GetCustomAttributes(typeof(InjectAttribute), true).FirstOrDefault() as InjectAttribute;
                if (injectAttribute != null)
                {
                    if (memberInfo is PropertyInfo)
                    {
                        var propertyInfo = memberInfo as PropertyInfo;
                        propertyInfo.SetValue(obj, Resolve(propertyInfo.PropertyType), null);
                    }
                    else if (memberInfo is FieldInfo)
                    {
                        var fieldInfo = memberInfo as FieldInfo;
                        fieldInfo.SetValue(obj, Resolve(fieldInfo.FieldType));
                    }
                }
            }
        }

        private object Resolve(Type type)
        {
            if (_typeToElements.ContainsKey(type))
            {
                return _typeToElements[type];
            }
            return null;
        }

        [SerializeField]
        private List<SceneElement> _elements;

        private Dictionary<Type, SceneElement> _typeToElements;
    }
}
