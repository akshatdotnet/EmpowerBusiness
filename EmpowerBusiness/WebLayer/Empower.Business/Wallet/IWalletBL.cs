using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empower.Data.Entities;

namespace Empower.Business.Wallet
{
    public interface IWalletBL
    {
        #region wallet
        /// <summary>
        /// create wallet
        /// </summary>
        /// <param name="wallet">Wallet</param>
        /// <param name="createdBy">int</param>
        /// <returns></returns>
        public Task CreateWallet(Empower.Data.Entities.Wallet wallet, int createdBy);

        /// <summary>
        /// update wallet
        /// </summary>
        /// <param name="wallet">Wallet</param>
        /// <param name="modifiedBy">modified by user id</param>
        /// <returns></returns>
        //public Task UpdateWallet(Empower.Data.Entities.Wallet wallet, int modifiedBy);

        /// <summary>
        /// delete wallet
        /// </summary>
        /// <param name="wallet">wallet</param>
        /// <param name="deletedBy">delete by user id</param>
        /// <returns></returns>
        //public Task DeleteWallet(Empower.Data.Entities.Wallet wallet, int deletedBy);

        /// <summary>
        /// get wallet by id
        /// </summary>
        /// <param name="id">wallet id</param>
        /// <returns>wallet</returns>
        //public Task<Empower.Data.Entities.Wallet?> GetWalletById(int id);

        /// <summary>
        /// check if wallet exist or nor for a specific user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //Task<bool> CheckWalletExist(int userId);

        /// <summary>
        /// get wallet by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Wallet</returns>
        //Task<Empower.Data.Entities.Wallet?> GetWalletByUserId(int userId);

        #endregion

    }
}
