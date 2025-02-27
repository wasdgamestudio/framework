﻿using UnityEngine;
using UnityEngine.UI;

namespace Utilities
{
    [AddComponentMenu("Game/UI/FPS Counter")]
    public class FPSCounter : TickBehaviour
    {
        [SerializeField] private TMPro.TMP_Text FPSText;
        public float RefreshRate;
        void Start()
        {
            Application.targetFrameRate = 60;
            InvokeRepeating("UpdateFrameRateOnScreen", 0, RefreshRate);
            //if that component does not have a text assigned, it will look locally for a text component.
            if (FPSText == null && GetComponent<Text>() != null) { FPSText = GetComponent<TMPro.TMP_Text>(); }
        }
        public void UpdateFrameRateOnScreen()
        {
            if (FPSText != null)
            {
                FPSText.text = GetFrameRate() + "FPS";
                FPSText.color = Color.Lerp(Color.red, Color.green, GetFrameRate() / 60f);
            }
        }
        /// <summary>
        /// Returns the value of the FPS(Frames per second) at the time it is called
        /// </summary>
        /// <returns></returns>
        public static int GetFrameRate()
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            return fps;
        }
    }
}