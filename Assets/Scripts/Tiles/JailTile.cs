using UnityEngine;
public class JailTile : Tile
{
    public override void LandOn(Player player)
    {
        player.isInJail = true;
        player.jailTurnsRemaining = 3;
        Debug.Log($"{player.playerName} is sent to jail for 3 turns.");
        GameManager.Instance.EndTurn();
    }
}
