public class InsertDeleteGetRandomO1
{
	public static void Run()
	{
		RunCase0([1, 2, 5, 11, 33], [33, 11, 5, 2, 1], 0);
		RunCase0([1, 2, 5, 11, 33], [1, 2, 3, 4, 111], 1);
		RunCase0([1, 5], [], 9);
		RunCase1();
		RunCase2();
	}

	#region Infrastucture
	private static void RunCase0(int[] add, int[] del, int random)
	{
		var obj = new RandomizedSet();

		foreach (var a in add)
			Insert(obj, a);

		foreach (var d in del)
			Remove(obj, d);

		for (int i = 0; i < random; i++)
			GetRandom(obj);

		Console.WriteLine();
	}

	private static void RunCase1()
	{
		var obj = new RandomizedSet();
		Insert(obj, -1);
		Remove(obj, -2);
		Insert(obj, -2);
		GetRandom(obj);
		Remove(obj, -1);
		Insert(obj, -2);
		GetRandom(obj);
		Console.WriteLine();
	}

	private static void RunCase2()
	{
		var obj = new RandomizedSet();
		Insert(obj, 3);
		Insert(obj, 3);
		GetRandom(obj);
		GetRandom(obj);
		Insert(obj, 1);
		Remove(obj, 3);
		GetRandom(obj);
		GetRandom(obj);
		Insert(obj, 0);
		Remove(obj, 0);
		Console.WriteLine();
	}

	private static void Insert(RandomizedSet obj, int val)
	{
		Console.WriteLine($"Insert({val})=>{obj.Insert(val)}");
		obj.PrintItemsToConsole();
	}

	private static void Remove(RandomizedSet obj, int val)
	{
		Console.WriteLine($"Remove({val})=>{obj.Remove(val)}");
		obj.PrintItemsToConsole();
	}

	private static void GetRandom(RandomizedSet obj)
	{
		Console.WriteLine($"GetRandom()=>{obj.GetRandom()}");
		obj.PrintIndexesToConsole();
	}
	#endregion Infrastucture

	public class RandomizedSet
	{
		private int _size = 1;
		private int _count;
		private Item?[] _items = new Item?[1];
		private readonly List<int> _indexes = new();
		private readonly Random _random = new();

		public bool Insert(int val)
		{
			var index = Find(val);

			if (index != -1)
				return false;

			_count++;

			if (_count > _size)
				ResizeItems();

			index = GetIndex(val);

			if (_items[index] is null)
			{
				_indexes.Add(index);
				_items[index] = new Item(val);
			}
			else
			{
				_items[index]!.Add(val);
			}

			return true;
		}

		public bool Remove(int val)
		{
			var index = Find(val);

			if (index == -1)
				return false;

			_count--;

			if (0 == _items[index]!.RemoveAndReturnCount(val))
			{
				_indexes.Remove(index);
				_items[index] = null;
			}

			return true;
		}

		public int GetRandom()
		{
			var indexIndex = _random.Next(_indexes.Count);
			var index = _indexes[indexIndex];
			var item = _items[index]!;
			return item.GetRandom(_random);
		}

		private int GetIndex(int val)
		{
			return Math.Abs(val.GetHashCode() % _size);
		}

		private void ResizeItems()
		{
			var oldSize = _size;
			_size *= 2;
			_indexes.Clear();
			var newItems = new Item[_size];

			for (int i = 0; i < oldSize; i++)
			{
				if (_items[i] is null)
					continue;

				foreach (var val in _items[i]!.Values)
				{
					int index = GetIndex(val);

					if (newItems[index] is null)
					{
						_indexes.Add(index);
						newItems[index] = new Item(val);
					}
					else
					{
						newItems[index]!.Add(val);
					}
				}
			}

			_items = newItems;
		}

		private int Find(int val)
		{
			int index = GetIndex(val);

			if (_items[index] is null || !_items[index]!.Exists(val))
				return -1;

			return index;
		}

		public class Item
		{
			public int[] Values;

			public Item(int val)
			{
				Values = [val];
			}

			public bool Exists(int val)
			{
				if (Values.Length == 1 && Values[0] == val)
				{
					return true;
				}

				return Values.Contains(val);
			}

			public void Add(int val)
			{
				if (Values.Length == 0)
				{
					Values = [val];
					return;
				}

				Values = [.. Values, val];
			}

			public int RemoveAndReturnCount(int val)
			{
				if (Values.Length == 1 && Values[0] == val)
				{
					Values = [];
					return 0;
				}

				Values = Values.Where(v => v != val).ToArray();
				return Values.Length;
			}

			public int GetRandom(Random random)
			{
				if (Values.Length == 0)
				{
					return Values[0];
				}

				return Values[random.Next(Values.Length)];
			}

			override public string ToString()
			{
				return string.Join(", ", Values);
			}
		}

		public void PrintItemsToConsole()
		{
			for (int i = 0; i < _size; i++)
				Console.WriteLine($"{i}: {_items[i]}");
		}
		public void PrintIndexesToConsole()
		{
			Console.WriteLine($"Indexes: {string.Join(", ", _indexes.Order())}");
		}
	}
}
