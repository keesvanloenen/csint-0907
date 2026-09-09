using System.Collections;

namespace Verzekeringen.App;

public class MijnLijst<T> : IEnumerable<T>
{
    private T[] _items;      // backing field

	public int Count { get; set; } 

	public T this[int index]
	{
		get 
		{
			CheckBounds(index);
			return _items[index]; 
		}
		set 
		{ 
			CheckBounds(index);
			_items[index] = value; 
		}
	}

	//public Schade? this[string omschrijving]
	//{
	//	get
	//	{
	//		return _schades.FirstOrDefault(s => s.Omschrijving == omschrijving);
	//	}
	//}

    private void CheckBounds(int index)
    {
        if (index < 0 || index > Count)
		{
			throw new IndexOutOfRangeException();
		}
    }


	public MijnLijst(int initialSize = 4)
	{
		_items = new T[initialSize];
		Count = 0;
	}

	public void Add(T item)
	{
		if (Count >= _items.Length)
		{
			Array.Resize(ref _items, _items.Length * 2);
		}

		_items[Count++] = item;
	}

    public IEnumerator<T> GetEnumerator()
    {
		for (var i = 0; i < Count; i++)
		{
			yield return _items[i];
		}
	}

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
