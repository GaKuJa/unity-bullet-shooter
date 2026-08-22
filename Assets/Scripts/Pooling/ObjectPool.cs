using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Pooling
{
    public class ObjectPool<T> where T : Component
    {
        private readonly T _prefab;
        private readonly Transform _parent;
        private readonly Action<T> _onCreated;
        private readonly Queue<T> _availableInstances = new Queue<T>();

        public ObjectPool(T prefab, Transform parent, int initialSize, Action<T> onCreated = null)
        {
            _prefab = prefab;
            _parent = parent;
            _onCreated = onCreated;

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

        public void Return(T instance)
        {
            instance.gameObject.SetActive(false);
            _availableInstances.Enqueue(instance);
        }

        private T CreateInstance()
        {
            T instance = UnityEngine.Object.Instantiate(_prefab, _parent);
            instance.gameObject.SetActive(false);
            _onCreated?.Invoke(instance);
            return instance;
        }
    }
}
