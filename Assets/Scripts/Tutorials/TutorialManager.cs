using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public enum SimpleTutorialTypes
    {
        Drag,
        DragCircle,
        Hold,
        Swipe,
        Tap
    }
    public enum DragDropTutorialTypes
    {
        DragDropGUI,
        DragDropWorld
    }
    public static class TutorialManager
    {
        private static List<GameObject> _tutorials = new List<GameObject>();

        private static GameObject _canvas;

        public static GameObject CreateSimpleTutorial(SimpleTutorialTypes simpleTutorialTypes)
        {
            if (_tutorials.Count == 0) GetSimpleTutorials();

            if (_canvas == null) CreateCanvas();

            GameObject tutorial = Object.Instantiate(_tutorials[(int)simpleTutorialTypes], _canvas.transform);
  
            tutorial.SetActive(true);
            
            return tutorial;
        }

        /// <summary>
        /// Create drag and drop tutorial. You should give base and target position.
        /// </summary>
        /// <param name="dragDropTutorialTypes"></param>
        /// <param name="basePosition"></param>
        /// <param name="targetPosition"></param>
        /// <returns></returns>
        public static GameObject CreateDragDropTutorial(DragDropTutorialTypes dragDropTutorialTypes, Transform basePosition, Transform targetPosition)
        {
            if (_tutorials.Count == 0) GetSimpleTutorials();

            if (_canvas == null) CreateCanvas();

            GameObject tutorial = null;

            switch (dragDropTutorialTypes)
            {
                case DragDropTutorialTypes.DragDropGUI:

                    tutorial = Object.Instantiate(Resources.Load<GameObject>("CustomTutorials/DragDropGUITutorial"), _canvas.transform);

                    var dragDropGUITutorial = tutorial.GetComponent<DragDropGUI>();

                    dragDropGUITutorial.SetPosition(basePosition, targetPosition);

                    break;

                case DragDropTutorialTypes.DragDropWorld:

                    tutorial = Object.Instantiate(Resources.Load<GameObject>("CustomTutorials/DragDropWorldTutorial"), _canvas.transform);

                    var dragDropWorldTutorial = tutorial.GetComponent<DragDropWorld>();

                    dragDropWorldTutorial.SetPosition(basePosition, targetPosition);

                    break;
            }
            tutorial.SetActive(true);
            return tutorial;
        }
        public static GameObject CreateTapWorld(Transform targetPosition)
        {
            if (_tutorials.Count == 0) GetSimpleTutorials();

            if (_canvas == null) CreateCanvas();

            GameObject tutorial = Object.Instantiate(Resources.Load<GameObject>("SimpleTutorials/TapWorldTutorial"), _canvas.transform);

            var tapWorldTutorial = tutorial.GetComponent<TapTutorial>();

            tapWorldTutorial.SetPosition(targetPosition);

            tutorial.SetActive(true);

            return tutorial;
        }
        public static void HideTutorial(GameObject tutorial)
        {
            tutorial.SetActive(false);
        }

        /// <summary>
        /// Get simple tutorials in the resources folder.
        /// </summary>
        private static void GetSimpleTutorials()
        {
            var tutorialResources = Resources.LoadAll<GameObject>("SimpleTutorials");

            foreach (var tutorial in tutorialResources)
            {
                _tutorials.Add(tutorial);
            }
        }

        /// <summary>
        /// Create ready canvas.
        /// </summary>
        private static void CreateCanvas()
        {
            var canvasResources = Resources.Load<GameObject>("Canvas");

            _canvas = Object.Instantiate(canvasResources);
        }
    }
}