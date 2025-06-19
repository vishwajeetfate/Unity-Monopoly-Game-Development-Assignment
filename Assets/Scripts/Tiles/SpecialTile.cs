using UnityEngine;

/// <summary>
/// Placeholder for special tiles like Railway, Airport, Harbor.
/// </summary>
public class SpecialTile : Tile
{
    public string typeName = "Special";

    public override void LandOn(Player player)
    {
        Debug.Log($"{player.playerName} landed on {typeName} tile. (No effect yet)");
        UIManager.Instance.diceResultText.text = $"{player.playerName} landed on {typeName}.";
        GameManager.Instance.EndTurn();
    }
}
