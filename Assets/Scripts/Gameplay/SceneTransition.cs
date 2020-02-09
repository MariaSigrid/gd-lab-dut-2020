using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;


namespace Platformer.Mechanics
{
    public class SceneTransition : MonoBehaviour
    {
        public string NextSceneName;
        public float TransitionDelay = 2.0f;

        private bool isTransitionStarted = false;
        private float timeLeft;

        void Start()
        {
            if (!Application.CanStreamedLevelBeLoaded(NextSceneName)) {
                Debug.Log("Scene "+ NextSceneName + " cannot be loaded!");
            }
            timeLeft = TransitionDelay;
        }

        void Update()
        {
            if (isTransitionStarted) {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0) {
                    SceneManager.LoadScene(NextSceneName, LoadSceneMode.Single);
                }
            }
        }

        void StartSceneTransition() 
        {
            isTransitionStarted = true;
        }

        void OnTriggerEnter2D(Collider2D collider)
            {
                var p = collider.gameObject.GetComponent<PlayerController>();
                if (p != null)
                {
                    StartSceneTransition();
                }
            }
    }
}
