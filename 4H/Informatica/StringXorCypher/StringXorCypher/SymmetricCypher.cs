using System.Text;

namespace StringXorCypher
{
    class SymmetricCypher
    {
        // Static Methods
        public static byte[] Encrypt(byte[] data, byte[] key)
        {
            if (data.Length != key.Length) throw new ArgumentException("Data and Key must be of the same length.");

            byte[] encryptedData = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                encryptedData[i] = (byte)(data[i] ^ key[i]);
            }

            return encryptedData;
        }

        public static string Encrypt(string data, string key)
        {
            if (data.Length != key.Length) throw new ArgumentException("Data and Key must be of the same length.");

            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            byte[] encryptedData = Encrypt(dataBytes, keyBytes);
            return Encoding.UTF8.GetString(encryptedData);
        }


        // Class Methods
        private byte[] key;

        public SymmetricCypher(byte[] key)
        {
            this.key = key;
        }

        public SymmetricCypher(string key) 
        {
            this.key = Encoding.UTF8.GetBytes(key);
        }

        public byte[] Encrypt(byte[] data)
        {
            return Encrypt(data, key);
        }

        public string Encrypt(string data)
        {
            return Encrypt(data, Encoding.UTF8.GetString(key));
        }
    }
}
