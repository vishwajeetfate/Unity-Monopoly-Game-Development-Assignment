using UnityEngine;

public class UtilityTile : PropertyTile
{
    public override void LandOn(Player player)
    {
        if (owner == null)
        {
            UIManager.Instance.ShowBuyButton(this, player);
        }
        else if (owner != player)
        {
            int rent = Mathf.RoundToInt(price * 0.15f); // rent = 15% of price
            player.AdjustMoney(-rent);
            owner.AdjustMoney(rent);
            UIManager.Instance.diceResultText.text = $"{player.playerName} paid ${rent} utility fee to {owner.playerName}";
            GameManager.Instance.EndTurn();
        }
        else
        {
            UIManager.Instance.diceResultText.text = $"{player.playerName} owns this utility.";
            GameManager.Instance.EndTurn();
        }
    }
}
