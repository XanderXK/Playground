namespace DesignPatterns.Structural.Facade
{
    public static class MerchantFacade
    {
        private static Merchant _merchant;
        private static bool _isInitialized;

        public static int Gold => _merchant.Gold;


        public static void Init(Merchant merchant)
        {
            _merchant = merchant;
            _isInitialized = true;
        }

        public static void Buy()
        {
            CheckInitialization();
            _merchant.Buy();
        }

        public static void Sell()
        {
            CheckInitialization();
            _merchant.Sell();
        }

        public static void Repair()
        {
            CheckInitialization();
            _merchant.Repair();
        }

        private static void CheckInitialization()
        {
            if (!_isInitialized)
            {
                throw new System.Exception("Merchant not initialized");
            }
        }
    }
}