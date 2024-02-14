
public class TrickyTrader : Trader
{
    private bool _isFirstTrade = true;


    public override void UpdateNextTradingStrategies(TypeTradingStrategies opponentTradingStrategies)
    {
        if (_isFirstTrade)
        {
            _isFirstTrade = false;
            return;
        }

        _tradingStrategies = opponentTradingStrategies;
    }

    public override void EndTrading()
    {
        _tradingStrategies = TypeTradingStrategies.Honestly;
        _isFirstTrade = true;
    }
}
