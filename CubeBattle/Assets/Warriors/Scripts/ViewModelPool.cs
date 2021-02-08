using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeBattle.Units.View.Pool
{
    public class ViewModelPool
    {
        private readonly ModelViewStorage storage;

        private Dictionary<WarriorViewType, Stack<ModelView>> pool = new Dictionary<WarriorViewType, Stack<ModelView>>();

        public ViewModelPool(ModelViewStorage storage)
        {
            this.storage = storage;
        }

        public void Push(ModelView view)
        {
            ModelDeactive(view);

            if (pool.TryGetValue(view.Type, out var stack))
            {
                if(stack == null)
                {
                    stack = new Stack<ModelView>();
                }

                stack.Push(view);
                return;
            }

            pool.Add(view.Type, new Stack<ModelView>());
            pool[view.Type].Push(view);
        }

        public ModelView Pop(WarriorViewType type)
        {
            if(pool.TryGetValue(type, out var stack))
            {
                if(stack != null && stack.Count > 0)
                {
                    return stack.Pop();
                }
            }

            return CreateNewPrefab(type);
        }

        private void ModelDeactive(ModelView view)
        {
            view.gameObject.SetActive(false);
            view.transform.SetParent(null);
            view.transform.position = Vector3.one * 100;
        }

        private ModelView CreateNewPrefab(WarriorViewType type)
        {
            return GameObject.Instantiate(storage.GetModelView(type), Vector3.zero, Quaternion.identity);
        }
    }
}