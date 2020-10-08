using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Name: DisplayDamage
 * Purpose: Displays the bloody image over the screen when hit
 */
public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Image dmgImg;
    [SerializeField] float dmgTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        dmgImg.enabled = false;
    }

    // ShowDamage starts the ienum for damage
    public void ShowDamage()
    {
        StartCoroutine(ShowDmg());
    }

    // ShowDmg enables and disables the blood image for a set time
    IEnumerator ShowDmg()
    {
        dmgImg.enabled = true;
        yield return new WaitForSeconds(dmgTime);
        dmgImg.enabled = false;
    }
}
