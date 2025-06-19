using UnityEngine;

public class ChanceTile : Tile
{
    public override void LandOn(Player player)
    {
        int chance = Random.Range(0, 100);

        if (chance < 90)
        {
            int loss = Mathf.RoundToInt(player.money * Random.Range(0.1f, 0.3f));
            player.AdjustMoney(-loss);
            UIManager.Instance.AddLog($"{player.playerName} lost ${loss} from chance.");
        }
        else
        {
            int bonus = Mathf.RoundToInt(player.money * 0.5f);
            player.AdjustMoney(bonus);
            UIManager.Instance.AddLog($"{player.playerName} gained ${bonus} from chance!");
        }

        GameManager.Instance.EndTurn();
    }
}
