using System;
using System.Collections.Generic;
using GeneratorLibrary.Model;

namespace GeneratorLibrary.Random
{
	public class RandomWithProbability
	{
		/// <summary>
		/// Возвращает случайное число в указанном диапазоне.
		/// </summary>
		/// <returns>
		/// 32-разрядное целое число со знаком большее или равное <paramref name="minValue"/> и меньше, чем <paramref name="maxValue"/>; то есть, диапазон возвращаемого значения включает <paramref name="minValue"/>, не включает <paramref name="maxValue"/>. Если значение параметра <paramref name="minValue"/> равно значению параметра <paramref name="maxValue"/>, то возвращается значение <paramref name="minValue"/>.
		/// </returns>
		/// <param name="minValue">Включенной нижний предел возвращаемого случайного числа.</param><param name="maxValue">Исключенный верхний предел возвращаемого случайного числа. Значение свойства <paramref name="maxValue"/> должно быть больше или равно значению свойства <paramref name="minValue"/>.</param><exception cref="T:System.ArgumentOutOfRangeException">Значение <paramref name="minValue"/> больше значения <paramref name="maxValue"/>.</exception><filterpriority>1</filterpriority>
		public int Next(int minValue, int maxValue)
		{
			if (maxValue == 0)
				return maxValue;
			return (BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 4) % (((maxValue - 1) + 1) - (minValue))) + (minValue);
		}

		public T Next<T>(IReadOnlyList<ElementWithProbability<T>> elements)
		{
			throw new NotImplementedException();
		}
	}
}