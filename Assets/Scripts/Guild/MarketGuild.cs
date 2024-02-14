using System.Collections.Generic;
using UnityEngine;

public class MarketGuild : MonoBehaviour
{
    [SerializeField] private GuildData _guildData;

    public void TradeAllTraders(List<Trader> guildTraders)
    {
        int amount = 0;

        for (int i = 0; i < guildTraders.Count; i++)
            for (int j = i + 1; j < guildTraders.Count; j++)
            {
                Trade(guildTraders[i], guildTraders[j]);
                amount++;
            }
    }


    private void Trade(Trader trader1, Trader trader2)
    {
        int countTrades = Random.Range(5, 11);

        for (int i = 0; i < countTrades; i++)
            TradeResult(trader1, trader2);

        trader1.EndTrading();
        trader2.EndTrading();
    }

    private void TradeResult(Trader trader1, Trader trader2)
    {
        TypeTradingStrategies trader1TradingStrategies = trader1.GetTradingStrategies();
        TypeTradingStrategies trader2TradingStrategies = trader2.GetTradingStrategies();

        if (trader1TradingStrategies.Equals(TypeTradingStrategies.Cheat) && trader2TradingStrategies.Equals(TypeTradingStrategies.Cheat))
        {
            trader1.ChangeCountMoney(_guildData.TwoCheat);
            trader2.ChangeCountMoney(_guildData.TwoCheat);
        }
        else if (trader1TradingStrategies.Equals(TypeTradingStrategies.Honestly) && trader2TradingStrategies.Equals(TypeTradingStrategies.Honestly))
        {
            trader1.ChangeCountMoney(_guildData.TwoHonestly);
            trader2.ChangeCountMoney(_guildData.TwoHonestly);
        }
        else
        {
            if (trader1TradingStrategies.Equals(TypeTradingStrategies.Honestly))
            {
                trader1.ChangeCountMoney(_guildData.OneHonestly);
                trader2.ChangeCountMoney(_guildData.OneCheat);
            }
            else
            {
                trader1.ChangeCountMoney(_guildData.OneCheat);
                trader2.ChangeCountMoney(_guildData.OneHonestly);
            }
        }

        trader1.UpdateNextTradingStrategies(trader2TradingStrategies);
        trader2.UpdateNextTradingStrategies(trader1TradingStrategies);
    }
}
