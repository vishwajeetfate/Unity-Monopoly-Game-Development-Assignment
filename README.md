# Unity-Monopoly-Game-Development-Assignment

A simplified digital board game built in Unity (2025), featuring property trading, rent, jail, chance tiles, and a complete UI system.

📆 Project Summary
This 2-player local multiplayer board game replicates core mechanics from Monopoly/Bankroll. Players roll dice, move around a 24-tile square board, purchase properties, and interact with Chance and Jail systems. The gameplay is turn-based, supports all UI panels, and logs every major event.

📂 Contents
🧱 Board Layout & Tile System

🧍‍♂️ Player Mechanics

💸 Property System

🚓 Jail Logic

🎲 Dice Mechanics

🎨 Full User Interface

🧾 Transaction Log

⚖️ Turn Management

🧱 Board Design
Total Tiles: 24 (square layout)

Tile Types:

🏙 City Properties (buyable, rent-based)

⚡ Utility (Electric Co., 15% rent)

🚆 Railway, ✈️ Airport, ⚓ Harbor (cosmetic)

🎲 Chance Tiles (random money events)

🚓 Jail Tile (3-turn lock)

⏩ Go To Jail (send player directly)

🌟 Start Tile (+$200 bonus when passed)

🎮 Gameplay Flow
Each player takes a turn rolling a 6-sided dice.

Players move clockwise on the board.

On landing:

Buy unowned properties

Pay rent to opponents

Trigger random effects from Chance

Get locked in jail for 3 turns (can't move)

Receive $200 when passing Start

🧍‍♂️ Player System
2 Players: "Player 1" and "Player 2"

Each player has:

A name

Money ($1500 starting)

List of owned properties

Jail status and countdown

💸 Property System
Buy unowned properties

Price varies by tile index

Rent = 10% of price (utilities: 15%)

Automatically pay rent when landing on owned property

Cannot buy already-owned property

🚓 Jail System
Sent to jail via tile or Chance event

Held for 3 turns

Cannot roll or move while jailed

Still collects rent from owned properties

🎲 Dice Mechanics
Clickable dice button rolls 1–6

Visual dice animation (sprite-based)

Final result shown in text

Player moves accordingly

🎨 UI Features
✅ Turn indicator (whose turn)

✅ Player money and owned property count

✅ Dice result display

✅ Property info panel

✅ Buy / Skip / End Turn buttons

✅ Transaction log (scrolling history)

✅ Win screen when one player remains

🧾 Transaction Log
Live log shows:

Dice rolls

Property purchases

Rent payments

Chance gains/losses

Jail entries and releases

Bankruptcy/eliminations

⚙️ Technical Overview
Language: C#

Engine: Unity 2021+ (2D URP)

Architecture:

Tile base class → extended by PropertyTile, ChanceTile, JailTile, etc.

Player.cs manages movement, money, and ownership

UIManager.cs handles all UI logic and logging

GameManager.cs controls turn flow and game state

✅ Features Implemented
✅ Turn-based player system

✅ Tile interaction with logic

✅ Random Chance (90% lose, 10% gain)

✅ Jail logic with countdown

✅ Dice roll animation

✅ Elimination on bankruptcy

✅ Win screen on last player

✅ Full UI integration

🧠 Future Improvements
🔁 Property trading

🌐 AI or online multiplayer

💬 Localization support

💡 Special abilities or events

✨ Visual polish (e.g., FX on special tiles)

📁 Project Structure
markdown
Copy
Edit
Assets/
├── Scripts/
│   ├── GameManager.cs
│   ├── UIManager.cs
│   ├── Player.cs
│   ├── BoardManager.cs
│   └── Tiles/
│       ├── Tile.cs
│       ├── PropertyTile.cs
│       ├── ChanceTile.cs
│       ├── JailTile.cs
│       ├── GoToJailTile.cs
│       ├── UtilityTile.cs
│       └── SpecialTile.cs
├── Prefabs/
│   ├── TilePrefab
│   └── PlayerPrefab
└── UI/
    ├── DiceButton, BuyButton, SkipButton, EndTurnButton
    ├── PlayerInfo Panels
    ├── PropertyInfoPanel
    ├── TransactionLog ScrollView
    └── WinScreenPanel
🏁 Credits
Developed by: Vishwajeet Fate
Built for: Game Developer Assignment 2025

