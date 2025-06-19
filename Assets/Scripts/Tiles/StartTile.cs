using UnityEngine;

public class StartTile : Tile
{
    public int bonus = 200;

    public override void LandOn(Player player)
    {
        Debug.Log($"{player.playerName} landed on Start (no bonus, just landing).");
        UIManager.Instance.diceResultText.text = $"Welcome {player.playerName}!";
        GameManager.Instance.EndTurn();
    }

    public void PassedBy(Player player)
    {
        player.AdjustMoney(bonus);
        Debug.Log($"{player.playerName} passed Start and received ${bonus}");
    }
}
