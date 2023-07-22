using System.Collections;
using System.Collections.Generic;
using Tutorial;
using Tutorial.Extensions;
using UnityEngine;

public class TutorialTest : MonoBehaviour
{
    GameObject _tutorial;
    void Start()
    {
        _tutorial = TutorialManager.CreateSimpleTutorial(SimpleTutorialTypes.Drag).AddCreateAnim(delay:1f);

        _tutorial.AddHideAnim(delay:3f);
    }

}
