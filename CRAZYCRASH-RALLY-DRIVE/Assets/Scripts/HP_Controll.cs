using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Controll : MonoBehaviour
{
    public Scrollbar HealthPointsScrollBar;
    private GameObject Player;
    private PlayerMovement playerMove;
    private CarCollider carCollider;

    private bool hitted = false;
    private bool healed = false;
    private float decreaseValue;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        //playerMove = Player.GetComponent<PlayerMovement>();
        carCollider = Player.GetComponent<CarCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        HitValueCheck();
        if (carCollider.isThatFullHealthReverse == true)
        {
            ToolBoxReverseFullHealth();
        }
        if (carCollider.isThatFullHealthReverse == false)
        {
            ToolBoxReverse2Health();
        }
        if (carCollider.playerCollide == true)
        {
            DecreaseHP();
        }
        else if (carCollider.playerCollide == false)
        {
            hitted = false;
        }
        if (carCollider.toolBoxPicked == false)
        {
            healed = false;
        }
        if (carCollider.isPlayerDead == true)
        {
            HealthPointsScrollBar.value = 1f;
        }
    }

    private void DecreaseHP()
    {
        switch (decreaseValue)
        {
            case 1f:
                {
                    if (hitted == false)
                    {
                        HealthPointsScrollBar.value += 0.1f;
                        /*if (HealthPointsScrollBar.value == 0.9f)
                        {
                            HealthPointsScrollBar.value += 0.01f;
                        }*/
                        hitted = true;
                    }
                }
                break;
            case 2f:
                {
                    if (hitted == false)
                    {
                        HealthPointsScrollBar.value += 0.2f;
                        hitted = true;
                    }
                    
                }
                break;
            case 2.5f:
                {
                    if (hitted == false)
                    {
                        HealthPointsScrollBar.value += 0.25f;
                        hitted = true;
                    }

                }
                break;
            case 3.33f:
                {
                    if (hitted == false)
                    {
                        HealthPointsScrollBar.value += 0.33f;
                        /*if (HealthPointsScrollBar.value == 0.99f)
                        {
                            HealthPointsScrollBar.value += 0.01f;
                        }*/
                        hitted = true;
                    }

                }
                break;
            case 5f:
                {
                    if (hitted == false)
                    {
                        HealthPointsScrollBar.value += 0.5f;
                        hitted = true;
                    }

                }
                break;
        }
    }

    private void HitValueCheck()
    {
        if (carCollider.maxOsumat == 10)    //10 osumaa
        {
            decreaseValue = 1f;
        }
        else if (carCollider.maxOsumat == 5)    //5 osumaa
        {
            decreaseValue = 2f;
        }
        else if (carCollider.maxOsumat == 4)    //4 osumaa
        {
            decreaseValue = 2.5f;
        }
        else if (carCollider.maxOsumat == 3)    //3 osumaa
        {
            decreaseValue = 3.33f;
        }
        else if (carCollider.maxOsumat == 2)    //2 osumaa
        {
            decreaseValue = 5f;
        }
    }

    private void ToolBoxReverseFullHealth()
    {
        carCollider.isThatFullHealthReverse = true;
        if (carCollider.toolBoxPicked == true)
        {
            HealthPointsScrollBar.value = 0f;
            carCollider.toolBoxPicked = false;
        }
    }

    private void ToolBoxReverse2Health()
    {
        carCollider.isThatFullHealthReverse = false;
        if (carCollider.toolBoxPicked == true)
        {
            switch (decreaseValue)
            {
                case 1f:
                    {
                        if (healed == false)
                        {
                            if (HealthPointsScrollBar.value >= 0.2f)
                            {
                                HealthPointsScrollBar.value -= 0.2f;
                            }
                            else if (HealthPointsScrollBar.value == 0.1f)
                            {
                                HealthPointsScrollBar.value -= 0.1f;
                            }
                            healed = true;
                        }
                    }
                    break;
                case 2f:
                    {
                        if (healed == false)
                        {
                            if (HealthPointsScrollBar.value >= 0.6f)
                            {
                                HealthPointsScrollBar.value -= 0.4f;
                            }
                            else if (HealthPointsScrollBar.value <= 0.4f)
                            {
                                HealthPointsScrollBar.value = 0f;
                            }
                            healed = true;
                        }

                    }
                    break;
                case 2.5f:
                    {
                        if (healed == false)
                        {
                            if (HealthPointsScrollBar.value >= 0.5f)
                            {
                                HealthPointsScrollBar.value -= 0.5f;
                            }
                            else if (HealthPointsScrollBar.value < 0.5f)
                            {
                                HealthPointsScrollBar.value = 0f;
                            }
                            healed = true;
                        }

                    }
                    break;
                case 3.33f:
                    {
                        if (healed == false)
                        {
                            if (HealthPointsScrollBar.value <= 0.66f)
                            {
                                HealthPointsScrollBar.value = 0f;
                            }
                            healed = true;
                        }

                    }
                    break;
                case 5f:
                    {
                        if (healed == false)
                        {
                            if (HealthPointsScrollBar.value <= 0.5f)
                            {
                                HealthPointsScrollBar.value = 0f;
                            }
                            healed = true;
                        }

                    }
                    break;
            }
            carCollider.toolBoxPicked = false;
        }
    }
}
