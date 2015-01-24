using UnityEngine;

namespace Fangtang
{
    public class ElementViewComponent<T> : MonoBehaviour, IElementView<T> where T : Component
    {
        public T Context
        {
            get
            {
                return _context;
            }
            private set
            {
                _context = value;
            }
        }

        public void Init(ElementViews<T> views, T context)
        {
            _views = views;
            Context = context;

            OnInit();
        }

        public R GetView<R>() where R : ElementViewComponent<T>
        {
            return _views.GetView<R>();
        }


        public virtual void Activate()
        {
            enabled = true;
        }

        public virtual void Deactivate()
        {
            enabled = false;
        }

        protected virtual void OnInit() { }

        [SerializeField]
        [HideInInspector]
        private T _context;

        private ElementViews<T> _views;
    }
}