using System.Numerics;

namespace BitArrays
{
    class BitArray
    {
        private const int BITS_PER_VALUE = 32;
        private uint[] bits;
        private long bitsNumber;

        public BitArray(long bitsNumber, bool initial_value)
        {
            long n_uints = bitsNumber / BITS_PER_VALUE;
            if (bitsNumber % BITS_PER_VALUE != 0)
                ++n_uints;  // serve un (uint) in più per i bits residui

            if (n_uints > int.MaxValue - 60)  // il valore massimo è stato trovato per tentativi
                throw new OverflowException("Too many bits");

            this.bits = new uint[n_uints];
            this.bitsNumber = bitsNumber;
            SetAllBits(initial_value);
        }

        public BitArray(long bitsNumber) : this(bitsNumber, false) { }

        public void SetAllBits(bool value)  // imposta tutti i bit a true o false
        {
            uint _value = 0;
            if (value)
                _value = ~_value;

            for (int i = 0; i < bits.Length; ++i)
                bits[i] = _value;
        }

        public bool GetBit(long bit_index)
        {
            int uint_idx = (int)(bit_index / BITS_PER_VALUE);
            int bit_idx = (int)(bit_index % BITS_PER_VALUE);

            return (bits[uint_idx] & (1 << bit_idx)) != 0;
        }
        public void SetBit(long bit_index, bool value)
        {
            int uint_idx = (int)(bit_index / BITS_PER_VALUE);
            int bit_idx = (int)(bit_index % BITS_PER_VALUE);

            uint mask = (uint)1 << bit_idx;
            if (value)
                bits[uint_idx] |= mask;
            else
                bits[uint_idx] &= ~mask;  // ~ è un not-bitwise (inverte gli 0 e gli 1 della mask)
        }


        public bool this[long index]
        {
            get => GetBit(index);
            set => SetBit(index, value);
        }
    }
}
