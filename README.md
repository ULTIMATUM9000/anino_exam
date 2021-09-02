# SlotMachine

### Unity Version: 2020.3.7f1

**System Setup**
- GameManager.cs - Manages the starting of the Spin,Coins,Info Tab, Bet Amount, and Prize Amount.
- Row.cs - Attached to each Reel UI, manages the randomization of the Symbols and the spinning when the spin button is pressed.
- PayLineManager.cs - Manages the Lines that determine whether there are patterns in certain coordinates.
- AudioManager.cs - Stores audio so you can play it using code.
- Singleton.cs - Inherited by scripts that should only be one during a runtime.
- SymbolData.cs - ScriptableObject script that determines the prizes of certain combinations of a symbol.

**Data Sources**
- ScriptableObjects Folder - You can find the SymbolData ScriptableObjects, which determines the prizes when you get patterns, and edit it based on balancing.
- PayLineManager.cs - This is where you assign the SymbolData ScriptableObjects, and you can put the Pay Lines pattern here in the Inspector.
- AudioManager.cs - You assign audio files here and edit their values; Volume, Pitch, Pan Stereo, Loop, Min and Max Distance, etc.

**Additional Notes**
- You can expand the number of Pay Line patterns and Symbols, with just small changes to the Inspector and code itself.
- You can expand the number of Reels and Rows with some additional code.
- For future improvements, I would like to make the code more efficient in finding patterns through each Pay Lines, and more balancing for the prizes of each Symbol patterns. And maybe better assets.
