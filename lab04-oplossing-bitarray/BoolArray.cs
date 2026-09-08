using System;

namespace BoolArrayProj;

public class BoolArray
{
	private uint _size;
	private ulong[] _data;

	public BoolArray(uint size)
	{
		_size = size;
		//_data = new ulong[(int)(size / 64 + Math.Ceiling(size % 64d))];
		_data = new ulong[(size + 63) / 64];			// 👈 Compact way to calculate te number of ulong-elements to store 'size bits'
                // eg. size = 130
		// 130 / 64 = 2, but we'll need 3 ...
		// (130 + 63) / 64 = 3
	}

    	public bool this[int index]
	{
		get
		{
			BoundaryCheck(index);

			int dataIndex = index / 64;		// 👈 Which ulong ?
			int bitIndex = index % 64;  		// 👈 Which bit (0-63) ?

			return (_data[dataIndex] & (1UL << bitIndex)) != 0;

			/* 🥸
                         * _data[dataIndex] = 0b0001 (binary) => bitindex = 0
                         * _data[dataIndex] = 0b1000 (binary) => bitindex = 3
                         * assume: bitindex = 3

			 * 1UL << 3 = 0b1000 (shift 1 left by 3 positions)
			 * 0b1000 & 0b1000 (result is a non-zero)
			 * 0b1000 != 0 -> true
			*/
        	}

        	set
		{
            		BoundaryCheck(index);

            		int dataIndex = index / 64; 		// 👈 Which ulong ?
			int bitIndex = index % 64;  		// 👈 Which bit (0-63) ?
			
			if (value)
			{
				_data[dataIndex] |= (1UL << bitIndex);  // 👈 Set bit to 1

				/* 🥸
				 * Set bit 3 to 1 in the number 01010101
				 * 1UL << 3 = 00001000
				 * 01010101 |= 0001000 = 01011101 (bit 3 is now 1)
				*/
			}
			else
			{
				_data[dataIndex] &= ~(1UL << bitIndex);	// 👈 Set bit to 0


				/* 🥸
				 * ~ => bitwise NOT: flips all bits (mask becomes all 1s except at bitindex)
				 * Set bit 3 to 0 in the number 01011101
				 * 1UL << 3 = 00001000
				 * ~(1UL << 3) = 11110111
				// 01011101 &= 11110111 = 01010101 (bit 3 is now 0)
			}
		}
	}

    private void BoundaryCheck(int index)
    {
        if (index < 0 || index >= _size)
	{
		throw new IndexOutOfRangeException();
	}
    }
}
