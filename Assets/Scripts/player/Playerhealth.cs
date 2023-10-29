using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{

  
    public int playerhealthProBalken; 
    public int currenthealthOfAffectedHealthbar;
    public int Lebensbalken;
    public Showhealthbar healthbar;
    public ShowXP xp;

    public bool[] LebensbalkenDieNochDaSind ;
    public int onCurrentLebensBalken;

    public int currentLevelNumber;
    public int currentXP;
    public int currentXPtonextLevelup;
    public bool isinvincible;

    public int[] XpofLevel = {0, 0,   12,  30,  40,  90,  160,
                              220, 450, 408, 650, 700, 1100,
                              1500,  2200,  2600,  4100,  3000,
                              5500,    7200,    10040, 
    };

    public int[] LebenProBalkenAnJedemLevel = {0,  4,  6,  6,   10,  15,
                                               20, 24, 20, 28,  34,
                                               40, 50, 60, 66,  72,
                                               60, 66, 74, 84,  80
    };


    public int[] BalkenAnJedemLevel =         {0,  2,  2,  3,   3,   3,
                                               3,  4,  4,  4,   4,
                                               4,  4,  4,  4,   4,
                                               5,  5,  5,  5,   6
    };
    public void Awake()
    {
        currentXP = 1;
        if(currentLevelNumber == 0) currentLevelNumber = 1;
        xp = FindFirstObjectByType<ShowXP>();
        xp.Setxpholder(this);
      
        isinvincible = false;
        GetcurrentXPLevel();
        healthbar = FindFirstObjectByType<Showhealthbar>();
       
       
    }


    public void takedamage(int amount)
    {

        if (!isinvincible)
        {
          
            currenthealthOfAffectedHealthbar -= amount;

            healthbar.Changehealth(onCurrentLebensBalken-1);

            if(currenthealthOfAffectedHealthbar <= 0)
            {
              
                onCurrentLebensBalken -= 1;
                currenthealthOfAffectedHealthbar = playerhealthProBalken;
                if (onCurrentLebensBalken <= 0) Debug.Log("player is now Dead");
            }
            healthbar.Changehealth(onCurrentLebensBalken - 1);





            isinvincible = true;
            StartCoroutine(Invinciblity());

            // playerflash kreieren
            // wir instantiaten den Damageframe wie bei z.b. Hollow Knight und haben den Spieler dann in einem 0.5 invincibility moment

        }
        


    }

    public IEnumerator Invinciblity()
    {
        yield return new WaitForSeconds(1.5f);
        isinvincible = false;
     
    }




    public void Healplayer(int amount)
    {
       
        currenthealthOfAffectedHealthbar += amount;
        currenthealthOfAffectedHealthbar = Mathf.Clamp(currenthealthOfAffectedHealthbar, 0, playerhealthProBalken);
        Debug.Log("Healed");
        healthbar.Changehealth(onCurrentLebensBalken - 1);
        if (currenthealthOfAffectedHealthbar >= playerhealthProBalken && onCurrentLebensBalken+1 <= Lebensbalken )
        {
           
            onCurrentLebensBalken += 1;
            currenthealthOfAffectedHealthbar = 1;
            healthbar.Changehealth(onCurrentLebensBalken - 1);
            healthbar.HealaHealthOrb(onCurrentLebensBalken - 1);
        }
        
      //  if (currenthealthOfAffectedHealthbar == playerhealthProBalken) ; //getafullhealthbar and start the next healthbar with 1 Hp 

    }



    public void GetXp(int amount)
    {
        currentXP += amount;
        xp.changeXpUi();
        while(currentXP >= currentXPtonextLevelup)
        {
            currentLevelNumber++;
            currentXP -= currentXPtonextLevelup;
            GetcurrentXPLevel();
            //getinfos and upgrade Lebensbalken und Leben pro Balken
        }

    }

    public void GetcurrentXPLevel()
    {
        if (currentLevelNumber > 1)
        {
            Lebensbalken = BalkenAnJedemLevel[currentLevelNumber];
            playerhealthProBalken = LebenProBalkenAnJedemLevel[currentLevelNumber];
            currentXPtonextLevelup = XpofLevel[currentLevelNumber];

            onCurrentLebensBalken = Lebensbalken;
            currenthealthOfAffectedHealthbar = playerhealthProBalken;

            for(int i = 0; i<6 ; i++)
            {
                if (BalkenAnJedemLevel[i] >= i)
                {
                    LebensbalkenDieNochDaSind[i] = true;
                } else LebensbalkenDieNochDaSind[i] = false;
            }


        }
        else
        {
            currentXPtonextLevelup = XpofLevel[2];
            Lebensbalken = BalkenAnJedemLevel[currentLevelNumber];
            playerhealthProBalken = LebenProBalkenAnJedemLevel[currentLevelNumber];
        //    currentXPtonextLevelup = XpofLevel[currentLevelNumber];
            onCurrentLebensBalken = Lebensbalken;
            currenthealthOfAffectedHealthbar = playerhealthProBalken;

            LebensbalkenDieNochDaSind[1] = true;
            LebensbalkenDieNochDaSind[2] = true;

        }
       
        FindAnyObjectByType<Showhealthbar>().Setupthehealthbars(Lebensbalken);

        xp.LevelUpUi();
        xp.changeXpUi();
    }


    #region
    /*            |   Lebensbalken |     Health pro Lebensbalken  |     Xp nur für das momentane Level   |

       Level  1      |     2       |      4                       |   
       Level  2      |     2       |      6                       |     12
       Level  3      |     3       |      6                       |     30
       Level  4      |     3       |      10                      |     40
       Level  5      |     3       |      15                      |     90
       Level  6      |     3       |      20                      |     160
       Level  7      |     3       |      24                      |     220
       Level  8      |     4       |      20                      |     450
       Level  9      |     4       |      28                      |     408
       Level  10     |     4       |      34                      |     650           (2060 xp insgesamt)
       Level  11     |     4       |      40                      |     700           
       Level  12     |     4       |      50                      |     1100
       Level  13     |     4       |      60                      |     1500
       Level  14     |     4       |      66                      |     2200
       Level  15     |     4       |      72                      |     2600
       Level  16     |     5       |      60                      |     4100          (14260 xp insgesamt)
       Level  17     |     5       |      66                      |     3000
       Level  18     |     5       |      74                      |     5500
       Level  19     |     5       |      84                      |     7200
       Level  20     |     6       |      80                      |     10040         (40000 xp insgesamt)
      */

    #endregion
}
