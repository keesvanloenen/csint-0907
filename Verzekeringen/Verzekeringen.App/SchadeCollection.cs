using System.Collections;

namespace Verzekeringen.App;

public class SchadeCollection : IEnumerable<Schade>
{
    private Schade[] _schades;      // backing field

	public int Count { get; set; } 

	public Schade this[int index]
	{
		get 
		{
			CheckBounds(index);
			return _schades[index]; 
		}
		set 
		{ 
			CheckBounds(index);
			_schades[index] = value; 
		}
	}

	public Schade? this[string omschrijving]
	{
		get
		{
			return _schades.FirstOrDefault(s => s.Omschrijving == omschrijving);
		}
	}

    private void CheckBounds(int index)
    {
        if (index < 0 || index > Count)
		{
			throw new IndexOutOfRangeException();
		}
    }


	public SchadeCollection(int initialSize = 3)
	{
		_schades = new Schade[initialSize];
		Count = 0;
	}

	public void Add(Schade schade)
	{
		if (Count >= _schades.Length)
		{
			Array.Resize(ref _schades, _schades.Length * 2);
		}

		_schades[Count++] = schade;
	}

    public IEnumerator<Schade> GetEnumerator()
    {
		for (var i = 0; i < Count; i++)
		{
			yield return _schades[i];
		}
	}

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
