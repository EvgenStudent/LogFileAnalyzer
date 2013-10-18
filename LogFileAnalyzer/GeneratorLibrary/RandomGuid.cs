using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneratorLibrary
{
	public class RandomGuid : Random
	{
		/// <summary>
		/// Возвращает случайное число в указанном диапазоне.
		/// </summary>
		/// <returns>
		/// 32-разрядное целое число со знаком большее или равное <paramref name="minValue"/> и меньше, чем <paramref name="maxValue"/>; то есть, диапазон возвращаемого значения включает <paramref name="minValue"/>, не включает <paramref name="maxValue"/>. Если значение параметра <paramref name="minValue"/> равно значению параметра <paramref name="maxValue"/>, то возвращается значение <paramref name="minValue"/>.
		/// </returns>
		/// <param name="minValue">Включенной нижний предел возвращаемого случайного числа.</param><param name="maxValue">Исключенный верхний предел возвращаемого случайного числа. Значение свойства <paramref name="maxValue"/> должно быть больше или равно значению свойства <paramref name="minValue"/>.</param><exception cref="T:System.ArgumentOutOfRangeException">Значение <paramref name="minValue"/> больше значения <paramref name="maxValue"/>.</exception><filterpriority>1</filterpriority>
		public override int Next(int minValue, int maxValue)
		{
			if (maxValue == 0)
				return maxValue;
			var buf = Guid.NewGuid().ToByteArray();
			var randomValue32 = BitConverter.ToInt32(buf, 4);
			var val = (randomValue32 % (((maxValue - 1) + 1) - (minValue))) + (minValue);
			return val;
		}

		public string Next(IReadOnlyDictionary<string, string> probability)
		{
			double[] array = new double[probability.Values.Sum(x => x.)];
			var buf = Guid.NewGuid().ToByteArray();
			var randomValue32 = BitConverter.ToInt32(buf, 4);
			
			return val;
		}
	}
}