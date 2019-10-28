using CryptoApisLibrary;
using CryptoApisLibrary.DataTypes;
using CryptoApisLibrary.ResponseTypes;
using MorseCode.ITask;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DataProviders;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1(ICryptoManager manager)
        {
            Manager = manager;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillListboxes();
            SetDefaultItemsListBox();

            RegisterRadioButton(historicalTradesBySymbolRadioButton, () =>
                new HistoricalTradesBySymbolCollectionProvider(Manager, Symbol, StartDate, EndDate));
            RegisterRadioButton(historicalTradesByAssetPairRadioButton, () =>
                new HistoricalTradesByAssetPairCollectionProvider(Manager, BaseAsset, QuoteAsset, StartDate, EndDate));
            RegisterRadioButton(historicalTradesByBaseAssetRadioButton, () =>
                new HistoricalTradesByBaseAssetCollectionProvider(Manager, BaseAsset, StartDate, EndDate));
            RegisterRadioButton(historicalTradesByExchangeRadioButton, () =>
                new HistoricalTradesByExchangeCollectionProvider(Manager, Exchange, StartDate, EndDate));
            RegisterRadioButton(historicalTradesByExchangeAssetPairRadioButton, () =>
                new HistoricalTradesByExchangeAssetPairCollectionProvider(Manager, Exchange, BaseAsset, QuoteAsset, StartDate, EndDate));

            RegisterRadioButton(latestDataRadioButton, () =>
                new LatestDataCollectionProvider(Manager));
            RegisterRadioButton(latestDataBySymbolRadioButton, () =>
                new LatestDataBySymbolCollectionProvider(Manager, Symbol));
            RegisterRadioButton(latestDataByAssetPairRadioButton, () =>
                new LatestDataByAssetPairCollectionProvider(Manager, BaseAsset, QuoteAsset));
            RegisterRadioButton(latestDataByBaseAssetRadioButton, () =>
                new LatestDataByBaseAssetCollectionProvider(Manager, BaseAsset));
            RegisterRadioButton(latestDataByExchangeRadioButton, () =>
                new LatestDataByExchangeCollectionProvider(Manager, Exchange));
            RegisterRadioButton(latestDataByExchangeAssetPairRadioButton, () =>
                new LatestDataByExchangeAssetPairCollectionProvider(Manager, Exchange, BaseAsset, QuoteAsset));

            RegisterRadioButton(ohlcvHistoricalDataBySymbolRadioButton, () =>
                StartDate == null
                    ? null
                    : new OhlcvHistoricalDataBySymbolCollectionProvider(Manager, Symbol, Period, StartDate.Value, EndDate));
            RegisterRadioButton(ohlcvHistoricalDataByExchangeRadioButton, () =>
                StartDate == null
                    ? null
                    : new OhlcvHistoricalDataByExchangeCollectionProvider(Manager, Exchange, Period, StartDate.Value, EndDate));
            RegisterRadioButton(ohlcvHistoricalDataByAssetAndExchangeRadioButton, () =>
                StartDate == null
                    ? null
                    : new OhlcvHistoricalDataByAssetAndExchangeCollectionProvider(Manager, Exchange, BaseAsset, Period, StartDate.Value, EndDate));

            RegisterRadioButton(allCurrentRatesRadioButton, () =>
                new AllCurrentRatesCollectionProvider(Manager, BaseAsset, StartDate));
            RegisterRadioButton(allCurrentRatesByExchangeRadioButton, () =>
                new AllCurrentRatesByExchangeCollectionProvider(Manager, BaseAsset, Exchange, StartDate));
            RegisterRadioButton(exchangesByAssetsRadioButton, () =>
                new ExchangesByAssetsCollectionProvider(Manager, BaseAsset));
            RegisterRadioButton(exchangesByPairRadioButton, () =>
                new ExchangesByPairCollectionProvider(Manager, BaseAsset, QuoteAsset, Exchanges));
            RegisterRadioButton(symbolsInExchangeRadioButton, () =>
                new SymbolsInExchangeCollectionProvider(Manager, Exchange));

            RegisterRadioButton(exchangesRadioButton, () =>
                new ExchangesCollectionProvider(Manager));
            RegisterRadioButton(assetsRadioButton, () =>
                new AssetsCollectionProvider(Manager));
            RegisterRadioButton(metaExchangesRadioButton, () =>
                new MetaExchangesCollectionProvider(Manager));
            RegisterRadioButton(metaAssetsRadioButton, () =>
                new MetaAssetsCollectionProvider(Manager));
            RegisterRadioButton(metaSymbolsRadioButton, () =>
                new SymbolsCollectionProvider(Manager));

            historicalTradesBySymbolRadioButton.Checked = true;
        }

        private void FillListboxes()
        {
            exchangeComboBox.Items.Clear();
            exchangeComboBox.Items.AddRange(Exchanges.ToArray());

            baseAssetComboBox.Items.Clear();
            baseAssetComboBox.Items.AddRange(Assets.ToArray());

            quoteAssetComboBox.Items.Clear();
            quoteAssetComboBox.Items.AddRange(Assets.ToArray());

            symbolComboBox.Items.Clear();
            symbolComboBox.Items.AddRange(Symbols.ToArray());

            periodComboBox.Items.Clear();
            periodComboBox.Items.AddRange(Periods.ToArray());
        }

        private void SetDefaultItemsListBox()
        {
            foreach (var item in exchangeComboBox.Items.OfType<ExchangeMeta>())
            {
                if (string.Equals(item.Name, "Bittrex", StringComparison.OrdinalIgnoreCase))
                {
                    exchangeComboBox.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in baseAssetComboBox.Items.OfType<AssetMeta>())
            {
                if (string.Equals(item.AssetId, "BTC", StringComparison.OrdinalIgnoreCase))
                {
                    baseAssetComboBox.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in quoteAssetComboBox.Items.OfType<AssetMeta>())
            {
                if (string.Equals(item.AssetId, "USD", StringComparison.OrdinalIgnoreCase))
                {
                    quoteAssetComboBox.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in symbolComboBox.Items.OfType<Symbol>())
            {
                if (string.Equals(item.Name, "BTC-USD", StringComparison.OrdinalIgnoreCase))
                {
                    symbolComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            GetAllAndFillControls();
        }

        private void AddItemTo(int? index, object item, ListView listView)
        {
            var itemContent = CollectionProvider.ItemContent(item).ToList();
            var elements = new string[itemContent.Count() + 1];
            elements[0] = index == null
                ? string.Empty
                : (index + 1).ToString();
            itemContent.CopyTo(elements, 1);

            var listViewItem = new ListViewItem(elements) { Tag = item };
            listView.Items.Add(listViewItem);
        }

        private void GetAllAndFillControls()
        {
            allListView.Items.Clear();

            var allItems = CollectionProvider.Items().ToList();
            for (var i = 0; i < allItems.Count(); i++)
            {
                AddItemTo(i, allItems[i], allListView);
            }

            AutoResizeColumnsAndHighlightChanges();
            HighlightChanges();
        }

        private void GetPartAndFillControls()
        {
            var index = CurrentIndex;

            var firstPart2 = CollectionProvider.GetPartItemsAsync(index * Skip, Limit);
            var secondPart2 = CollectionProvider.GetPartItemsAsync((index + 1) * Skip, Limit);
            var thirdPart2 = CollectionProvider.GetPartItemsAsync((index + 2) * Skip, Limit);

            firstListView.Items.Clear();
            secondListView.Items.Clear();
            thirdListView.Items.Clear();

            Task.WaitAll(firstPart2.AsTask(), secondPart2.AsTask(), thirdPart2.AsTask());

            FillPartList(firstPart2.Result, firstListView);
            FillPartList(secondPart2.Result, secondListView);
            FillPartList(thirdPart2.Result, thirdListView);

            AutoResizeColumnsAndHighlightChanges();
            HighlightChanges();
        }

        private void FillPartList(ICollectionResponse response, ListView listView)
        {
            var items = response.Items.ToList();
            if (items.Any())
            {
                var firstIndex = GetIndexInAllItemsOfFirstElementInPart(items.First());
                for (var i = 0; i < items.Count; i++)
                {
                    var index = firstIndex + i;
                    AddItemTo(index, items[i], listView);
                }
            }
        }

        private int? GetIndexInAllItemsOfFirstElementInPart(object partElement)
        {
            for (var i = 0; i < allListView.Items.Count; i++)
            {
                if (allListView.Items[i].Tag.Equals(partElement))
                {
                    return i;
                }
            }

            return null;
        }

        private void HighlightChanges(int startIndex, ListView partListView)
        {
            for (int i = startIndex, j = 0; j < partListView.Items.Count; i++, j++)
            {
                if (allListView.Items.Count <= i)
                    break;

                var allOrder = allListView.Items[i].Tag;
                var firstOrder = partListView.Items[j].Tag;
                if (!allOrder.Equals(firstOrder))
                {
                    allListView.Items[i].BackColor = DifferentColor;
                    partListView.Items[j].BackColor = DifferentColor;
                }
                else
                {
                    allListView.Items[i].BackColor = IntervalColor;
                    partListView.Items[j].BackColor = IntervalColor;
                }
            }
        }

        private void HighlightChanges()
        {
            ResetHighlightChanges();

            if (firstListView.Items.Count > 0)
            {
                var firstIndex = GetIndexInAllItemsOfFirstElementInPart(firstListView.Items[0].Tag);
                if (firstIndex == null)
                    return;

                HighlightChanges(firstIndex.Value, firstListView);
            }

            if (secondListView.Items.Count > 0)
            {
                var firstIndex = GetIndexInAllItemsOfFirstElementInPart(secondListView.Items[0].Tag);
                if (firstIndex == null)
                    return;

                HighlightChanges(firstIndex.Value, secondListView);
            }

            if (thirdListView.Items.Count > 0)
            {
                var firstIndex = GetIndexInAllItemsOfFirstElementInPart(thirdListView.Items[0].Tag);
                if (firstIndex == null)
                    return;

                HighlightChanges(firstIndex.Value, thirdListView);
            }
        }

        private void ResetHighlightChanges()
        {
            ResetHighlightChanges(allListView);
            ResetHighlightChanges(firstListView);
            ResetHighlightChanges(secondListView);
            ResetHighlightChanges(thirdListView);
        }

        private void ResetHighlightChanges(ListView listView)
        {
            for (var i = 0; i < listView.Items.Count; i++)
            {
                listView.Items[i].BackColor = DefaultBackColor;
            }
        }

        private void AutoResizeColumnsAndHighlightChanges()
        {
            allListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            firstListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            secondListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            thirdListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void AddHeader(string name)
        {
            allListView.Columns.Add(name);
            firstListView.Columns.Add(name);
            secondListView.Columns.Add(name);
            thirdListView.Columns.Add(name);
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            CurrentIndex--;
            GetPartAndFillControls();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            CurrentIndex++;
            GetPartAndFillControls();
        }

        private Exchange Exchange => (exchangeComboBox.SelectedItem as ExchangeMeta)?.ToExchange;
        private Asset BaseAsset => (baseAssetComboBox.SelectedItem as AssetMeta)?.ToAsset;
        private Asset QuoteAsset => (quoteAssetComboBox.SelectedItem as AssetMeta)?.ToAsset;
        private Symbol Symbol => symbolComboBox.SelectedItem as Symbol;
        private Period Period => periodComboBox.SelectedItem as Period;

        private ICollectionProvider<ICollectionResponse> _collectionProvider;

        private ICollectionProvider<ICollectionResponse> CollectionProvider
        {
            get => _collectionProvider;
            set
            {
                if (value == _collectionProvider)
                    return;
                _collectionProvider = value;

                allListView.Columns.Clear();
                firstListView.Columns.Clear();
                secondListView.Columns.Clear();
                thirdListView.Columns.Clear();

                if (CollectionProvider != null)
                {
                    AddHeader("#");
                    foreach (var header in CollectionProvider.Headers)
                    {
                        AddHeader(header);
                    }
                }

                GetAllAndFillControls();
                GetPartAndFillControls();

                CurrentIndex = 0;
            }
        }

        private int Skip { get; } = 5;
        private int Limit { get; } = 5;

        private IEnumerable<Period> _periods;

        private IEnumerable<Period> Periods => _periods ??
                                               (_periods = Manager.Exchanges.Ohlcv.Periods().Periods.OrderBy(a => a.DisplayName).ToList());

        private IEnumerable<Symbol> _symbols;

        private IEnumerable<Symbol> Symbols => _symbols ??
            (_symbols = Manager.Exchanges.Info.Symbols().Symbols.OrderBy(a => a.Name).ToList());

        private IEnumerable<AssetMeta> _assets;

        private IEnumerable<AssetMeta> Assets => _assets ??
            (_assets = Manager.Exchanges.Info.AssetsMeta().Assets.OrderBy(a => a.AssetId).ToList());

        private IEnumerable<ExchangeMeta> _exchanges;
        private int _currentIndex;

        private IEnumerable<ExchangeMeta> Exchanges => _exchanges ??
            (_exchanges = Manager.Exchanges.Info.ExchangesMeta().Exchanges.OrderBy(a => a.Name).ToList());

        private DateTime? StartDate => startDateTimePicker.Checked ? startDateTimePicker.Value : (DateTime?)null;
        private DateTime? EndDate => endDateTimePicker.Checked ? endDateTimePicker.Value : (DateTime?)null;

        private ICryptoManager Manager { get; }

        private Color IntervalColor => Color.LightYellow;
        private Color DifferentColor => Color.Aquamarine;

        private int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                _currentIndex = value;
                prevButton.Text = CurrentIndex > 0
                    ? $"Previous [page {CurrentIndex - 1}]"
                    : "Previous - none";

                nextButton.Text = $"Next [page {CurrentIndex + 1}]";
                partsGroupBox.Text = $"Parts of collection(skip={CurrentIndex * Skip}, " +
                                     $"skip={(CurrentIndex + 1) * Skip}, " +
                                     $"skip={(CurrentIndex + 2) * Skip})";

                prevButton.Enabled = _currentIndex > 0;
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                var makeFunc = _buildCollectionProvider[radioButton];
                CollectionProvider = makeFunc?.Invoke();
                CurrentIndex = 0;
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReinitCollectionProvider();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ReinitCollectionProvider();
        }

        private void ReinitCollectionProvider()
        {
            var radioButton = GetCheckedRadiobutton();
            if (radioButton == null)
                return;

            if (_buildCollectionProvider.TryGetValue(radioButton, out var makeFunc))
            {
                CollectionProvider = makeFunc.Invoke();
            }
        }

        private RadioButton GetCheckedRadiobutton()
        {
            return _allRadioButtons.FirstOrDefault(rb => rb.Checked);
        }

        private void RegisterRadioButton(RadioButton radioButton, Func<ICollectionProvider<ICollectionResponse>> makeCollectionProviderFunc)
        {
            _allRadioButtons.Add(radioButton);
            _buildCollectionProvider.Add(radioButton, makeCollectionProviderFunc);
        }

        private readonly Dictionary<RadioButton, Func<ICollectionProvider<ICollectionResponse>>> _buildCollectionProvider =
            new Dictionary<RadioButton, Func<ICollectionProvider<ICollectionResponse>>>();

        private readonly List<RadioButton> _allRadioButtons = new List<RadioButton>();
    }
}