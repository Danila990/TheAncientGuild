
public class VindictiveTrader : Trader
{
    private bool _isOpponentCheat = false;

    public override void UpdateNextTradingStrategies(TypeTradingStrategies opponentTradingStrategies)
    {
        if (!_isOpponentCheat)
            if (opponentTradingStrategies.Equals(TypeTradingStrategies.Cheat))
            {
                _tradingStrategies = TypeTradingStrategies.Cheat;
                _isOpponentCheat = true;
            }
    }

    public override void EndTrading()
    {
        _tradingStrategies = TypeTradingStrategies.Honestly;
        _isOpponentCheat = false;
    }
}
