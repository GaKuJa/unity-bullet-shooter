using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Pooling
{
    public class ObjectPool<T> where T : Component
    {
        private readonly T prefab;
        private readonly Transform parent;
        private readonly Action<T> onCreated;
        private readonly Queue<T> availableInstances = new Queue<T>();

        public ObjectPool(T prefab, Transform parent, int initialSize, Action<T> onCreated = null)
        {
            this.prefab = prefab;
            this.parent = parent;
            this.onCreated = onCreated;

            for (int i = 0; i < initialSize; i++)
            {
                availableInstances.Enqueue(CreateInstance());
            }
        }

        public T Rent()
        {
            T instance = availableInstances.Count > 0 ? availableInstances.Dequeue() : CreateInstance();
            instance.gameObject.SetActive(true);
            return instance;
        }

        public void Return(T instance)
        {
            instance.gameObject.SetActive(false);
            availableInstances.Enqueue(instance);
        }

        private T CreateInstance()
        {
            T instance = UnityEngine.Object.Instantiate(prefab, parent);
            instance.gameObject.SetActive(false);
            onCreated?.Invoke(instance);
            return instance;
        }
    }
}
