using UnityEngine;

public class UnpredictableTrader : Trader
{
    public override void UpdateNextTradingStrategies(TypeTradingStrategies opponentTradingStrategies)
    {
        if (Random.Range(0, 100) < 50)
            _tradingStrategies = TypeTradingStrategies.Cheat;
        else 
            _tradingStrategies = TypeTradingStrategies.Honestly;
    }
}
