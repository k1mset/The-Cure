using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Name: GameEnding
 * Purpose: Sets the players game objective to complete
 */
public class GameEnding : MonoBehaviour
{
    [SerializeField] GameObject player;

    private CurrentObjective currObj;

    // Start is called before the first frame update
    void Start()
    {
        currObj = player.GetComponent<CurrentObjective>();
    }

    public void SetEndGame()
    {
        currObj.setComplete();
    }
}
