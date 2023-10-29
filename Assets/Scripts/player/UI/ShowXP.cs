using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowXP : MonoBehaviour
{

    public Text maxXP;
    public Text currentXP;
    public Playerhealth xpholder;
    public Slider slider;

    public void Setxpholder(Playerhealth xp)
    {
        xpholder = xp;
    }
    public void changeXpUi()
    {
        slider.value = xpholder.currentXP;
        currentXP.text = xpholder.currentXP.ToString();
        slider.maxValue = xpholder.currentXPtonextLevelup;
        maxXP.text = xpholder.currentXPtonextLevelup.ToString();
    }
    public void LevelUpUi()
    {
        slider.maxValue = xpholder.currentXPtonextLevelup;
        changeXpUi();
        maxXP.text = xpholder.currentXPtonextLevelup.ToString();

    }
}
