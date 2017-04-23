﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour {

    public static bool winning = false;


	public void win()
    {
        StartCoroutine(winCycle());
        winning = true;
    }

    IEnumerator winCycle()
    {
        fullDialogue dio = Player.Instance.GetComponent<fullDialogue>();

        Player.Instance.WorldInteraction.stateBools.canMove = false;
        Player.Instance.GetComponent<NavMeshAgent>().Stop();

        dio.showCustomDialogue("I did it!");
        yield return new WaitForSeconds(3);

        dio.showCustomDialogue("I finally have my own place to move into!");
        yield return new WaitForSeconds(3);

        dio.showCustomDialogue("I wish my dad was here... He'd be proud");
        yield return new WaitForSeconds(3);

        FadeManager.Instance.Fade(true, 4);
        dio.showCustomDialogue("Time to start a new life...");
        yield return new WaitForSeconds(3);
        dio.endDialogue();

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("opening menu");
    }
}
