using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Texts")]
    public Text turnText;
    public Text diceResultText;
    public Text player1Info;
    public Text player2Info;
    public Text transactionLogText;

    [Header("Property Info")]
    public GameObject propertyInfoPanel;
    public Text propertyNameText;
    public Text propertyPriceText;
    public Text propertyRentText;
    public Text propertyOwnerText;

    [Header("Buttons")]
    public Button diceButton;
    public Button buyButton;
    public Button skipButton;
    public Button endTurnButton;

    [Header("Dice Visual")]
    public Image diceImage;
    public Sprite[] diceSprites;

    [Header("Win Screen")]
    public GameObject winScreenPanel;
    public Text winMessageText;

    private Player currentPlayer;
    private PropertyTile currentProperty;

    private Queue<string> logQueue = new Queue<string>();
    private const int maxLogLines = 6;

    private void Awake()
    {
        Instance = this;

        if (turnText != null) turnText.text = "🎯 Game Starting...";
        if (diceResultText != null) diceResultText.text = "";
        if (transactionLogText != null) transactionLogText.text = "";
        if (propertyInfoPanel != null) propertyInfoPanel.SetActive(false);
        if (winScreenPanel != null) winScreenPanel.SetActive(false);
    }

    public void OnDiceRoll()
    {
        StartCoroutine(AnimateDiceRoll());
    }

    private IEnumerator AnimateDiceRoll()
    {
        diceButton.gameObject.SetActive(false);
        int roll = Random.Range(1, 7);

        for (int i = 0; i < 10; i++)
        {
            int tempRoll = Random.Range(0, 6);
            if (diceImage != null && diceSprites.Length == 6)
                diceImage.sprite = diceSprites[tempRoll];

            yield return new WaitForSeconds(0.05f);
        }

        if (diceImage != null && diceSprites.Length == 6)
            diceImage.sprite = diceSprites[roll - 1];

        diceResultText.text = $"🎲 {currentPlayer.playerName} rolled a {roll}";
        currentPlayer.Move(roll);
    }

    public void ShowDiceRollButton(Player player)
    {
        currentPlayer = player;
        if (diceButton != null)
            diceButton.gameObject.SetActive(true);

        UpdateTurnText(player.playerName);
    }

    public void OnBuyProperty()
    {
        if (currentProperty == null || currentPlayer == null)
        {
            AddLog("⚠️ Cannot buy — no property selected.");
            return;
        }

        if (currentProperty.owner == null)
        {
            currentProperty.Buy(currentPlayer);
            AddLog($"{currentPlayer.playerName} bought {currentProperty.name} for ${currentProperty.price}");
        }
        else
        {
            AddLog("⚠️ This property is already owned.");
        }
    }

    public void OnSkipProperty()
    {
        AddLog($"{currentPlayer.playerName} skipped buying.");
        if (propertyInfoPanel != null)
            propertyInfoPanel.SetActive(false);

        GameManager.Instance.EndTurn();
    }

    public void OnEndTurn()
    {
        AddLog($"{currentPlayer.playerName} ended their turn.");
        if (propertyInfoPanel != null)
            propertyInfoPanel.SetActive(false);

        GameManager.Instance.EndTurn();
    }

    public void ShowBuyButton(PropertyTile property, Player player)
    {
        currentPlayer = player;
        currentProperty = property;

        if (buyButton != null) buyButton.gameObject.SetActive(true);
        if (skipButton != null) skipButton.gameObject.SetActive(true);

        ShowPropertyInfo(property);
    }

    public void UpdateTurnText(string playerName)
    {
        if (turnText != null)
            turnText.text = $"🎯 It's {playerName}'s Turn";
    }

    public void UpdatePlayerUI()
    {
        if (GameManager.Instance == null || GameManager.Instance.players.Length < 2)
            return;

        Player p1 = GameManager.Instance.players[0];
        Player p2 = GameManager.Instance.players.Length > 1 ? GameManager.Instance.players[1] : null;

        if (player1Info != null)
            player1Info.text = $"{p1.playerName}\n💰 ${p1.money}\n🏠 {p1.ownedProperties.Count} props";

        if (player2Info != null && p2 != null)
            player2Info.text = $"{p2.playerName}\n💰 ${p2.money}\n🏠 {p2.ownedProperties.Count} props";
        else if (player2Info != null)
            player2Info.text = "-- Eliminated --";
    }

    public void ShowPropertyInfo(PropertyTile property)
    {
        if (property == null || propertyInfoPanel == null) return;

        propertyInfoPanel.SetActive(true);

        propertyNameText.text = property.name;
        propertyPriceText.text = $"Price: ${property.price}";
        propertyRentText.text = $"Rent: ${property.rent}";
        propertyOwnerText.text = $"Owner: {(property.owner != null ? property.owner.playerName : "None")}";
    }

    public void AddLog(string message)
    {
        logQueue.Enqueue(message);
        if (logQueue.Count > maxLogLines)
            logQueue.Dequeue();

        if (transactionLogText != null)
            transactionLogText.text = string.Join("\n", logQueue.ToArray());
    }

    public void ShowWinScreen(string winnerName)
    {
        if (winScreenPanel != null)
        {
            winScreenPanel.SetActive(true);
            winMessageText.text = $"{winnerName} wins the game! 🎉";
        }
    }
}
