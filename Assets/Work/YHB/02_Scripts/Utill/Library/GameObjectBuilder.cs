using System;
using UnityEngine;

namespace Library
{
    public class GameObjectBuilder
    {
        private GameObject target;

        public GameObjectBuilder()
        {
            target = new GameObject();
        }

        public GameObjectBuilder(GameObject obj)
        {
            target = obj;
        }

        public GameObjectBuilder SetName(string name)
        {
            target.name = name;
            return this;
        }

        public GameObjectBuilder SetStatic(bool isStatic)
        {
            target.isStatic = isStatic;
            return this;
        }

        public GameObjectBuilder SetTag(string tag)
        {
            target.tag = tag;
            return this;
        }

        public GameObjectBuilder SetLayer(int layer)
        {
            target.layer = layer;
            return this;
        }

        public GameObjectBuilder SetParent(Transform parent)
        {
            target.transform.parent = parent;
            return this;
        }

        public GameObjectBuilder SetPosition(Vector3 position)
        {
            target.transform.position = position;
            return this;
        }

        public GameObjectBuilder SetRotation(Quaternion rotation)
        {
            target.transform.rotation = rotation;
            return this;
        }

        public GameObjectBuilder SetRotation(Vector3 rotation)
        {
            target.transform.rotation = Quaternion.Euler(rotation);
            return this;
        }

        public GameObjectBuilder SetScale(float scale)
        {
            target.transform.localScale = Vector3.one * scale;
            return this;
        }

        public GameObjectBuilder SetScale(Vector3 scale)
        {
            target.transform.localScale = scale;
            return this;
        }

        public GameObjectBuilder SetActive(bool active)
        {
            target.SetActive(active);
            return this;
        }

        public GameObjectBuilder SetComponent<T>(Action<T> func) where T : Component
        {
            func(target.transform.TryAddComponent<T>());
            return this;
        }

#if UNITY_EDITOR
        public GameObjectBuilder Debug(object str)
        {
            UnityEngine.Debug.Log(str);
            return this;
        }

        public GameObjectBuilder Debug(Action func)
        {
            func();
            return this;
        }
#endif
        public GameObject Build() => target;
    }
}