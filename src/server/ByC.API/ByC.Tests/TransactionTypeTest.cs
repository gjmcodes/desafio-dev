using ByC.Domain.Transactions.Entities;
using ByC.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ByC.Tests
{
    [TestClass]
    public class TransactionTypeTest
    {
        static Random typeRange = new Random();

        [TestMethod]
        public void NewTransaction_Type_IsValid()
        {
            // Arrange
            var minMaxType = TransactionTypeHelpers.MinMaxTypeRange;

            var type = typeRange.Next(minMaxType.Item1, minMaxType.Item2);

            var cnab = CNABHelpers.GetCNAB(type: type.ToString());

            // Act
            var transaction = new TransactionRoot(cnab);

            // Assert
            Assert.IsTrue(transaction.Type != null && transaction.Type == type);
        }
    }
}
