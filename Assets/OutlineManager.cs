using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

    public class OutlineManager : MonoBehaviour
    {
        public static OutlineManager Instance = null;

        private void Awake()
        {
            Application.targetFrameRate = 100;
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            Instance = this;
        }


        public void ApplyOutline(GameObject g, Color c, bool enabled)
        {
        }
    }

