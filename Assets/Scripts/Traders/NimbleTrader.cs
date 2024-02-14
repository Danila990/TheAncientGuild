
public class NimbleTrader : Trader
{
    private int _numberTrade = 1;
    private bool _isOpponentCheat = false;

    public override void UpdateNextTradingStrategies(TypeTradingStrategies opponentTradingStrategies)
    {
        if(_numberTrade < 4)
        {
            _numberTrade++;

            if (_numberTrade == 2)
                _tradingStrategies = TypeTradingStrategies.Cheat;
            else if (_numberTrade == 3)
                _tradingStrategies = TypeTradingStrategies.Honestly;
            else if (_numberTrade == 4)
                _tradingStrategies = TypeTradingStrategies.Honestly;

            if (opponentTradingStrategies.Equals(TypeTradingStrategies.Cheat))
                _isOpponentCheat = true;
            return;
        }

        if (_isOpponentCheat)
        {
            _tradingStrategies = TypeTradingStrategies.Cheat;
            return;
        }

        _tradingStrategies = opponentTradingStrategies;
    }

    public override void EndTrading()
    {
        _numberTrade = 0;
        _isOpponentCheat = false;
        _tradingStrategies = TypeTradingStrategies.Honestly;
    }
}
