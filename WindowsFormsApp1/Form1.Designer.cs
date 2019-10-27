namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.allListView = new System.Windows.Forms.ListView();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.firstListView = new System.Windows.Forms.ListView();
            this.secondListView = new System.Windows.Forms.ListView();
            this.thirdListView = new System.Windows.Forms.ListView();
            this.refreshButton = new System.Windows.Forms.Button();
            this.allGroupBox = new System.Windows.Forms.GroupBox();
            this.partsGroupBox = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.symbolComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.symbolsInExchangeRadioButton = new System.Windows.Forms.RadioButton();
            this.exchangesByPairRadioButton = new System.Windows.Forms.RadioButton();
            this.exchangesByAssetsRadioButton = new System.Windows.Forms.RadioButton();
            this.metaAssetsRadioButton = new System.Windows.Forms.RadioButton();
            this.metaSymbolsRadioButton = new System.Windows.Forms.RadioButton();
            this.allCurrentRatesRadioButton = new System.Windows.Forms.RadioButton();
            this.assetsRadioButton = new System.Windows.Forms.RadioButton();
            this.allCurrentRatesByExchangeRadioButton = new System.Windows.Forms.RadioButton();
            this.ohlcvHistoricalDataByExchangeRadioButton = new System.Windows.Forms.RadioButton();
            this.metaExchangesRadioButton = new System.Windows.Forms.RadioButton();
            this.ohlcvHistoricalDataByAssetAndExchangeRadioButton = new System.Windows.Forms.RadioButton();
            this.exchangesRadioButton = new System.Windows.Forms.RadioButton();
            this.ohlcvHistoricalDataBySymbolRadioButton = new System.Windows.Forms.RadioButton();
            this.latestDataRadioButton = new System.Windows.Forms.RadioButton();
            this.latestDataBySymbolRadioButton = new System.Windows.Forms.RadioButton();
            this.latestDataByExchangeAssetPairRadioButton = new System.Windows.Forms.RadioButton();
            this.latestDataByExchangeRadioButton = new System.Windows.Forms.RadioButton();
            this.latestDataByBaseAssetRadioButton = new System.Windows.Forms.RadioButton();
            this.latestDataByAssetPairRadioButton = new System.Windows.Forms.RadioButton();
            this.historicalTradesBySymbolRadioButton = new System.Windows.Forms.RadioButton();
            this.historicalTradesByExchangeAssetPairRadioButton = new System.Windows.Forms.RadioButton();
            this.historicalTradesByExchangeRadioButton = new System.Windows.Forms.RadioButton();
            this.historicalTradesByBaseAssetRadioButton = new System.Windows.Forms.RadioButton();
            this.historicalTradesByAssetPairRadioButton = new System.Windows.Forms.RadioButton();
            this.quoteAssetComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.baseAssetComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.exchangeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.periodComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.allGroupBox.SuspendLayout();
            this.partsGroupBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // allListView
            // 
            this.allListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allListView.FullRowSelect = true;
            this.allListView.GridLines = true;
            this.allListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.allListView.HideSelection = false;
            this.allListView.Location = new System.Drawing.Point(6, 19);
            this.allListView.Name = "allListView";
            this.allListView.Size = new System.Drawing.Size(365, 370);
            this.allListView.TabIndex = 0;
            this.allListView.UseCompatibleStateImageBehavior = false;
            this.allListView.View = System.Windows.Forms.View.Details;
            // 
            // prevButton
            // 
            this.prevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevButton.Location = new System.Drawing.Point(471, 603);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(115, 23);
            this.prevButton.TabIndex = 1;
            this.prevButton.Text = "Prev";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextButton.Location = new System.Drawing.Point(592, 603);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(115, 23);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // firstListView
            // 
            this.firstListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstListView.FullRowSelect = true;
            this.firstListView.GridLines = true;
            this.firstListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.firstListView.HideSelection = false;
            this.firstListView.Location = new System.Drawing.Point(6, 19);
            this.firstListView.Name = "firstListView";
            this.firstListView.Size = new System.Drawing.Size(381, 124);
            this.firstListView.TabIndex = 2;
            this.firstListView.UseCompatibleStateImageBehavior = false;
            this.firstListView.View = System.Windows.Forms.View.Details;
            // 
            // secondListView
            // 
            this.secondListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secondListView.FullRowSelect = true;
            this.secondListView.GridLines = true;
            this.secondListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.secondListView.HideSelection = false;
            this.secondListView.Location = new System.Drawing.Point(6, 149);
            this.secondListView.Name = "secondListView";
            this.secondListView.Size = new System.Drawing.Size(381, 88);
            this.secondListView.TabIndex = 3;
            this.secondListView.UseCompatibleStateImageBehavior = false;
            this.secondListView.View = System.Windows.Forms.View.Details;
            // 
            // thirdListView
            // 
            this.thirdListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thirdListView.FullRowSelect = true;
            this.thirdListView.GridLines = true;
            this.thirdListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.thirdListView.HideSelection = false;
            this.thirdListView.Location = new System.Drawing.Point(6, 243);
            this.thirdListView.Name = "thirdListView";
            this.thirdListView.Size = new System.Drawing.Size(381, 146);
            this.thirdListView.TabIndex = 4;
            this.thirdListView.UseCompatibleStateImageBehavior = false;
            this.thirdListView.View = System.Windows.Forms.View.Details;
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshButton.Location = new System.Drawing.Point(16, 603);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(377, 23);
            this.refreshButton.TabIndex = 5;
            this.refreshButton.Text = "Refresh all items";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // allGroupBox
            // 
            this.allGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.allGroupBox.Controls.Add(this.allListView);
            this.allGroupBox.Location = new System.Drawing.Point(11, 202);
            this.allGroupBox.Name = "allGroupBox";
            this.allGroupBox.Size = new System.Drawing.Size(377, 395);
            this.allGroupBox.TabIndex = 6;
            this.allGroupBox.TabStop = false;
            this.allGroupBox.Text = "All items";
            // 
            // partsGroupBox
            // 
            this.partsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.partsGroupBox.Controls.Add(this.firstListView);
            this.partsGroupBox.Controls.Add(this.secondListView);
            this.partsGroupBox.Controls.Add(this.thirdListView);
            this.partsGroupBox.Location = new System.Drawing.Point(394, 202);
            this.partsGroupBox.Name = "partsGroupBox";
            this.partsGroupBox.Size = new System.Drawing.Size(393, 395);
            this.partsGroupBox.TabIndex = 7;
            this.partsGroupBox.TabStop = false;
            this.partsGroupBox.Text = "Parts of collection (skip=0, skip=5, skip=10)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.periodComboBox);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.symbolComboBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.endDateTimePicker);
            this.panel2.Controls.Add(this.startDateTimePicker);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.quoteAssetComboBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.baseAssetComboBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.exchangeComboBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1194, 184);
            this.panel2.TabIndex = 8;
            // 
            // symbolComboBox
            // 
            this.symbolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.symbolComboBox.FormattingEnabled = true;
            this.symbolComboBox.Location = new System.Drawing.Point(79, 78);
            this.symbolComboBox.Name = "symbolComboBox";
            this.symbolComboBox.Size = new System.Drawing.Size(121, 21);
            this.symbolComboBox.TabIndex = 12;
            this.symbolComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Symbol";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "End date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Start date";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Checked = false;
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateTimePicker.Location = new System.Drawing.Point(79, 155);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.ShowCheckBox = true;
            this.endDateTimePicker.Size = new System.Drawing.Size(121, 20);
            this.endDateTimePicker.TabIndex = 8;
            this.endDateTimePicker.Value = new System.DateTime(2019, 10, 21, 0, 0, 0, 0);
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Checked = false;
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTimePicker.Location = new System.Drawing.Point(79, 129);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.ShowCheckBox = true;
            this.startDateTimePicker.Size = new System.Drawing.Size(121, 20);
            this.startDateTimePicker.TabIndex = 7;
            this.startDateTimePicker.Value = new System.DateTime(2019, 10, 20, 0, 0, 0, 0);
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.symbolsInExchangeRadioButton);
            this.groupBox2.Controls.Add(this.exchangesByPairRadioButton);
            this.groupBox2.Controls.Add(this.exchangesByAssetsRadioButton);
            this.groupBox2.Controls.Add(this.metaAssetsRadioButton);
            this.groupBox2.Controls.Add(this.metaSymbolsRadioButton);
            this.groupBox2.Controls.Add(this.allCurrentRatesRadioButton);
            this.groupBox2.Controls.Add(this.assetsRadioButton);
            this.groupBox2.Controls.Add(this.allCurrentRatesByExchangeRadioButton);
            this.groupBox2.Controls.Add(this.ohlcvHistoricalDataByExchangeRadioButton);
            this.groupBox2.Controls.Add(this.metaExchangesRadioButton);
            this.groupBox2.Controls.Add(this.ohlcvHistoricalDataByAssetAndExchangeRadioButton);
            this.groupBox2.Controls.Add(this.exchangesRadioButton);
            this.groupBox2.Controls.Add(this.ohlcvHistoricalDataBySymbolRadioButton);
            this.groupBox2.Controls.Add(this.latestDataRadioButton);
            this.groupBox2.Controls.Add(this.latestDataBySymbolRadioButton);
            this.groupBox2.Controls.Add(this.latestDataByExchangeAssetPairRadioButton);
            this.groupBox2.Controls.Add(this.latestDataByExchangeRadioButton);
            this.groupBox2.Controls.Add(this.latestDataByBaseAssetRadioButton);
            this.groupBox2.Controls.Add(this.latestDataByAssetPairRadioButton);
            this.groupBox2.Controls.Add(this.historicalTradesBySymbolRadioButton);
            this.groupBox2.Controls.Add(this.historicalTradesByExchangeAssetPairRadioButton);
            this.groupBox2.Controls.Add(this.historicalTradesByExchangeRadioButton);
            this.groupBox2.Controls.Add(this.historicalTradesByBaseAssetRadioButton);
            this.groupBox2.Controls.Add(this.historicalTradesByAssetPairRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(206, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(959, 168);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Endpoints";
            // 
            // symbolsInExchangeRadioButton
            // 
            this.symbolsInExchangeRadioButton.AutoSize = true;
            this.symbolsInExchangeRadioButton.Location = new System.Drawing.Point(666, 110);
            this.symbolsInExchangeRadioButton.Name = "symbolsInExchangeRadioButton";
            this.symbolsInExchangeRadioButton.Size = new System.Drawing.Size(125, 17);
            this.symbolsInExchangeRadioButton.TabIndex = 28;
            this.symbolsInExchangeRadioButton.Text = "Symbols in exchange";
            this.symbolsInExchangeRadioButton.UseVisualStyleBackColor = true;
            this.symbolsInExchangeRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // exchangesByPairRadioButton
            // 
            this.exchangesByPairRadioButton.AutoSize = true;
            this.exchangesByPairRadioButton.Location = new System.Drawing.Point(666, 87);
            this.exchangesByPairRadioButton.Name = "exchangesByPairRadioButton";
            this.exchangesByPairRadioButton.Size = new System.Drawing.Size(112, 17);
            this.exchangesByPairRadioButton.TabIndex = 26;
            this.exchangesByPairRadioButton.Text = "Exchanges by pair";
            this.exchangesByPairRadioButton.UseVisualStyleBackColor = true;
            this.exchangesByPairRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // exchangesByAssetsRadioButton
            // 
            this.exchangesByAssetsRadioButton.AutoSize = true;
            this.exchangesByAssetsRadioButton.Location = new System.Drawing.Point(666, 64);
            this.exchangesByAssetsRadioButton.Name = "exchangesByAssetsRadioButton";
            this.exchangesByAssetsRadioButton.Size = new System.Drawing.Size(125, 17);
            this.exchangesByAssetsRadioButton.TabIndex = 25;
            this.exchangesByAssetsRadioButton.Text = "Exchanges by assets";
            this.exchangesByAssetsRadioButton.UseVisualStyleBackColor = true;
            this.exchangesByAssetsRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // metaAssetsRadioButton
            // 
            this.metaAssetsRadioButton.AutoSize = true;
            this.metaAssetsRadioButton.Location = new System.Drawing.Point(832, 87);
            this.metaAssetsRadioButton.Name = "metaAssetsRadioButton";
            this.metaAssetsRadioButton.Size = new System.Drawing.Size(82, 17);
            this.metaAssetsRadioButton.TabIndex = 24;
            this.metaAssetsRadioButton.Text = "Meta assets";
            this.metaAssetsRadioButton.UseVisualStyleBackColor = true;
            this.metaAssetsRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // metaSymbolsRadioButton
            // 
            this.metaSymbolsRadioButton.AutoSize = true;
            this.metaSymbolsRadioButton.Location = new System.Drawing.Point(832, 109);
            this.metaSymbolsRadioButton.Name = "metaSymbolsRadioButton";
            this.metaSymbolsRadioButton.Size = new System.Drawing.Size(89, 17);
            this.metaSymbolsRadioButton.TabIndex = 23;
            this.metaSymbolsRadioButton.Text = "Meta symbols";
            this.metaSymbolsRadioButton.UseVisualStyleBackColor = true;
            this.metaSymbolsRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // allCurrentRatesRadioButton
            // 
            this.allCurrentRatesRadioButton.AutoSize = true;
            this.allCurrentRatesRadioButton.Location = new System.Drawing.Point(666, 19);
            this.allCurrentRatesRadioButton.Name = "allCurrentRatesRadioButton";
            this.allCurrentRatesRadioButton.Size = new System.Drawing.Size(98, 17);
            this.allCurrentRatesRadioButton.TabIndex = 20;
            this.allCurrentRatesRadioButton.Text = "All current rates";
            this.allCurrentRatesRadioButton.UseVisualStyleBackColor = true;
            this.allCurrentRatesRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // assetsRadioButton
            // 
            this.assetsRadioButton.AutoSize = true;
            this.assetsRadioButton.Location = new System.Drawing.Point(832, 42);
            this.assetsRadioButton.Name = "assetsRadioButton";
            this.assetsRadioButton.Size = new System.Drawing.Size(56, 17);
            this.assetsRadioButton.TabIndex = 22;
            this.assetsRadioButton.Text = "Assets";
            this.assetsRadioButton.UseVisualStyleBackColor = true;
            this.assetsRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // allCurrentRatesByExchangeRadioButton
            // 
            this.allCurrentRatesByExchangeRadioButton.AutoSize = true;
            this.allCurrentRatesByExchangeRadioButton.Location = new System.Drawing.Point(666, 41);
            this.allCurrentRatesByExchangeRadioButton.Name = "allCurrentRatesByExchangeRadioButton";
            this.allCurrentRatesByExchangeRadioButton.Size = new System.Drawing.Size(162, 17);
            this.allCurrentRatesByExchangeRadioButton.TabIndex = 18;
            this.allCurrentRatesByExchangeRadioButton.Text = "All current rates by exchange";
            this.allCurrentRatesByExchangeRadioButton.UseVisualStyleBackColor = true;
            this.allCurrentRatesByExchangeRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // ohlcvHistoricalDataByExchangeRadioButton
            // 
            this.ohlcvHistoricalDataByExchangeRadioButton.AutoSize = true;
            this.ohlcvHistoricalDataByExchangeRadioButton.Location = new System.Drawing.Point(427, 42);
            this.ohlcvHistoricalDataByExchangeRadioButton.Name = "ohlcvHistoricalDataByExchangeRadioButton";
            this.ohlcvHistoricalDataByExchangeRadioButton.Size = new System.Drawing.Size(193, 17);
            this.ohlcvHistoricalDataByExchangeRadioButton.TabIndex = 17;
            this.ohlcvHistoricalDataByExchangeRadioButton.Text = "OHLCV historical data by exchange";
            this.ohlcvHistoricalDataByExchangeRadioButton.UseVisualStyleBackColor = true;
            this.ohlcvHistoricalDataByExchangeRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // metaExchangesRadioButton
            // 
            this.metaExchangesRadioButton.AutoSize = true;
            this.metaExchangesRadioButton.Location = new System.Drawing.Point(832, 64);
            this.metaExchangesRadioButton.Name = "metaExchangesRadioButton";
            this.metaExchangesRadioButton.Size = new System.Drawing.Size(104, 17);
            this.metaExchangesRadioButton.TabIndex = 21;
            this.metaExchangesRadioButton.Text = "Meta exchanges";
            this.metaExchangesRadioButton.UseVisualStyleBackColor = true;
            this.metaExchangesRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // ohlcvHistoricalDataByAssetAndExchangeRadioButton
            // 
            this.ohlcvHistoricalDataByAssetAndExchangeRadioButton.AutoSize = true;
            this.ohlcvHistoricalDataByAssetAndExchangeRadioButton.Location = new System.Drawing.Point(427, 65);
            this.ohlcvHistoricalDataByAssetAndExchangeRadioButton.Name = "ohlcvHistoricalDataByAssetAndExchangeRadioButton";
            this.ohlcvHistoricalDataByAssetAndExchangeRadioButton.Size = new System.Drawing.Size(242, 17);
            this.ohlcvHistoricalDataByAssetAndExchangeRadioButton.TabIndex = 14;
            this.ohlcvHistoricalDataByAssetAndExchangeRadioButton.Text = "OHLCV historical data by asset and exchange";
            this.ohlcvHistoricalDataByAssetAndExchangeRadioButton.UseVisualStyleBackColor = true;
            this.ohlcvHistoricalDataByAssetAndExchangeRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // exchangesRadioButton
            // 
            this.exchangesRadioButton.AutoSize = true;
            this.exchangesRadioButton.Location = new System.Drawing.Point(832, 19);
            this.exchangesRadioButton.Name = "exchangesRadioButton";
            this.exchangesRadioButton.Size = new System.Drawing.Size(78, 17);
            this.exchangesRadioButton.TabIndex = 19;
            this.exchangesRadioButton.Text = "Exchanges";
            this.exchangesRadioButton.UseVisualStyleBackColor = true;
            this.exchangesRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // ohlcvHistoricalDataBySymbolRadioButton
            // 
            this.ohlcvHistoricalDataBySymbolRadioButton.AutoSize = true;
            this.ohlcvHistoricalDataBySymbolRadioButton.Location = new System.Drawing.Point(427, 19);
            this.ohlcvHistoricalDataBySymbolRadioButton.Name = "ohlcvHistoricalDataBySymbolRadioButton";
            this.ohlcvHistoricalDataBySymbolRadioButton.Size = new System.Drawing.Size(178, 17);
            this.ohlcvHistoricalDataBySymbolRadioButton.TabIndex = 12;
            this.ohlcvHistoricalDataBySymbolRadioButton.Text = "OHLCV historical data by symbol";
            this.ohlcvHistoricalDataBySymbolRadioButton.UseVisualStyleBackColor = true;
            this.ohlcvHistoricalDataBySymbolRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // latestDataRadioButton
            // 
            this.latestDataRadioButton.AutoSize = true;
            this.latestDataRadioButton.Location = new System.Drawing.Point(228, 19);
            this.latestDataRadioButton.Name = "latestDataRadioButton";
            this.latestDataRadioButton.Size = new System.Drawing.Size(78, 17);
            this.latestDataRadioButton.TabIndex = 10;
            this.latestDataRadioButton.Text = "Latest data";
            this.latestDataRadioButton.UseVisualStyleBackColor = true;
            this.latestDataRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // latestDataBySymbolRadioButton
            // 
            this.latestDataBySymbolRadioButton.AutoSize = true;
            this.latestDataBySymbolRadioButton.Location = new System.Drawing.Point(228, 42);
            this.latestDataBySymbolRadioButton.Name = "latestDataBySymbolRadioButton";
            this.latestDataBySymbolRadioButton.Size = new System.Drawing.Size(127, 17);
            this.latestDataBySymbolRadioButton.TabIndex = 9;
            this.latestDataBySymbolRadioButton.Text = "Latest data by symbol";
            this.latestDataBySymbolRadioButton.UseVisualStyleBackColor = true;
            this.latestDataBySymbolRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // latestDataByExchangeAssetPairRadioButton
            // 
            this.latestDataByExchangeAssetPairRadioButton.AutoSize = true;
            this.latestDataByExchangeAssetPairRadioButton.Location = new System.Drawing.Point(228, 133);
            this.latestDataByExchangeAssetPairRadioButton.Name = "latestDataByExchangeAssetPairRadioButton";
            this.latestDataByExchangeAssetPairRadioButton.Size = new System.Drawing.Size(195, 17);
            this.latestDataByExchangeAssetPairRadioButton.TabIndex = 8;
            this.latestDataByExchangeAssetPairRadioButton.Text = "Latest data by exchange assets pair";
            this.latestDataByExchangeAssetPairRadioButton.UseVisualStyleBackColor = true;
            this.latestDataByExchangeAssetPairRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // latestDataByExchangeRadioButton
            // 
            this.latestDataByExchangeRadioButton.AutoSize = true;
            this.latestDataByExchangeRadioButton.Location = new System.Drawing.Point(228, 65);
            this.latestDataByExchangeRadioButton.Name = "latestDataByExchangeRadioButton";
            this.latestDataByExchangeRadioButton.Size = new System.Drawing.Size(142, 17);
            this.latestDataByExchangeRadioButton.TabIndex = 7;
            this.latestDataByExchangeRadioButton.Text = "Latest data by exchange";
            this.latestDataByExchangeRadioButton.UseVisualStyleBackColor = true;
            this.latestDataByExchangeRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // latestDataByBaseAssetRadioButton
            // 
            this.latestDataByBaseAssetRadioButton.AutoSize = true;
            this.latestDataByBaseAssetRadioButton.Location = new System.Drawing.Point(228, 110);
            this.latestDataByBaseAssetRadioButton.Name = "latestDataByBaseAssetRadioButton";
            this.latestDataByBaseAssetRadioButton.Size = new System.Drawing.Size(146, 17);
            this.latestDataByBaseAssetRadioButton.TabIndex = 6;
            this.latestDataByBaseAssetRadioButton.Text = "Latest data by base asset";
            this.latestDataByBaseAssetRadioButton.UseVisualStyleBackColor = true;
            this.latestDataByBaseAssetRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // latestDataByAssetPairRadioButton
            // 
            this.latestDataByAssetPairRadioButton.AutoSize = true;
            this.latestDataByAssetPairRadioButton.Location = new System.Drawing.Point(228, 87);
            this.latestDataByAssetPairRadioButton.Name = "latestDataByAssetPairRadioButton";
            this.latestDataByAssetPairRadioButton.Size = new System.Drawing.Size(140, 17);
            this.latestDataByAssetPairRadioButton.TabIndex = 5;
            this.latestDataByAssetPairRadioButton.Text = "Latest data by asset pair";
            this.latestDataByAssetPairRadioButton.UseVisualStyleBackColor = true;
            this.latestDataByAssetPairRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // historicalTradesBySymbolRadioButton
            // 
            this.historicalTradesBySymbolRadioButton.AutoSize = true;
            this.historicalTradesBySymbolRadioButton.Location = new System.Drawing.Point(6, 19);
            this.historicalTradesBySymbolRadioButton.Name = "historicalTradesBySymbolRadioButton";
            this.historicalTradesBySymbolRadioButton.Size = new System.Drawing.Size(149, 17);
            this.historicalTradesBySymbolRadioButton.TabIndex = 4;
            this.historicalTradesBySymbolRadioButton.Text = "Historical trades by symbol";
            this.historicalTradesBySymbolRadioButton.UseVisualStyleBackColor = true;
            this.historicalTradesBySymbolRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // historicalTradesByExchangeAssetPairRadioButton
            // 
            this.historicalTradesByExchangeAssetPairRadioButton.AutoSize = true;
            this.historicalTradesByExchangeAssetPairRadioButton.Location = new System.Drawing.Point(6, 110);
            this.historicalTradesByExchangeAssetPairRadioButton.Name = "historicalTradesByExchangeAssetPairRadioButton";
            this.historicalTradesByExchangeAssetPairRadioButton.Size = new System.Drawing.Size(217, 17);
            this.historicalTradesByExchangeAssetPairRadioButton.TabIndex = 3;
            this.historicalTradesByExchangeAssetPairRadioButton.Text = "Historical trades by exchange assets pair";
            this.historicalTradesByExchangeAssetPairRadioButton.UseVisualStyleBackColor = true;
            this.historicalTradesByExchangeAssetPairRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // historicalTradesByExchangeRadioButton
            // 
            this.historicalTradesByExchangeRadioButton.AutoSize = true;
            this.historicalTradesByExchangeRadioButton.Location = new System.Drawing.Point(6, 42);
            this.historicalTradesByExchangeRadioButton.Name = "historicalTradesByExchangeRadioButton";
            this.historicalTradesByExchangeRadioButton.Size = new System.Drawing.Size(164, 17);
            this.historicalTradesByExchangeRadioButton.TabIndex = 2;
            this.historicalTradesByExchangeRadioButton.Text = "Historical trades by exchange";
            this.historicalTradesByExchangeRadioButton.UseVisualStyleBackColor = true;
            this.historicalTradesByExchangeRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // historicalTradesByBaseAssetRadioButton
            // 
            this.historicalTradesByBaseAssetRadioButton.AutoSize = true;
            this.historicalTradesByBaseAssetRadioButton.Location = new System.Drawing.Point(6, 87);
            this.historicalTradesByBaseAssetRadioButton.Name = "historicalTradesByBaseAssetRadioButton";
            this.historicalTradesByBaseAssetRadioButton.Size = new System.Drawing.Size(168, 17);
            this.historicalTradesByBaseAssetRadioButton.TabIndex = 1;
            this.historicalTradesByBaseAssetRadioButton.Text = "Historical trades by base asset";
            this.historicalTradesByBaseAssetRadioButton.UseVisualStyleBackColor = true;
            this.historicalTradesByBaseAssetRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // historicalTradesByAssetPairRadioButton
            // 
            this.historicalTradesByAssetPairRadioButton.AutoSize = true;
            this.historicalTradesByAssetPairRadioButton.Location = new System.Drawing.Point(6, 64);
            this.historicalTradesByAssetPairRadioButton.Name = "historicalTradesByAssetPairRadioButton";
            this.historicalTradesByAssetPairRadioButton.Size = new System.Drawing.Size(162, 17);
            this.historicalTradesByAssetPairRadioButton.TabIndex = 0;
            this.historicalTradesByAssetPairRadioButton.Text = "Historical trades by asset pair";
            this.historicalTradesByAssetPairRadioButton.UseVisualStyleBackColor = true;
            this.historicalTradesByAssetPairRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // quoteAssetComboBox
            // 
            this.quoteAssetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.quoteAssetComboBox.FormattingEnabled = true;
            this.quoteAssetComboBox.Location = new System.Drawing.Point(79, 54);
            this.quoteAssetComboBox.Name = "quoteAssetComboBox";
            this.quoteAssetComboBox.Size = new System.Drawing.Size(121, 21);
            this.quoteAssetComboBox.TabIndex = 5;
            this.quoteAssetComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quote asset";
            // 
            // baseAssetComboBox
            // 
            this.baseAssetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baseAssetComboBox.FormattingEnabled = true;
            this.baseAssetComboBox.Location = new System.Drawing.Point(79, 30);
            this.baseAssetComboBox.Name = "baseAssetComboBox";
            this.baseAssetComboBox.Size = new System.Drawing.Size(121, 21);
            this.baseAssetComboBox.TabIndex = 3;
            this.baseAssetComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Base asset";
            // 
            // exchangeComboBox
            // 
            this.exchangeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exchangeComboBox.FormattingEnabled = true;
            this.exchangeComboBox.Location = new System.Drawing.Point(79, 6);
            this.exchangeComboBox.Name = "exchangeComboBox";
            this.exchangeComboBox.Size = new System.Drawing.Size(121, 21);
            this.exchangeComboBox.TabIndex = 1;
            this.exchangeComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exchanges";
            // 
            // periodComboBox
            // 
            this.periodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.periodComboBox.FormattingEnabled = true;
            this.periodComboBox.Location = new System.Drawing.Point(79, 102);
            this.periodComboBox.Name = "periodComboBox";
            this.periodComboBox.Size = new System.Drawing.Size(121, 21);
            this.periodComboBox.TabIndex = 14;
            this.periodComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Period";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 632);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.partsGroupBox);
            this.Controls.Add(this.allGroupBox);
            this.Controls.Add(this.refreshButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.allGroupBox.ResumeLayout(false);
            this.partsGroupBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView allListView;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.ListView firstListView;
        private System.Windows.Forms.ListView secondListView;
        private System.Windows.Forms.ListView thirdListView;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.GroupBox allGroupBox;
        private System.Windows.Forms.GroupBox partsGroupBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox quoteAssetComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox baseAssetComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox exchangeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton historicalTradesByAssetPairRadioButton;
        private System.Windows.Forms.RadioButton historicalTradesByBaseAssetRadioButton;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton historicalTradesByExchangeRadioButton;
        private System.Windows.Forms.RadioButton historicalTradesByExchangeAssetPairRadioButton;
        private System.Windows.Forms.ComboBox symbolComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton historicalTradesBySymbolRadioButton;
        private System.Windows.Forms.RadioButton latestDataBySymbolRadioButton;
        private System.Windows.Forms.RadioButton latestDataByExchangeAssetPairRadioButton;
        private System.Windows.Forms.RadioButton latestDataByExchangeRadioButton;
        private System.Windows.Forms.RadioButton latestDataByBaseAssetRadioButton;
        private System.Windows.Forms.RadioButton latestDataByAssetPairRadioButton;
        private System.Windows.Forms.RadioButton latestDataRadioButton;
        private System.Windows.Forms.RadioButton symbolsInExchangeRadioButton;
        private System.Windows.Forms.RadioButton exchangesByPairRadioButton;
        private System.Windows.Forms.RadioButton exchangesByAssetsRadioButton;
        private System.Windows.Forms.RadioButton metaAssetsRadioButton;
        private System.Windows.Forms.RadioButton metaSymbolsRadioButton;
        private System.Windows.Forms.RadioButton allCurrentRatesRadioButton;
        private System.Windows.Forms.RadioButton assetsRadioButton;
        private System.Windows.Forms.RadioButton allCurrentRatesByExchangeRadioButton;
        private System.Windows.Forms.RadioButton ohlcvHistoricalDataByExchangeRadioButton;
        private System.Windows.Forms.RadioButton metaExchangesRadioButton;
        private System.Windows.Forms.RadioButton ohlcvHistoricalDataByAssetAndExchangeRadioButton;
        private System.Windows.Forms.RadioButton exchangesRadioButton;
        private System.Windows.Forms.RadioButton ohlcvHistoricalDataBySymbolRadioButton;
        private System.Windows.Forms.ComboBox periodComboBox;
        private System.Windows.Forms.Label label7;
    }
}

