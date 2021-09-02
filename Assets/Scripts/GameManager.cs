using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : Singleton<GameManager>
{
    public static event Action HandlePulled = delegate { };

    public Reel[] reels;

    public TextMeshProUGUI prizeText;
    public TextMeshProUGUI betText;
    public TextMeshProUGUI coinText;

    [SerializeField] Button addBetButton;
    [SerializeField] Button subtractBetButton;
    [SerializeField] Button spinButton;

    public bool rollStopped = true;
    public int betValue;
    public int prizeValue;
    public int coinValue;

	private void Update()
	{
        betText.SetText(betValue.ToString());
        prizeText.SetText(prizeValue.ToString());
        coinText.SetText(coinValue.ToString());
        ButtonFunctionality();
	}

	private void Start()
	{
        coinValue = 20000;
        betValue = 1;
	}

	public void SpinButton()
    {

        if(coinValue >= betValue * 20)
		{
            if (rollStopped)
            {
                rollStopped = false;
                coinValue -= betValue * 20;
                prizeValue = 0;
                AudioManager.Instance.Play("Spin");
                if (reels[0].rowStopped && reels[1].rowStopped && reels[2].rowStopped && reels[3].rowStopped && reels[4].rowStopped)
                {
                    HandlePulled();
                }
                return;
            }
        }
        
        if(!rollStopped)
		{
            if (!reels[0].rowStopped && !reels[1].rowStopped && !reels[2].rowStopped && !reels[3].rowStopped && !reels[4].rowStopped)
            {
                AudioManager.Instance.Play("SpinStop");

                rollStopped = true;

                PayLineManager.Instance.CheckPayLines();

                coinValue += prizeValue;
            }
            return;
		}
        
    }

    public void ButtonFunctionality()
	{
        addBetButton.interactable = betValue == 20 ? false : true;
		subtractBetButton.interactable = betValue == 1 ? false : true;

        if(rollStopped)
		{
            spinButton.interactable = coinValue >= betValue * 20 ? true : false;
        }
    }

    public void AddBet()
	{
        betValue++;
        AudioManager.Instance.Play("BetIncrease");
    }

    public void SubtractBet()
	{
		betValue--;
        AudioManager.Instance.Play("BetDecrease");
    }

	public void OpenInfo()
	{
        CanvasManager.Instance.SecondaryCanvas(CanvasType.InfoUI);
        AudioManager.Instance.Play("ButtonClicked");
	}

    public void CloseInfo()
    {
        CanvasManager.Instance.TurnOffSecondaryCanvas(CanvasType.InfoUI); 
        AudioManager.Instance.Play("ButtonClicked");
    }
}
