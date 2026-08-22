using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Pooling
{
    public class ObjectPool<T> where T : Component
    {
        private readonly T _prefab;
        private readonly Transform _parent;
        private readonly Queue<T> _availableInstances = new Queue<T>();

        public ObjectPool(T prefab, Transform parent, int initialSize)
        {
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                _availableInstances.Enqueue(CreateInstance());
            }
        }

        public T Rent()
        {
            T instance = _availableInstances.Count > 0 ? _availableInstances.Dequeue() : CreateInstance();
            instance.gameObject.SetActive(true);
            return instance;
        }

        protected void Return(T instance)
        {
            instance.gameObject.SetActive(false);
            _availableInstances.Enqueue(instance);
        }

        protected virtual T CreateInstance()
        {
            T instance = UnityEngine.Object.Instantiate(_prefab, _parent);
            instance.gameObject.SetActive(false);
            return instance;
        }
    }
}
