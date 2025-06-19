using UnityEngine;

public class GoToJailTile : Tile
{
    public override void LandOn(Player player)
    {
        player.isInJail = true;
        player.jailTurnsRemaining = 3;
        Debug.Log($"{player.playerName} was sent to jail!");
        UIManager.Instance.diceResultText.text = $"{player.playerName} goes directly to jail!";
        GameManager.Instance.EndTurn();
    }
}
