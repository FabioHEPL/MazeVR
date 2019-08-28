using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Client
{
    [CreateAssetMenu]
    public class Selection : ScriptableObject
    {
        [SerializeField]
        private Highlight highlight;
        [SerializeField]
        private int maxLength = 2;

        public GameObject[] Elements => elements.ToArray();

        private List<GameObject> elements;
        private int length = 0;
        private Dictionary<GameObject, Highlight> highlightMap;

        public void Awake()
        {

        }

        public void OnEnable()
        {
            this.elements = new List<GameObject>();
            this.highlightMap = new Dictionary<GameObject, Highlight>();
            length = 0;
        }

        public void Include(GameObject gameObject)
        {
            // add to collection
            if (elements.Contains(gameObject))
            {
                Remove(gameObject);
            }
            else
            {
                if (elements.Count < maxLength)
                {
                    Add(gameObject);
                }
                else
                {
                    PopAdd(gameObject);
                }
            }
        }

        private void Add(GameObject gameObject)
        {
            ApplyEffect(gameObject);
            elements.Add(gameObject);
        }

        private void PopAdd(GameObject gameObject)
        {
            Remove(elements[0]);
            Add(gameObject);
        }

        private void Remove(GameObject gameObject)
        {
            RemoveEffect(gameObject);
            elements.Remove(gameObject);
        }

        private void ApplyEffect(GameObject gameObject)
        {
            Highlight highlight = ScriptableObject.CreateInstance<Highlight>();
            highlight.Initialise(this.highlight.Material);
            highlight.Apply(gameObject);
            highlightMap.Add(gameObject, highlight);
        }

        private void RemoveEffect(GameObject gameObject)
        {
            Highlight highlight = highlightMap[gameObject];
            highlight.Undo();
            highlightMap.Remove(gameObject);
        }
    }

}