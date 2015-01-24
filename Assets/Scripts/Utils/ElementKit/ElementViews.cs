using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Fangtang
{
    public sealed class ElementViews<T> where T : Component
    {
        public T Context { get { return _context; } }

        public ElementViews(T context)
        {
            _views = new Dictionary<System.Type, ElementViewComponent<T>>();
            _context = context;
        }

        public void AddView(ElementViewComponent<T> view)
        {
            view.Init(this, _context);
            _views[view.GetType()] = view;
        }

        public R GetView<R>() where R : ElementViewComponent<T>
        {
            System.Type viewType = typeof(R);

#if UNITY_EDITOR
            if (!_views.ContainsKey(viewType))
            {
                var error = GetType() + ": view " +
                    viewType + " does not exist. Did you forget to add it by calling AddView?";
                Debug.LogError(error);
                throw new System.Exception(error);
            }
#endif

            return _views[viewType] as R;
        }

        protected T _context;
        private Dictionary<System.Type, ElementViewComponent<T>> _views;
    }
}