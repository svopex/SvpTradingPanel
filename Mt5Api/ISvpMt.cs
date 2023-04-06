using MtApi;
using MtApi5;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mt5Api
{
	public interface ISvpMt
	{
		string AccountCurrency();
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
		bool isConnected();
		void Disconnect();
		void SetPositionSlAndPtPercent(Order order, double slPercent, double ptPercent);
		void SetPendingOrderSlAndPtPercent(Order order, double slPercent, double ptPercent);
		bool ClosePendingOrder(long orderId);
	}
}
