﻿

using BoogleClient.BoggleServices;

namespace BoogleClient.ViewModel
{
    internal abstract class BoggleServiceCallback : BaseViewModel, IBoggleServiceContractsCallback
    {
        public virtual void AskForEmailValidation(string accountCreationStatus, string userEmail)
        {
            throw new System.NotImplementedException();
        }

        public virtual void GrantAccess(string accessStatus, AccountDTO accountInfoDTO)
        {
            throw new System.NotImplementedException();
        }

        public virtual void GrantValidation(string validationStatus, AccountDTO accountInfoDTO)
        {
            throw new System.NotImplementedException();
        }

        public virtual void JoinLobby()
        {
            throw new System.NotImplementedException();
        }
    }
}
