using Empower.Data.Entities;
using Empower.Data.Repository;


namespace Empower.Business.Wallet
{
    #region Fields
    //private readonly IRepository<WalletUsage> _walletUsageRepository;    
    //private readonly IRepository<AccountWallet>? _walletRepository;
    //private readonly IRepository<UserDetail> _userDetailRepository;
    //private readonly IUnitOfWorkBL _unitOfWorkBL;
    //private readonly IRepository<Data.Entities.CurrencyMaster> _currency;
    
    #endregion
    public class WalletBL : IWalletBL
    {
        private readonly IRepository<Empower.Data.Entities.Wallet>? _walletRepository;

        #region Ctor
        public WalletBL(
            IRepository<Empower.Data.Entities.Wallet> walletRepository
            //IRepository<UserDetail> userDetailRepository,
            //IRepository<WalletUsage> walletUsageRepository,
            //IUnitOfWorkBL unitOfWorkBL,
            //IRepository<User> userRepository,
            //IRepository<Data.Entities.CurrencyMaster> currency
            )
        {
            _walletRepository = walletRepository;
            //_walletUsageRepository = walletUsageRepository;
            //_unitOfWorkBL = unitOfWorkBL;
            //_userDetailRepository = userDetailRepository;
            //_currency = currency;
        }
        #endregion

        #region Wallet

        /// <summary>
        /// create wallet
        /// </summary>
        /// <param name="wallet">Wallet</param>
        /// <param name="createdBy">int</param>
        /// <returns></returns>
        public virtual async Task CreateWallet(Empower.Data.Entities.Wallet wallet, int createdBy)
        {
            wallet.User = null;
            await _walletRepository.Add(wallet);
        }

        /// <summary>
        /// update wallet
        /// </summary>
        /// <param name="wallet">Wallet</param>
        /// <param name="modifiedBy">modified by user id</param>
        /// <returns></returns>
        //public virtual async Task UpdateWallet(Wallet wallet, int modifiedBy)
        //{
        //    wallet.LastModifiedBy = modifiedBy;
        //    wallet.LastModifiedOn = DateTime.UtcNow;
        //    await _walletRepository.Update(wallet);
        //}

        /// <summary>
        /// delete wallet
        /// </summary>
        /// <param name="wallet">wallet</param>
        /// <param name="deletedBy">delete by user id</param>
        /// <returns></returns>
        //public virtual async Task DeleteWallet(Wallet wallet, int deletedBy)
        //{
        //    wallet.IsDeleted = true;
        //    wallet.IsActive = false;
        //    wallet.DeletedOn = DateTime.UtcNow;
        //    wallet.DeletedBy = deletedBy;
        //    await _walletRepository.Update(wallet);
        //}

        /// <summary>
        /// get wallet by id
        /// </summary>
        /// <param name="id">wallet id</param>
        /// <returns>wallet</returns>
        //public virtual async Task<Wallet?> GetWalletById(int id)
        //{
        //    return await _walletRepository.GetWhere(x => x.Id == id).FirstOrDefaultAsync();
        //}


        /// <summary>
        /// check if wallet exist or nor for a specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //public virtual async Task<bool> CheckWalletExist(int userId)
        //{
        //    var wallet = await _walletRepository.GetWhere(x => x.UserId == userId && x.IsActive).FirstOrDefaultAsync();
        //    if (wallet != null)
        //        return true;
        //    return false;
        //}

        /// <summary>
        /// get wallet by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Wallet</returns>
        //public virtual async Task<Wallet?> GetWalletByUserId(int userId)
        //{
        //    var wallet = await _walletRepository.GetWhere(x => x.UserId == userId && x.IsActive).FirstOrDefaultAsync();
        //    return wallet;
        //}
        #endregion

    }
}
