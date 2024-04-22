using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickPlayer : MonoBehaviour
{
    public List<GameObject> players;
    public GameObject _panel;
    public int playerIndex;

    public List<Image> images;

    private void Start()
    {
        images[0].color = Color.yellow;
    }

    public void OnGameStart()
    {
        players[playerIndex].SetActive(true);
        _panel.SetActive(false);
    }

    public void IndexChange(int index)
    {
        images[playerIndex].color = Color.white;
        int test = playerIndex + index;


        if (test > players.Count - 1)
        {
            playerIndex = 0;
            images[playerIndex].color = Color.yellow;
            return;
        }
        else if (test < 0)
        {
            playerIndex = players.Count - 1;
            images[playerIndex].color = Color.yellow;
            return;
        }

        playerIndex += index;
        images[playerIndex].color = Color.yellow;
    }


}
