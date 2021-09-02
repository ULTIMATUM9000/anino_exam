using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PayLine
{
    public List<int> payLine  = new List<int>(5); //array of the index of the slot machine
}

[System.Serializable]
public class PayLineList
{
    public List<PayLine> payLineList; 
}

public class PayOut
{
	public List<int> payOut;
}

public class PayOutList
{
	public List<PayOut> payOutList;
}

public class PayLineManager : Singleton<PayLineManager>
{
	enum SymbolEnum
	{
		A,	
		B,	
		C,	
		D,	
		E,	
		F,	
		G
	}

	[SerializeField] SymbolData[] symbolData;

	public PayLineList ListOfPayLines = new PayLineList(); //list of the different types of payline

	[SerializeField] int[] duplicateCounter;

	public void CheckPayLines()
	{
		for (int i = 0; i < GameManager.Instance.betValue; i++) //Finds the first item of the pay line list
		{
			for (int j = 0; j < GameManager.Instance.reels.Length; j++)
			{
				switch (GameManager.Instance.reels[j].stoppedSlot[ListOfPayLines.payLineList[i].payLine[j]])
				{
					case "A":
						duplicateCounter[0]++;
						break;
					case "B":
						duplicateCounter[1]++;
						break;
					case "C":
						duplicateCounter[2]++;
						break;
					case "D":
						duplicateCounter[3]++;
						break;
					case "E":
						duplicateCounter[4]++;
						break;
					case "F":
						duplicateCounter[5]++;
						break;
					case "G":
						duplicateCounter[6]++;
						break;
				}
			}

			for (int j = 0; j < symbolData.Length; j++) //Adds the specific combination payout
			{
				switch (duplicateCounter[j])
				{
					case 1:
						GameManager.Instance.prizeValue += symbolData[j].oneCombination;
						break;
					case 2:
						GameManager.Instance.prizeValue += symbolData[j].twoCombination;
						break;
					case 3:
						GameManager.Instance.prizeValue += symbolData[j].threeCombination;
						break;
					case 4:
						GameManager.Instance.prizeValue += symbolData[j].fourCombination;
						break;
					case 5:
						GameManager.Instance.prizeValue += symbolData[j].fiveCombination;
						break;
				}
			}

			for (int l = 0; l < duplicateCounter.Length; l++) //Reset Dupe Counter
			{
				duplicateCounter[l] = 0;
			}
		}
	}
}
