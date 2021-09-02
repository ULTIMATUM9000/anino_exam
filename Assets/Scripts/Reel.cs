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
        timeInterval = 0.05f;

        while (!GameManager.Instance.rollStopped)
		{
            stoppedSlot[0] = Symbols[Random.Range(0, Symbols.Length - 1)];
            stoppedSlot[1] = Symbols[Random.Range(0, Symbols.Length - 1)];
            stoppedSlot[2] = Symbols[Random.Range(0, Symbols.Length - 1)];

            yield return new WaitForSeconds(timeInterval);
        }

        yield return new WaitForSeconds(timeInterval);

        rowStopped = true;
	}
}
