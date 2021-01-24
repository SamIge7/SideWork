﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Collections.ObjectModel;

namespace Pluralsight.ConcurrentCollections.SellShirts
{
	public class StockController
	{
		private Dictionary<string, TShirt> _stock;

		public StockController(IEnumerable<TShirt> shirts)
		{
			_stock = shirts.ToDictionary(x => x.Code);
		}
		public void Sell(string code)
		{
			_stock.Remove(code);
		}
		public TShirt SelectRandomShirt()
		{
			var keys = _stock.Keys.ToList();
			if (keys.Count == 0)
				return null;    // all shirts sold

			Thread.Sleep(Rnd.NextInt(10));
			string selectedCode = keys[Rnd.NextInt(keys.Count)];
			return _stock[selectedCode];
		}
		public void DisplayStock()
		{
			Console.WriteLine($"\r\n{_stock.Count} items left in stock:");
			foreach (TShirt shirt in _stock.Values)
				Console.WriteLine(shirt);
		}
	}
}
