using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public int money = 1500;
    public int currentTileIndex = 0;
    public bool isInJail = false;
    public int jailTurnsRemaining = 0;

    public List<PropertyTile> ownedProperties = new List<PropertyTile>();

    public void StartTurn()
    {
        if (isInJail)
        {
            jailTurnsRemaining--;

            if (jailTurnsRemaining <= 0)
            {
                isInJail = false;
                UIManager.Instance.diceResultText.text = $"{playerName} is released from jail!";
                UIManager.Instance.AddLog($"{playerName} is released from jail!");
                UIManager.Instance.ShowDiceRollButton(this);
                return;
            }

            UIManager.Instance.diceResultText.text = $"{playerName} is in jail ({jailTurnsRemaining} turns left)";
            UIManager.Instance.AddLog($"{playerName} is in jail ({jailTurnsRemaining} turns left)");
            GameManager.Instance.EndTurn();
            return;
        }

        UIManager.Instance.ShowDiceRollButton(this);
    }

    public void Move(int steps)
    {
        int previousIndex = currentTileIndex;
        currentTileIndex = (currentTileIndex + steps) % BoardManager.Instance.tiles.Count;

        if (currentTileIndex < previousIndex)
        {
            if (BoardManager.Instance.tiles[0] is StartTile startTile)
            {
                startTile.PassedBy(this);
                UIManager.Instance.AddLog($"{playerName} passed Start and received ${startTile.bonus}");
            }
        }

        Tile tile = BoardManager.Instance.tiles[currentTileIndex];
        Vector3 offset = playerName == "Player 1" ? new Vector3(-0.2f, 0.2f, 0) : new Vector3(0.2f, -0.2f, 0);
        transform.position = tile.transform.position + offset;

        tile.LandOn(this);
    }

    public void AdjustMoney(int amount)
    {
        money += amount;
        string change = amount >= 0 ? $"gained ${amount}" : $"lost ${-amount}";
        UIManager.Instance.AddLog($"{playerName} {change}. Now has ${money}");

        UIManager.Instance.UpdatePlayerUI();

        if (money < 0)
        {
            UIManager.Instance.AddLog($"{playerName} is bankrupt!");
        }
    }
}
