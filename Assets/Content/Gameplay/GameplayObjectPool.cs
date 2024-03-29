﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Content.Gameplay
{
    public class GameplayObjectPool<T> where T : MonoBehaviour
    {
        private const int InvalidPoolIndex = -1;

        private List<T> _pool = new();
        private readonly int _poolSize;

        public GameplayObjectPool(int poolSize)
        {
            _poolSize = poolSize;
        }

        public T GetObject(out int objectPoolId)
        {
            objectPoolId = InvalidPoolIndex;
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].gameObject.activeInHierarchy)
                {
                    objectPoolId = i;
                    _pool[i].gameObject.SetActive(true);
                    return _pool[i];
                }
            }

            return null;
        }

        public void ReleaseObject(int objectPoolId)
        {
            if (objectPoolId == InvalidPoolIndex)
                return;

            _pool[objectPoolId].gameObject.SetActive(false);
        }

        public void CreatePool(Func<T> constructionMethod, Action<T> onConstructionComplete = null)
        {
            for (int i = 0; i < _poolSize; i++)
            {
                T poolObject = constructionMethod();
                onConstructionComplete?.Invoke(poolObject);

                _pool.Add(poolObject);
            }
        }

        public void ClearPool() => _pool = new List<T>();
    }
}