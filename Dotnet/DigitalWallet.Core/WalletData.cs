namespace DigitalWallet.Core
{
    public class WalletData
    {
        // Value types
        public int UserId;
        public decimal Balance;
        public bool IsActive;

        // Reference type
        public string UserName;

        // Array (reference type)
        public decimal[] RecentTransactions;
    }
}