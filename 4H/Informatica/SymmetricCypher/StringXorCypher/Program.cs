using System.Text;

namespace StringXorCypher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                string msg = "Hey! Meet me at 8pm on the 13th street.";
                string key = "That's the key for the encryption, kekw";

                string encryptedString = SymmetricCypher.Encrypt(msg, key);
            }

            {
                string msg = "Hey! Meet me at 8pm on the 13th street.";
                SymmetricCypher cypher = new SymmetricCypher("That's the key for the encryption, kekw");

                string encryptedString = cypher.Encrypt(msg);
            }
        }
    }
}
