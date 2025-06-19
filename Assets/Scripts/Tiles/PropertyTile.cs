using UnityEngine;

public class PropertyTile : Tile
{
    public int price;
    public int rent;
    public Player owner;

    public override void LandOn(Player player)
    {
        if (owner == null)
        {
            UIManager.Instance.ShowBuyButton(this, player);
        }
        else if (owner != player)
        {
            if (player.money >= rent)
            {
                player.AdjustMoney(-rent);
                owner.AdjustMoney(rent);
                UIManager.Instance.AddLog($"{player.playerName} paid ${rent} rent to {owner.playerName}");
            }
            else
            {
                int allMoney = player.money;
                player.AdjustMoney(-allMoney);
                owner.AdjustMoney(allMoney);
                UIManager.Instance.AddLog($"{player.playerName} is bankrupt! Paid ${allMoney} to {owner.playerName}.");
            }

            UIManager.Instance.UpdatePlayerUI();
            GameManager.Instance.EndTurn();
        }
        else
        {
            UIManager.Instance.AddLog($"{player.playerName} landed on their own property.");
            GameManager.Instance.EndTurn();
        }
    }

    public void Buy(Player player)
    {
        if (owner != null)
        {
            UIManager.Instance.AddLog("This property is already owned.");
            return;
        }

        if (player.money >= price)
        {
            player.AdjustMoney(-price);
            owner = player;
            player.ownedProperties.Add(this);
            UIManager.Instance.AddLog($"{player.playerName} bought {name} for ${price}");
        }
        else
        {
            UIManager.Instance.AddLog($"{player.playerName} can't afford {name}.");
        }

        UIManager.Instance.UpdatePlayerUI();
        UIManager.Instance.ShowPropertyInfo(this);
        GameManager.Instance.EndTurn();
    }
}
