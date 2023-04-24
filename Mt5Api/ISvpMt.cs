using MtApi;
using MtApi5;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mt5Api
{
	public interface ISvpMt
	{
		string Symbol { get; set; }
		string AccountCurrency();
		double AccountEquity();
		double SymbolPoint();
		double SymbolTradeTickValue();
		double GetActualPrice();
		double SymbolMinLot();
		double SymbolLotStep();
		int SymbolLotStepDigits();
		int SymbolDigits();
		Orders GetMarketOrders();
		Orders GetPendingOrders();
		ulong CreatePendingOrderSlPtPercent(double price, double units, double slPercent, double ptPercent);
		ulong CreateMarketOrderSlPtPercent(double units, double slPercent, double ptPercent);
		void ModifyPendingOrder(Order order);
		void SetPositionSlAndPt(Order order);
		void SetOrderSlAndPt(Order order);
		bool Connect();
		bool CloseMarketOrder(long orderId);
		bool IsConnected();
		void Disconnect();
		void SetPositionSlAndPtPercent(Order order, double slPercent, double ptPercent);
		void SetPendingOrderSlAndPtPercent(Order order, double slPercent, double ptPercent);
		bool ClosePendingOrder(long orderId);
		int SymbolsTotal(bool symbolsInMarketWatch);
		string SymbolName(int pos, bool fromMarketWatch);
		double DailyClose(int Shift);
		bool IsConnectedConsole();
		ulong CreatePendingOrderSlPtRelative(double price, double units, double slRelative, double ptRelative);
		void SetPendingOrderSlAndPtRelative(Order order, double slRelative, double ptRelative);
		ulong CreateMarketOrderSlPtRelative(double units, double slRelative, double ptRelative);
		void SetPositionSlAndPtRelative(Order order, double slRelative, double ptRelative);
		double GetActualSpread();
		double GetActualBidPrice();
		double GetActualAskPrice();
		ulong CreateMarketOrderSlPt(double units, double Sl, double Pt);
		bool IsOpenPosition();
		double? GetLatestProfit();
		Histories GetLatestProfitHistory(DateTime from, DateTime to);

		// Scalping WTRS
		double WtrsAtr(int period); // period = 5/10
		double WtrsHigh();
		double WtrsLow();		
	}
}
