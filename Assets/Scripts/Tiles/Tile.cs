using UnityEngine;

public class Tile : MonoBehaviour
{
    public int index;

    public virtual void LandOn(Player player)
    {
        Debug.Log($"{player.playerName} landed on Tile {index}");
        GameManager.Instance.EndTurn();
    }
}
