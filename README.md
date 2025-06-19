# Unity-Monopoly-Game-Development-Assignment

# 🎲 monopoly-clone-unity

A 2D Monopoly-style board game built in Unity (2025). Designed for a 2-player local multiplayer experience, this project features dice rolls, property acquisition, rent mechanics, chance events, jail system, and a full user interface with live transaction logs.

---

## 📆 Project Summary

This project was developed for the **Game Developer Assignment 2025**. It replicates core Monopoly-style gameplay mechanics with a clean UI and object-oriented structure, entirely in Unity using C#.

---

## 📂 Contents

- 🧱 Board Layout & Tile System  
- 🧍‍♂️ Player Mechanics  
- 💸 Property System  
- 🚓 Jail Logic  
- 🎲 Dice Mechanics  
- 🎨 Full User Interface  
- 🧾 Transaction Log  
- ⚖️ Turn Management  

---

## 🧱 Board Design

- **Total Tiles:** 24 arranged in a square layout
- **Tile Types:**
  - 🏙 City Properties (buyable, rent-based)
  - ⚡ Utility (Electric Co., 15% rent)
  - 🚆 Railway, ✈️ Airport, ⚓ Harbor (cosmetic only)
  - 🎲 Chance (random 10–30% loss or 50% gain)
  - 🚓 Jail (3-turn lock)
  - ⏩ Go To Jail (send player to jail)
  - 🏁 Start (collect $200 when passed)

---

## 🎮 Gameplay Flow

1. Players alternate turns rolling a 6-sided dice.
2. Movement is clockwise across the board.
3. On landing:
   - **Unowned Property** → option to buy or skip
   - **Opponent’s Property** → pay rent
   - **Chance Tile** → lose/gain money
   - **Go To Jail** → get locked for 3 turns
   - **Pass Start** → collect $200

---

## 🧍‍♂️ Player System

- 2 Players: “Player 1” and “Player 2”
- Each has:
  - Starting money: `$1500`
  - Jail state & 3-turn countdown
  - List of owned properties

---

## 💸 Property System

- Property price varies by index
- Rent = 10% of price, 15% for utility
- Cannot buy owned properties
- Auto-pays rent on landing
- Displays property info in panel

---

## 🚓 Jail System

- Triggered via Chance or Jail tiles
- Player is frozen for 3 full turns
- Cannot roll or move, but can collect rent

---

## 🎲 Dice Mechanics

- Roll 1–6 with button
- Animated visual dice
- Movement and log triggered by roll

---

## 🎨 UI Features

- ✅ Player status panel (money, property count)
- ✅ Current turn display
- ✅ Dice result display
- ✅ Buy, Skip, and End Turn buttons
- ✅ Property info panel
- ✅ Transaction log with all actions
- ✅ Win screen on player elimination

---

## 🧾 Transaction Log

Live event log includes:
- Dice rolls
- Property buys
- Rent transfers
- Jail entries/exits
- Chance gains/losses
- Bankruptcies

---

## ⚙️ Technical Overview

- Language: C#
- Engine: Unity 2021.3+ (2D URP)
- Architecture:
  - `Tile` base class extended by: `PropertyTile`, `ChanceTile`, `JailTile`, etc.
  - Singleton managers: `GameManager`, `UIManager`
  - Modular scripts for all logic systems

---

## ✅ Features Implemented

- ✅ Turn system with UI
- ✅ Dynamic board & tiles
- ✅ Rent, jail, and purchase mechanics
- ✅ Dice roll animation
- ✅ Player elimination
- ✅ Win screen logic
- ✅ Fully functional and responsive UI

---

## 🧠 Future Improvements

- 🔁 Property trading
- 🌐 Online multiplayer or AI
- 🎨 Special tile effects
- 🧠 Smarter turn options
- 💬 Multilingual support

---

## 📁 Project Structure


📁 Project Structure

Assets/
├── _Project/
│   ├── Scripts/
│   │   ├── Managers/
│   │   │   ├── GameManager.cs
│   │   │   ├── UIManager.cs
│   │   │   └── BoardManager.cs
│   │   ├── Player/
│   │   │   └── Player.cs
│   │   ├── Tiles/
│   │   │   ├── Tile.cs
│   │   │   ├── PropertyTile.cs
│   │   │   ├── ChanceTile.cs
│   │   │   ├── JailTile.cs
│   │   │   ├── GoToJailTile.cs
│   │   │   ├── UtilityTile.cs
│   │   │   └── SpecialTile.cs
│   └── Prefabs/
│       ├── Tile.prefab
│       └── Player.prefab
├── Art/
│   ├── Sprites/
│   │   ├── Dice/
│   │   │   ├── dice1.png
│   │   │   ├── dice2.png
│   │   │   └── ...
│   └── Tiles/
├── UI/
│   ├── Panels/
│   │   ├── PlayerInfoPanel.prefab
│   │   ├── PropertyInfoPanel.prefab
│   │   └── WinScreenPanel.prefab
│   ├── Buttons/
│   │   ├── DiceButton.prefab
│   │   ├── BuyButton.prefab
│   │   ├── SkipButton.prefab
│   │   └── EndTurnButton.prefab
│   └── Fonts/
├── Scenes/
│   └── MainScene.unity
├── Resources/ (only if needed)
│   └── GameData/
├── Audio/ (optional)
├── Materials/ (optional)
└── Plugins/ (if used)

---

## 🏁 Credits

**Developer:** Vishwajeet Fate  
**Assignment:** Game Developer Assignment 2025  
**Tools:** Unity 2D, C#

---
