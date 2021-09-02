using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reel : MonoBehaviour
{
    public string[] Symbols;

    [SerializeField] TextMeshProUGUI[] rowText = new TextMeshProUGUI[3];

    float timeInterval;

    public bool rowStopped;
    public string[] stoppedSlot = new string[3];

	private void Update()
	{
        SetSlotMachineText();
	}

	private void Start()
	{
        rowStopped = true;
        GameManager.HandlePulled += StartRotating;
        stoppedSlot[0] = Symbols[Symbols.Length - 1];
        stoppedSlot[1] = Symbols[0];
        stoppedSlot[2] = Symbols[1];
    }

    private void StartRotating()
	{
        for(int i = 0; i < stoppedSlot.Length; i++)
		{
            stoppedSlot[i] = "";
		}
        StartCoroutine("Rotate");
	}

    private void SetSlotMachineText()
	{
        rowText[0].SetText(stoppedSlot[0].ToString());
        rowText[1].SetText(stoppedSlot[1].ToString());
        rowText[2].SetText(stoppedSlot[2].ToString());
	}

    private IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = Random.Range(0.025f, 0.05f);

        while (!GameManager.Instance.rollStopped)
		{
            //if (index == 0)
            //{
            //    stoppedSlot[0] = Symbols[Symbols.Length-1];
            //    stoppedSlot[1] = Symbols[0];
            //    stoppedSlot[2] = Symbols[1];
            //    index++;
            //}

            //if (index == Symbols.Length - 1)
            //{
            //    stoppedSlot[0] = Symbols[Symbols.Length-2];
            //    stoppedSlot[1] = Symbols[Symbols.Length-1];
            //    stoppedSlot[2] = Symbols[0];
            //    index = 0;
            //}
            //if (index > 0 && index < Symbols.Length - 1)
            //{
            //    stoppedSlot[0] = Symbols[index - 1];
            //    stoppedSlot[1] = Symbols[index];
            //    stoppedSlot[2] = Symbols[index + 1];
            //    index++;
            //}

            stoppedSlot[0] = Symbols[Random.Range(0, Symbols.Length - 1)];
            stoppedSlot[1] = Symbols[Random.Range(0, Symbols.Length - 1)];
            stoppedSlot[2] = Symbols[Random.Range(0, Symbols.Length - 1)];

            yield return new WaitForSeconds(timeInterval);
        }

        rowStopped = true;
	}
}
