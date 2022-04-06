using System;
using System.Collections;
using System.Collections.Generic;

namespace ByC.Domain.Transactions.Entities
{
    public class CnabRoot
    {
        public string Value { get; private set; }

        public virtual ICollection<TransactionRoot> TransactionRoots { get; private set; }
        //For EF Core
        protected CnabRoot()
        {
        }

        public CnabRoot(string cnab)
        {
            this.Value = cnab;
        }
    }
}
