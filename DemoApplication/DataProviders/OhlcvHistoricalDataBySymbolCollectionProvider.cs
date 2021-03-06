﻿using CryptoApisLibrary;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes.Exchanges;
using MorseCode.ITask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DataProviders
{
    internal class OhlcvHistoricalDataBySymbolCollectionProvider : BaseCollectionProvider<HistoricalOhlcvResponse>
    {
        public OhlcvHistoricalDataBySymbolCollectionProvider(
            ICryptoManager manager, Symbol symbol, Period period, DateTime startDateTime, DateTime? endDateTime)
            : base(manager)
        {
            _symbol = symbol;
            _period = period;
            _startDateTime = startDateTime;
            _endDateTime = endDateTime;
        }

        public override IEnumerable<object> Items()
        {
            return InternalItems()?.Result.Ohlcv;
        }

        public override ITask<HistoricalOhlcvResponse> GetPartItemsAsync(int skip, int limit)
        {
            return InternalItems(skip, limit);
        }

        public override IEnumerable<string> Headers { get; } = new[] { "timePeriodStart", "priceClose" };

        public override IEnumerable<string> ItemContent(object item)
        {
            return item is Ohlcv ohlcv
                ? new[] { ohlcv.TimePeriodStart.ToString(), ohlcv.PriceClose.ToString() }
                : Enumerable.Empty<string>();
        }

        private ITask<HistoricalOhlcvResponse> InternalItems(int skip = 0, int limit = 50)
        {
            Task<HistoricalOhlcvResponse> task;
            if (_endDateTime == null)
            {
                task = Manager.Exchanges.Ohlcv.HistoricalAsync(
                    CancellationToken.None, _symbol, _period, _startDateTime, skip, limit);
            }
            else
            {
                task = Manager.Exchanges.Ohlcv.HistoricalAsync(
                    CancellationToken.None, _symbol, _period, _startDateTime, _endDateTime.Value, skip, limit);
            }

            return task.AsITask();
        }

        private readonly Symbol _symbol;
        private readonly Period _period;
        private readonly DateTime _startDateTime;
        private readonly DateTime? _endDateTime;
    }
}