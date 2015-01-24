using UnityEngine;

namespace Fangtang
{
    public abstract class SceneElement : MonoBehaviour
    {
        [SerializeField]
        public string ID;

        public abstract void OnInit();
    }
}
